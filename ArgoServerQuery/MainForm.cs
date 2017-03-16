using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using QueryMaster;
using QueryMaster.GameServer;
using System.Collections.Specialized;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ArgoServerQuery
{
    public partial class MainForm : Form
    {
        // TODO: Figure out why the toolstrip keeps resetting to the default renderer, or say fuck it and remember to add 'this.toolStrip1.Renderer = new ToolStripRenderer()' before releasing

        // This dict can be accessed by our bgworker to query a server and update its UI info 
        private Dictionary<string, string> dict_ServerInfo = new Dictionary<string, string>();

        // Create an instance of the BackgroundWorker class to update the server info on a background thread
        private BackgroundWorker bgWorker = new BackgroundWorker();

        // Path to programs base directory
        private string _APP_PATH = AppDomain.CurrentDomain.BaseDirectory;

        public MainForm()
        {
            InitializeComponent();

            if (Properties.Settings.Default.ServerList != null)
            {
                //create a new collection again
                StringCollection collection = new StringCollection();
                //set the collection from the settings variable
                collection = Properties.Settings.Default.ServerList;
                //convert the collection back to a list
                List<string> serversToLoad = collection.Cast<string>().ToList();
                //populate the listview again from the new list
                int i = 0;
                int index = 0;
                foreach (var item in serversToLoad)
                {
                    i++;

                    dict_ServerInfo["addr"] = item;
                    string[] addrInsert = { "", item, "", "", "", "", "", "" };
                    lvMainView.Items.Add(Convert.ToString(i));
                    lvMainView.Items[index].SubItems.AddRange(addrInsert);
                    index++;
                }
            }

            // Hook up the handlers for our BackgroundWorker
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            // RunWorkerAsync() starts the BackgroundWorker and fires the DoWork() event handler
            bgWorker.RunWorkerAsync();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(_APP_PATH, "*.sqlite");
            foreach (string file in files)
            {
                comboServerList.Items.Add(Path.GetFileName(file));
            }

            if (!String.IsNullOrEmpty(Properties.Settings.Default.rconPW) 
                && !String.IsNullOrEmpty(Properties.Settings.Default.key) 
                && !String.IsNullOrEmpty(Properties.Settings.Default.IV))
            {
                txtRconPW.Text = Query.decryptRcon();
            }
        }

        // This event handler does our work asynchronously in the background thread. Making calls to our
        // GUI controls in this method is not thread-safe and will throw an exception. Once this finishes
        // updating the server info, it will fire the RunWorkerCompleted() event.
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> toUpdate = SQLite.bgUpdates();

            if (!toUpdate.Any())
            {
                Console.WriteLine("No servers to update.");
                Thread.Sleep(2000);
            }
            else
            {
                e.Result = Query.bgUpdater(toUpdate);
                Thread.Sleep(1500);
            }
        }


        // This event is called on the main thread that created our GUI, so calling our controls
        // here is thread-safe. Report the results of our background work and use it to update
        // the server listView object with the updated server info.
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (lvMainView.Items.Count != 0)
            {
                // Explicitly cast the list of Updates objects holding new server info
                // back to its correct type after returning from DoWorkEventArgs
                List<Updates> castObj = (List<Updates>)e.Result;
                if (castObj != null)
                {
                    int pos = 0;
                    // Iterate over each instance of the Updates class in the castObj List
                    // and update the server list with new info from properties of each
                    foreach (Updates server in castObj)
                    {
                        try
                        {
                            lvMainView.Items[pos].UseItemStyleForSubItems = false;

                            if (server.serverInfo.Address != lvMainView.Items[pos].SubItems[2].Text)
                            {
                                lvMainView.Items[pos].SubItems[2].Text = server.serverInfo.Address;
                            }
                            if (server.serverInfo.Name != lvMainView.Items[pos].SubItems[3].Text)
                            {
                                lvMainView.Items[pos].SubItems[3].Text = server.serverInfo.Name;
                            }

                            lvMainView.Items[pos].SubItems[1].Text = Convert.ToString(server.serverInfo.Ping) + "ms";
                            lvMainView.Items[pos].SubItems[4].ForeColor = Color.Red;
                            lvMainView.Items[pos].SubItems[4].Text = server.serverInfo.Map;
                            lvMainView.Items[pos].SubItems[5].Text = $@"{server.serverInfo.Players}/{server.serverInfo.MaxPlayers}";

                            if (server.serverInfo.GameVersion != lvMainView.Items[pos].SubItems[6].Text)
                            {
                                lvMainView.Items[pos].SubItems[6].Text = server.serverInfo.GameVersion;
                            }
                            lvMainView.Items[pos].SubItems[7].Text = server.score;

                            lvMainView.Items[pos].BackColor = Color.Empty;
                            pos++;
                        }
                        catch (NullReferenceException)
                        {
                            lvMainView.Items[pos].BackColor = Color.IndianRed;
                            pos++;
                            continue;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            continue;
                        }
                    }
                }
            }

            bgWorker.RunWorkerAsync(); // Start the bgWorker again after its finished updating the server list

        }

        
        private int slot = 0;

        // Event handler for adding a new server to the server list
        private void mnuServersAdd_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,5}$"); // Regex to validate correct IP:Port format

            if (comboServerList.SelectedIndex == -1)
            {
                string text = "Load an existing server list or create a new one before adding a server.";
                string caption = "No Server List Loaded";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result = MessageBox.Show(text, caption, button, icon);

                return;
            }

            string addr = Microsoft.VisualBasic.Interaction.InputBox("Enter server IP followed by port e.g. '123.45.67.890:12345'", 
                "Add Server", "104.206.97.211:27060", -1, -1);

            if (String.IsNullOrEmpty(addr))
            {
                return;
            }

            while (!regex.IsMatch(addr))
            {
                string text = "The IP Address you entered is not valid.";
                string caption = "Invalid Address";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result = MessageBox.Show(text, caption, button, icon);

                if (result == DialogResult.OK)
                {
                    addr = Microsoft.VisualBasic.Interaction.InputBox("Enter server IP followed by port e.g. '123.45.67.890:12345'",
                    "Add Server", "104.206.97.211:27060", -1, -1);
                    if (String.IsNullOrEmpty(addr))
                    {
                        return;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (lvMainView.Items.Count != 0)
            {
                slot = lvMainView.Items.Count + 1;

                // There are a few of these throughout this code. Each null element acts
                // as a blueprint to set up the layout for each subitem/cell in the list
                string[] addrInsert = { "", addr, "", "", "", "", "", "" };

                lvMainView.Items.Add(Convert.ToString(slot)).SubItems.AddRange(addrInsert);
                SQLite.addAddress(addr);
            }
            else if (lvMainView.Items.Count == 0)
            {
                slot++;
                string[] addrInsert = { "", addr, "", "", "", "", "", "" };
                lvMainView.Items.Add(Convert.ToString(slot)).SubItems.AddRange(addrInsert);
                SQLite.addAddress(addr);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1 && !String.IsNullOrEmpty(txtCmd.Text))
            {
                string cmd = txtCmd.Text;
                string rconAddr = lvMainView.SelectedItems[0].SubItems[2].Text;
                const string err = "RCON Error! Authentication failed. Make sure the RCON password is correct.";
                string rconResp = Query.sendRcon(rconAddr, cmd);

                if (String.IsNullOrEmpty(rconResp))
                {
                    showErrors(err);
                }
                else
                {
                    txtOutput.AppendText(rconResp);
                }
            }
        }

        private void txtCmd_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow pressing the enter key to send commands from the textbox
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(this, new EventArgs());
            }
        }

        private void btnSendStatus_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1)
            {
                const string cmd = "status";
                const string err = "RCON Error! Authentication failed. Make sure the RCON password is correct.";
                string rconAddr = lvMainView.SelectedItems[0].SubItems[2].Text;
                string rconResp = Query.sendRcon(rconAddr, cmd);

                if (String.IsNullOrEmpty(rconResp))
                {
                    showErrors(err);
                }
                else
                {
                    txtOutput.AppendText(rconResp);
                }
            }
        }

        private void lvMainView_MouseClick(object sender, MouseEventArgs e)
        {

            ListView listView = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    contextMenuServer.Show(listView, e.Location);
                }
            }
        }

        private void addInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1)
            {
                string info = Microsoft.VisualBasic.Interaction.InputBox("Enter server color info or whatever the hell you want here. I DONT CARE JUST SOMETHING.",
                "Add Info", "", -1, -1);
                string ip = lvMainView.SelectedItems[0].SubItems[2].Text;
                lvMainView.SelectedItems[0].SubItems[8].Text = info;
                SQLite.addInfo(ip, info);
            }
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void delServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1)
            {
                string text = "Are you sure you want to delete this server?";
                string caption = "You sure bro?";
                MessageBoxButtons button = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result = MessageBox.Show(text, caption, button, icon);

                if (result == DialogResult.Yes)
                {
                    string ip = lvMainView.SelectedItems[0].SubItems[2].Text;
                    string strRemoved = lvMainView.SelectedItems[0].Text;
                    int total = lvMainView.Items.Count;

                    SQLite.deleteRecord(ip);
                    lvMainView.SelectedItems[0].Remove();

                    try
                    {
                        int removed = Convert.ToInt16(strRemoved);
                        if (removed == total) { return; }

                        while (removed < total)
                        {
                            int pos = Convert.ToInt16(lvMainView.Items[removed-1].Text);
                            lvMainView.Items[removed-1].Text = Convert.ToString(pos-1);
                            removed++;
                        }
                    }

                    catch (FormatException)
                    { Console.WriteLine("Couldn't convert strRemoved to int."); }
                }
            }
        }

        private void lvMainView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        private void btnRestartServer_Click(object sender, EventArgs e)
        {
            string svAddr = Microsoft.VisualBasic.Interaction.InputBox("Enter the address of the server you wish to restart.",
                "Restart Server", "123.45.67.890:12345", -1, -1);

            ServerTools.serverList(svAddr);
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            txtOutput.SelectionStart = txtOutput.Text.Length;
            txtOutput.ScrollToCaret();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a list to store each address for the servers in the server list
            List<string> serverList = new List<string>();

            foreach (ListViewItem Item in lvMainView.Items)
            {
                serverList.Add(Convert.ToString(Item.SubItems[2].Text));
            }

            // Create a string collection from list of server addresses
            StringCollection collection = new StringCollection();
            collection.AddRange(serverList.ToArray());

            // Set the project ServerList setting to the string collection
            Properties.Settings.Default.ServerList = collection;
            // Save the state and make persistent
            Properties.Settings.Default.Save();
        }

        private void btnUpdatePlayers_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1)
            {
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;
                JArray playerInfo = Query.getPlayerInfo(addr);

                if (playerInfo != null)
                {
                    playersListView.Items.Clear();

                    foreach (JObject player in playerInfo)
                    {
                        string name = Convert.ToString(player["Name"]);

                        string rawTime = Convert.ToString(player["Time"]);
                        string time = rawTime.Remove(rawTime.Length - 8);
                        string[] score_time = { Convert.ToString(player["Score"]), time };

                        playersListView.Items.Add(Convert.ToString(player["Name"])).SubItems.AddRange(score_time);
                    }
                }
                else
                {
                    string err = "Error fetching players...Make sure host_players_show is set to 2.";
                    showErrors(err);
                }
            }
        }

        private void banPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Regex to validate input for ban length
            Regex regex = new Regex(@"^[0-9]+$");

            string banLength;
            string banReason;

            if (playersListView.SelectedItems.Count == 1 && lvMainView.SelectedItems.Count == 1)
            {
                string player = playersListView.SelectedItems[0].Text;
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;

                InputBoxItem[] items = new InputBoxItem[]
                {
                    new InputBoxItem("Length of ban in minutes:", ""),
                    new InputBoxItem("Ban reason (leave blank to skip):", false)
                };

                InputBox input = InputBox.Show("Ban Player From Server", items, InputBoxButtons.OKCancel);

                if (input.Result == InputBoxResult.OK)
                {
                    banLength = input.Items["Length of ban in minutes:"];
                    banReason = input.Items["Ban reason (leave blank to skip):"];

                    if (!regex.IsMatch(banLength))
                    {
                        string text = "Invalid ban length. Did you fuck up? -___-";
                        string caption = "Oops";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        MessageBoxIcon icon = MessageBoxIcon.Error;
                        DialogResult result = MessageBox.Show(text, caption, button, icon);
                        return;
                    }

                    if (!String.IsNullOrEmpty(banReason))
                    {
                        txtOutput.AppendText(Query.banPlayerFromServer(addr, player, banLength, banReason));
                    }
                    else if (String.IsNullOrEmpty(banReason))
                    {
                        txtOutput.AppendText(Query.banPlayerFromServer(addr, player, banLength));
                    }
                }
            }
        }

        private void banServersTSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kickPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]+$");

            if (playersListView.SelectedItems.Count == 1 && lvMainView.SelectedItems.Count == 1)
            {
                string player = playersListView.SelectedItems[0].Text;
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;

                string kickReason = Microsoft.VisualBasic.Interaction.InputBox("Tell 'em why they were kicked, or leave blank to skip.",
                "Kick Reason", "", -1, -1);

                if (!String.IsNullOrEmpty(kickReason))
                {
                    txtOutput.AppendText(Query.kickPlayer(addr, player, kickReason));
                }
                else if (String.IsNullOrEmpty(kickReason))
                {
                    txtOutput.AppendText(Query.kickPlayer(addr, player));
                }
            }
        }

        private void btnNewServerList_Click(object sender, EventArgs e)
        {
            string slName = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the new server list.",
                "New Server List", "", -1, -1);

            if (!String.IsNullOrEmpty(slName))
            {
                if (File.Exists(_APP_PATH + $"{slName}.sqlite"))
                {
                    string text = "A server list with that name already exists. Do you wish to overwrite?";
                    string caption = "File already exists";
                    MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                    MessageBoxIcon icon = MessageBoxIcon.Warning;
                    DialogResult result = MessageBox.Show(text, caption, btn, icon);

                    if (result == DialogResult.OK)
                    {
                        // If user decides to overwrite existing SQLite db, close current SQLite connection, then
                        // try to delete the local db and remove the file from the combobox before rebuilding
                        SQLite.closeConnection();

                        try
                        {
                            File.Delete(_APP_PATH + $"{slName}.sqlite");
                            lvMainView.Items.Clear();
                            comboServerList.Items.Remove(Path.GetFileName($"{slName}.sqlite"));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            string msg = $"Error attempting to delete the server list. \n\nINFO: {ex.Message} \n\nSRC: {ex.Source}";
                            string cap = "Error";
                            MessageBoxButtons ok = MessageBoxButtons.OK;
                            MessageBoxIcon ico = MessageBoxIcon.Error;
                            MessageBox.Show(msg, cap, ok, ico);
                            return;
                        }

                        SQLite.createDB(slName);

                        string[] owFiles = Directory.GetFiles(_APP_PATH, $"{slName}.sqlite");
                        comboServerList.Items.Add(Path.GetFileName(owFiles[0]));
                        comboServerList.SelectedItem = Path.GetFileName(owFiles[0]);

                        List<string> populate = SQLite.loadDB(Convert.ToString(comboServerList.SelectedItem));
                        int i = 1;

                        foreach (string addr in populate)
                        {
                            string[] addrInsert = { "", addr, "", "", "", "", "", "" };
                            lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);
                            i++;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    SQLite.createDB(slName);
                    lvMainView.Items.Clear();

                    string[] files = Directory.GetFiles(_APP_PATH, $"{slName}.sqlite");
                    comboServerList.Items.Add(Path.GetFileName(files[0]));
                    comboServerList.SelectedItem = Path.GetFileName(files[0]);

                    List<string> populate = SQLite.loadDB(Convert.ToString(comboServerList.SelectedItem));
                    int i = 1;

                    foreach (string addr in populate)
                    {
                        string[] addrInsert = { "", addr, "", "", "", "", "", "" };
                        lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);
                        i++;
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult db_SQLite = openFile.ShowDialog();

            if (db_SQLite == DialogResult.OK)
            {
                lvMainView.Items.Clear();
                List<string> populate = SQLite.loadDB(openFile.FileName);
                int i = 1;

                foreach (string addr in populate)
                {
                    string[] addrInsert = { "", addr, "", "", "", "", "", "" };
                    lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);
                    i++;
                }
            }
        }

        private void comboServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboServerList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // This SelectionChangeCommitted event is called when the selected item is changed
            // by the user. Programmatically changing the selected item (such as the result of
            // loading or creating a new SQLite DB) will not call this under most circumstances.

            lvMainView.Items.Clear();
            List<string> populate = SQLite.loadDB(Convert.ToString(comboServerList.SelectedItem));
            int i = 1;

            foreach (string addr in populate)
            {
                string[] addrInsert = { "", addr, "", "", "", "", "", "" };
                lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);
                i++;
            }
        }

        private void toolBtnRCONAll_Click(object sender, EventArgs e)
        {
            if (lvMainView.Items.Count != 0)
            {
                string strRCONAll = Microsoft.VisualBasic.Interaction.InputBox("Type a command to send to all servers in the list:",
                "RCON2All", "", -1, -1);

                if (!String.IsNullOrEmpty(strRCONAll))
                {
                    int num = 0;
                    progressBar.Step = 100 / lvMainView.Items.Count;
                    progressBar.Show();

                    for (int i=0; i < lvMainView.Items.Count; i++)
                    {
                        progressBar.PerformStep();
                        Query.sendRcon(lvMainView.Items[i].SubItems[2].Text, strRCONAll);
                        num++;
                    }

                    progressBar.Hide();
                    string result = $"\"{strRCONAll}\" was sent successfully to {num} servers.";
                    showErrors(result);
                }
            }
        }

        private void toolBtnDeleteList_Click(object sender, EventArgs e)
        {
            string msg;
            string cap;
            string queuedList;
            MessageBoxIcon ico;
            DialogResult result;

            if (comboServerList.SelectedIndex == -1)
            {
                msg = "Hmm..if you're trying to delete a server list, it may be a good idea to pick one first...";
                cap = "No Server List Loaded";
                MessageBoxButtons ok = MessageBoxButtons.OK;
                ico = MessageBoxIcon.Warning;
                MessageBox.Show(msg, cap, ok, ico);
            }
            else
            {
                queuedList = comboServerList.SelectedItem.ToString();
                msg = $"The server list \"{queuedList}\" will be permanently deleted. Do you wish to proceed?";
                cap = $"Delete \"{queuedList}\"?";
                MessageBoxButtons yesNo = MessageBoxButtons.YesNo;
                ico = MessageBoxIcon.Exclamation;
                result = MessageBox.Show(msg, cap, yesNo, ico);

                if (result == DialogResult.Yes)
                {
                    SQLite.closeConnection();
                    lvMainView.Items.Clear();
                    comboServerList.Items.Clear();

                    if (File.Exists(_APP_PATH + queuedList))
                    {
                        try
                        {
                            File.Delete(_APP_PATH + queuedList);
                            msg = "Server list deleted successfully.";
                            cap = "Success";
                            ico = MessageBoxIcon.None;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            msg = $"Error attempting to delete the server list. \n\nINFO: {ex.Message} \n\nSRC: {ex.Source}";
                            cap = "Error";
                            ico = MessageBoxIcon.Error;
                        }
                        MessageBoxButtons btn = MessageBoxButtons.OK;
                        MessageBox.Show(msg, cap, btn, ico);
                    }
                    else
                    {
                        msg = "Server list file not found.";
                        cap = "Error";
                        ico = MessageBoxIcon.Error;
                        MessageBoxButtons btnOK = MessageBoxButtons.OK;
                        MessageBox.Show(msg, cap, btnOK, ico);
                    }

                    string[] files = Directory.GetFiles(_APP_PATH, "*.sqlite");
                    foreach (string file in files)
                    {
                        comboServerList.Items.Add(Path.GetFileName(file));
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void chkTS3_CheckedChanged(object sender, EventArgs e)
        {
            tsMenu.Visible = chkTS3.Checked;
        }

        private void btnRconSave_Click(object sender, EventArgs e)
        {
            string pw = txtRconPW.Text;
            if (!String.IsNullOrEmpty(pw))
            {
                try
                {
                    // Create a new instance of the RijndaelManaged class and generate
                    // a new key and initialization vector.
                    using (RijndaelManaged aesCipher = new RijndaelManaged())
                    {
                        aesCipher.GenerateKey();
                        aesCipher.GenerateIV();
                        string keyb64 = Convert.ToBase64String(aesCipher.Key);
                        string ivb64 = Convert.ToBase64String(aesCipher.IV);
                        Properties.Settings.Default.key = keyb64;
                        Properties.Settings.Default.IV = ivb64;

                        // Encrypt the string to an array of bytes
                        byte[] encrypted = PasswordStorage.EncryptStringToBytes(pw, aesCipher.Key, aesCipher.IV);
                        string base64 = Convert.ToBase64String(encrypted);

                        Properties.Settings.Default.rconPW = base64;
                        Properties.Settings.Default.Save();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }

            lblRconSaved.Show();

            var timer = new System.Windows.Forms.Timer { Interval = 1800 };
            timer.Tick += (start, end) =>
            {
                lblRconSaved.Hide();
                timer.Stop();
            };
            timer.Start();
        }

        private void chkRconShow_CheckedChanged(object sender, EventArgs e)
        {
            txtRconPW.UseSystemPasswordChar = !chkRconShow.Checked;
        }











        public void showErrors(string str)
        {
            lblErrors.Text = str;
            lblErrors.Show();

            var timer = new System.Windows.Forms.Timer { Interval = 8000 };
            timer.Tick += (start, end) =>
            {
                lblErrors.Hide();
                timer.Stop();
            };
            timer.Start();
        }
    }
}

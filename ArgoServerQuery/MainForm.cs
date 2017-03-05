using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using QueryMaster;
using QueryMaster.GameServer;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace ArgoServerQuery
{
    public partial class MainForm : Form
    {
        // This dict can be accessed by our bgworker to query a server and update its UI info 
        private Dictionary<string, string> dict_ServerInfo = new Dictionary<string, string>();

        // Create an instance of the BackgroundWorker class to update the server info on a background thread.
        private BackgroundWorker bgWorker = new BackgroundWorker();

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

            // RunWorkerAsync() starts the BackgroundWorker and fires the DoWork() event handler.
            bgWorker.RunWorkerAsync();

        }


        // This event handler does our work asynchronously in the background thread. Making calls to our
        // GUI controls in this method is not thread-safe and will throw an exception. Once this finishes
        // updating the server info, it will fire the RunWorkerCompleted() event.
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if (!dict_ServerInfo.ContainsKey("addr"))
            {
                Console.WriteLine("Did not contain key 'addr'");
                Thread.Sleep(3000);
            }

            else
            {
                e.Result = Query.sendQuery(dict_ServerInfo["addr"], txtRconPW.Text);

                Thread.Sleep(3000);
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
                for (int i=0; i < lvMainView.Items.Count; i++)
                {
                    // Tuple<ServerInfo, string> newInfo = e.Result as Tuple<ServerInfo, string>;
                    // ServerInfo castObj = newInfo.Item1;
                    // ServerInfo castObj = (ServerInfo)e.Result;
                    ScoreUpdate castObj = (ScoreUpdate)e.Result;

                    if (castObj != null)
                    {
                        try
                        {
                            lvMainView.Items[i].UseItemStyleForSubItems = false;

                            lvMainView.Items[i].SubItems[1].Text = castObj.mainUpdate.Ping.ToString() + "ms";
                            lvMainView.Items[i].SubItems[2].Text = castObj.mainUpdate.Address;
                            lvMainView.Items[i].SubItems[3].Text = castObj.mainUpdate.Name;
                            lvMainView.Items[i].SubItems[4].ForeColor = System.Drawing.Color.Red;
                            lvMainView.Items[i].SubItems[4].Text = castObj.mainUpdate.Map;
                            lvMainView.Items[i].SubItems[5].Text = castObj.mainUpdate.Players.ToString() + "/" + castObj.mainUpdate.MaxPlayers.ToString();
                            lvMainView.Items[i].SubItems[6].Text = castObj.mainUpdate.GameVersion;
                            lvMainView.Items[i].SubItems[7].Text = castObj.rconResp;
                        }
                        catch (NullReferenceException ex)
                        {
                            continue;
                        }
                        
                    }
                }
            }

            // Start the background worker again after it has finished updating the server list
            bgWorker.RunWorkerAsync();
        }
 

        
        private int i = 0;

        // Event handler for adding a new server to the server list
        private void mnuServersAdd_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}:\d{1,5}$");
            string addr = Microsoft.VisualBasic.Interaction.InputBox("Enter server IP followed by port e.g. '123.45.67.890:12345'", 
                "Add Server", "123.45.67.890:12345", -1, -1);

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
                    "Add Server", "123.45.67.890:12345", -1, -1);
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

            //------------------------------------------------------------------------------
            //------------------------------------------------------------------------------
            // CODE FROM HERE UNTIL THE END OF THIS EVENT HANDLER IS SHITTY TEMPORARY SHIT.
            //------------------------------------------------------------------------------
            //------------------------------------------------------------------------------
            string[] addrInsert = { "", addr, "", "", "", "", "", "" };
            string[] olvTest = { "", "", "", addr, "", "", "", "", "", "" };

            i++;
            lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);

            dict_ServerInfo.Add("online",  "");
            dict_ServerInfo.Add("num",     Convert.ToString(i));
            dict_ServerInfo.Add("addr",    addr);
            dict_ServerInfo.Add("name",    "");
            dict_ServerInfo.Add("map",     "");
            dict_ServerInfo.Add("players", "");
            dict_ServerInfo.Add("version", "");
            dict_ServerInfo.Add("info",    "");



            /*MenuItem[] newMI = new MenuItem[] { new MenuItem("Delete"), new MenuItem("Properties") };
            ContextMenu newContextMenu = new ContextMenu(newMI);
            newContextMenu.MenuItems.Add();*/
        }


        private void btnSend_Click(object sender, EventArgs e)
        {

            if (lvMainView.SelectedItems.Count == 1 && !String.IsNullOrEmpty(txtRconPW.Text) && !String.IsNullOrEmpty(txtCmd.Text))
            {
                string rconPW = txtRconPW.Text;
                string cmd = txtCmd.Text;
                string rconAddr = lvMainView.SelectedItems[0].SubItems[2].Text;

                string rconResp = Query.sendRcon(rconAddr, cmd, rconPW);
                txtOutput.AppendText(rconResp);
            }
        }


        private void txtCmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(this, new EventArgs());
            }
        }


        private void btnSendStatus_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1 && !String.IsNullOrEmpty(txtRconPW.Text))
            {
                string rconPW = txtRconPW.Text;
                string cmd = "status";
                string rconAddr = lvMainView.SelectedItems[0].SubItems[2].Text;

                string rconResp = Query.sendRcon(rconAddr, cmd, rconPW);
                txtOutput.AppendText(rconResp);
            }
        }


        private void lvMainView_MouseClick(object sender, MouseEventArgs e)
        {

            ListView listView = sender as ListView;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
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
                lvMainView.SelectedItems[0].SubItems[8].Text = info;
            }
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1 && !String.IsNullOrEmpty(txtRconPW.Text))
            {
                string rconPW = txtRconPW.Text;
                string cmd = "getpugscore";
                string rconAddr = lvMainView.SelectedItems[0].SubItems[2].Text;
                string rconResp = Query.sendRcon(rconAddr, cmd, rconPW);
                string[] splitResp = rconResp.Split('L');

                lvMainView.SelectedItems[0].SubItems[7].Text = splitResp[0];
            }
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

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    lvMainView.SelectedItems[0].Remove();
                }

            }
        }


        private void lvMainView_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvMainView.SelectedItems.Count == 1)
            {
                lvMainView.SelectedItems[0].Selected = true;
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;
                JArray playerInfo = Query.getPlayerInfo(addr);

                if (playerInfo != null)
                {
                    playersListView.Items.Clear();

                    foreach (JObject player in playerInfo)
                    {
                        string name = player["Name"].ToString();

                        string rawTime = player["Time"].ToString();
                        string time = rawTime.Remove(rawTime.Length - 8);
                        string[] score_time = { player["Score"].ToString(), time };

                        playersListView.Items.Add(player["Name"].ToString()).SubItems.AddRange(score_time);
                    }
                }
                else
                {
                    txtOutput.AppendText("Error fetching players...Make sure host_players_show is set to 2.\n");
                }

            }
        }

        void bgPlayers_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        void bgPlayers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
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
                serverList.Add(Item.SubItems[2].Text.ToString());
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
                        string name = player["Name"].ToString();

                        string rawTime = player["Time"].ToString();
                        string time = rawTime.Remove(rawTime.Length - 8);
                        string[] score_time = { player["Score"].ToString(), time };

                        playersListView.Items.Add(player["Name"].ToString()).SubItems.AddRange(score_time);
                    }
                }
                
            }
        }

        private void banPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            string banLength = "";
            string banReason = "";

            if (playersListView.SelectedItems.Count == 1 && lvMainView.SelectedItems.Count == 1 && !String.IsNullOrEmpty(txtRconPW.Text))
            {
                string player = playersListView.SelectedItems[0].Text;
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;
                string pw = txtRconPW.Text;

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
                        txtOutput.AppendText(Query.banPlayerFromServer(addr, player, pw, banLength, banReason));
                    }
                    else if (String.IsNullOrEmpty(banReason))
                    {
                        txtOutput.AppendText(Query.banPlayerFromServer(addr, player, pw, banLength));
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

            if (playersListView.SelectedItems.Count == 1 && lvMainView.SelectedItems.Count == 1 && !String.IsNullOrEmpty(txtRconPW.Text))
            {
                string pw = txtRconPW.Text;
                string player = playersListView.SelectedItems[0].Text;
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;

                string kickReason = Microsoft.VisualBasic.Interaction.InputBox("Tell 'em why they were kicked, or leave blank to skip.",
                "Kick Reason", "", -1, -1);

                if (!String.IsNullOrEmpty(kickReason))
                {
                    txtOutput.AppendText(Query.kickPlayer(addr, player, pw, kickReason));
                }
                else if (String.IsNullOrEmpty(kickReason))
                {
                    txtOutput.AppendText(Query.kickPlayer(addr, player, pw));
                }

            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;

namespace ArgoServerQuery
{
    public partial class MainForm : Form
    {
        // This list is used to persist the command history by saving to Settings.Default
        // List<string> commandHistory = new List<string>();

        // This instance of BackgroundWorker is used to update server info in the UI on a background thread
        private BackgroundWorker bgWorker = new BackgroundWorker();

        // Path to programs base directory in Local AppData
        private static string _APP_PATH = Application.LocalUserAppDataPath;

        // Set a path to a new folder in local appdata for saving server lists. This avoids having
        // to copy server lists from folders of previous versions whenever the program is updated.
        private static string folderBase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string _SL_PATH = $@"{folderBase}\{"ASQT"}\{"ServerLists"}\";
        

    public MainForm()
        {
            InitializeComponent();

            if (!Directory.Exists(_SL_PATH))
            {
                Directory.CreateDirectory(_SL_PATH);
            }
            AppDomain.CurrentDomain.SetData("DataDirectory", _SL_PATH);

            string version = Application.ProductVersion;
            this.Text = $"Argo CS:GO Server Query Tool v{version}";

            // Use our own ToolStripRenderer to remove the ugly bottom border in the .NET tool strip
            toolStrip1.Renderer = new ToolStripRenderer();
            
            // Get any saved server lists in our app directory and add them to comboServerList
            string[] files = Directory.GetFiles(_SL_PATH, "*.sqlite");
            foreach (string file in files)
            {
                if (file != null)
                {
                    comboServerList.Items.Add(Path.GetFileName(file));
                }
            }

            if (!String.IsNullOrEmpty(Properties.Settings.Default.lastLoadedList))
            {
                try
                {
                    // Preload the last open server list 
                    Dictionary<string, string> dict = SQLite.loadDB(Properties.Settings.Default.lastLoadedList);
                    int loadedIndex = comboServerList.FindString(Properties.Settings.Default.lastLoadedList);
                    comboServerList.SelectedIndex = loadedIndex;
                    int i = 1;
                    foreach (KeyValuePair<string, string> addr_info in dict)
                    {
                        string[] addrInsert = { "", addr_info.Key, "", "", "", "", "", addr_info.Value };
                        lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);
                        i++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            // Get history of commands used and add them to comboCmd
            if (Properties.Settings.Default.cmdHistory != null)
            {
                foreach (string command in Properties.Settings.Default.cmdHistory)
                {
                    comboCmd.Items.Insert(0, command);
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
            if (!String.IsNullOrEmpty(Properties.Settings.Default.rconPW) 
                && !String.IsNullOrEmpty(Properties.Settings.Default.key) 
                && !String.IsNullOrEmpty(Properties.Settings.Default.IV))
            {
                txtRconPW.Text = Query.decryptRcon();
            }

            if (!String.IsNullOrEmpty(Properties.Settings.Default.region))
            {
                string region = Properties.Settings.Default.region;
                switch (region)
                {
                    case "EU":
                        comboRegion.SelectedItem = "EU";
                        break;
                    case "NA":
                        comboRegion.SelectedItem = "NA";
                        break;
                    case "AU/NZ":
                        comboRegion.SelectedItem = "AU/NZ";
                        break;
                }
            }  
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // For the lolz, only show on the first run. 'firstRun' is initialized to true in settings.
            if (Properties.Settings.Default.firstRun == true)
            {
                string text = "Hi, I am an Albanian virus but because of poor technology in my country, " +
                              "unfortunately I am not able to harm your computer. Please be so kind to " +
                              "delete one of your important files yourself and then forward me to other " +
                              "users. Many thank for your cooperation! Best regards, Albanian virus.";
                string caption = "Virus Alert!";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                DialogResult result = MessageBox.Show(text, caption, button, icon);

                Properties.Settings.Default.firstRun = false;
                Properties.Settings.Default.Save();
            }
        }

        //-------------------------------------------------------------------------------------------------//
        //- This event handler does our work asynchronously in the background thread. Making calls to our -//
        //- GUI controls in this method is not thread-safe and will throw an exception. Once this finishes //
        //------------- updating the server info, it will fire the RunWorkerCompleted() event. ------------//
        //-------------------------------------------------------------------------------------------------//
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // SQLite.bgUpdates() returns a list of all server IP's in the current server list
            List<string> toUpdate = SQLite.bgUpdates();

            if (!toUpdate.Any())
            {
                Console.WriteLine("No servers to update.");
                Thread.Sleep(2000);
            }
            else
            {
                e.Result = Query.bgUpdater(toUpdate); // Query.bgUpdater() sends queries to each server in the list and
                Thread.Sleep(1000);                   // returns all updated info to bgWorker_RunWorkerCompleted()
            }
        }

        //-----------------------------------------------------------------------------------------//
        //- This event is called on the main thread that created our GUI, so calling our controls -//
        //- here is thread-safe. Report the results of our background work and use it to update ---//
        //--------------- the server listView object with the updated server info. ----------------//
        //-----------------------------------------------------------------------------------------//
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (lvMainView.Items.Count != 0)
            {
                // Explicitly cast the list of Updates objects holding new
                // server info after returning from DoWorkEventArgs
                List<Updates> castObj = (List<Updates>)e.Result;
                if (castObj != null)
                {
                    int pos = 0;
                    // Iterate over each instance of Updates in castObj and update
                    // the server list with new info from properties of each
                    foreach (Updates server in castObj)
                    {
                        try
                        {
                            lvMainView.Items[pos].UseItemStyleForSubItems = false;

                            if (server.getServerInfo().Address != lvMainView.Items[pos].SubItems[2].Text)
                            {
                                lvMainView.Items[pos].SubItems[2].Text = server.getServerInfo().Address;
                            }
                            if (server.getServerInfo().Name != lvMainView.Items[pos].SubItems[3].Text)
                            {
                                lvMainView.Items[pos].SubItems[3].Text = server.getServerInfo().Name;
                            }

                            lvMainView.Items[pos].SubItems[1].Text = Convert.ToString(server.getServerInfo().Ping) + "ms";
                            lvMainView.Items[pos].SubItems[4].ForeColor = Color.Red;
                            lvMainView.Items[pos].SubItems[4].Text = server.getServerInfo().Map;

                            if (server.getServerInfo().Players > 0)
                            {
                                lvMainView.Items[pos].SubItems[5].ForeColor = Color.ForestGreen;
                            }
                            else
                            {
                                lvMainView.Items[pos].SubItems[5].ForeColor = Color.Empty;
                            }

                            lvMainView.Items[pos].SubItems[5].Text = $"{server.getServerInfo().Players}/{server.getServerInfo().MaxPlayers}";

                            if (server.getServerInfo().GameVersion != lvMainView.Items[pos].SubItems[6].Text)
                            {
                                lvMainView.Items[pos].SubItems[6].Text = server.getServerInfo().GameVersion;
                            }
                            lvMainView.Items[pos].SubItems[7].Text = server.getScore();

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

        
        private int slot;

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
                MessageBox.Show(text, caption, button, icon);
                return;
            }

            string addr = Microsoft.VisualBasic.Interaction.InputBox("Enter server IP followed by port e.g. '123.45.67.890:12345'", 
                "Add Server");

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
                    "Add Server");
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

        private void mnuServersAddAll_Click(object sender, EventArgs e)
        {
            if (comboRegion.SelectedItem == null)
            {
                string txt = "Choose your region before using auto build.";
                string cap = "No Region Selected";
                MessageBoxButtons btn = MessageBoxButtons.OK;
                MessageBoxIcon ico = MessageBoxIcon.Warning;
                MessageBox.Show(txt, cap, btn, ico);
                return;
            }

            if (comboServerList.SelectedIndex == -1)
            {
                string text = "Create a new server list before using auto build.";
                string caption = "No Server List Loaded";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBox.Show(text, caption, button, icon);
                return;
            }

            if (lvMainView.Items.Count > 0)
            {
                string text = "Auto build can only be used on new server lists.";
                string caption = "Auto Build Error";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBox.Show(text, caption, button, icon);
                return;
            }

            List<string> loadout = new List<string>();
            string region = comboRegion.SelectedItem.ToString();
            switch (region)
            {
                case "EU":
                    loadout = RegionsStruct.regions.EU;
                    break;
                case "NA":
                    loadout = RegionsStruct.regions.NA;
                    break;
                case "AU/NZ":
                    loadout = RegionsStruct.regions.AU;
                    break;
            }

            int count = new int();
            foreach (string ip in loadout)
            {
                count++;
                string[] addrInsert = { "", ip, "", "", "", "", "", "" };
                lvMainView.Items.Add(Convert.ToString(count)).SubItems.AddRange(addrInsert);
                SQLite.addAddress(ip);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvMainView.SelectedItems.Count == 1 && !String.IsNullOrEmpty(comboCmd.Text))
                {
                    string cmd = comboCmd.Text;
                    string startTime = DateTime.Now.ToString("HH:mm:ss");
                    txtOutput.SelectionColor = Color.Crimson;
                    txtOutput.AppendText($"- {startTime}: {cmd.ToUpper()}\n");
                    txtOutput.SelectionColor = txtOutput.ForeColor;

                    List<string> commandHistory = Properties.Settings.Default.cmdHistory;
                    int findIndex = comboCmd.FindStringExact(cmd);
                    string rconAddr = lvMainView.SelectedItems[0].SubItems[2].Text;

                    if (findIndex == -1)
                    {
                        comboCmd.Items.Insert(0, cmd);
                        commandHistory.Add(cmd);
                        Properties.Settings.Default.cmdHistory = commandHistory;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        comboCmd.Items.RemoveAt(findIndex);
                        commandHistory.Remove(cmd);
                        comboCmd.Items.Insert(0, cmd);
                        commandHistory.Add(cmd);
                        Properties.Settings.Default.cmdHistory = commandHistory;
                        Properties.Settings.Default.Save();
                    }

                    comboCmd.SelectAll();
                    string rconResp = Query.sendRcon(rconAddr, cmd);

                    if (String.IsNullOrEmpty(rconResp))
                    {
                        const string err = "RCON Error! Authentication failed. Make sure the RCON password is correct.";
                        showErrors(err);
                    }
                    else
                    {
                        txtOutput.AppendText($"{rconResp}\n\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                string msg = "This is the error that I need info about. Show me info mr program. thank. " +
                             $"\n\nINFO: {ex.Message} \n\nSRC: {ex.Source} \n\nCODE: {ex.HResult} \n\nSTACK: {ex.StackTrace}";
                string cap = "Error";
                MessageBoxButtons ok = MessageBoxButtons.OK;
                MessageBoxIcon ico = MessageBoxIcon.Error;
                MessageBox.Show(msg, cap, ok, ico);
            }
        }

        private void comboCmd_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow pressing the enter key to send commands from the textbox
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSend_Click(this, new EventArgs());
            }
        }

        private void copyCmdMenuItem_Click(object sender, EventArgs e)
        {
            if (comboCmd.SelectedText.Length > 0)
            {
                string text = comboCmd.SelectedText;
                System.Windows.Forms.Clipboard.SetText(text);
            }
        }

        private void pasteCmdMenuItem_Click(object sender, EventArgs e)
        {
            if (comboCmd.Text.Length > 0)
            {
                string paste = System.Windows.Forms.Clipboard.GetText();
                string existing = comboCmd.Text;
                comboCmd.Text = existing + paste;
                comboCmd.SelectionStart = comboCmd.Text.Length;
            }
            else
            {
                string paste = System.Windows.Forms.Clipboard.GetText();
                comboCmd.Text = paste;
                comboCmd.SelectionStart = comboCmd.Text.Length;
            }
        }

        private void selectAllCmdMenuItem_Click(object sender, EventArgs e)
        {
            if (comboCmd.Text.Length > 0)
            {
                comboCmd.SelectAll();
            }
        }

        private void commonCommands_Click(object sender, EventArgs e)
        {
            string cmd = Convert.ToString(sender);
            comboCmd.Text = cmd;
            comboCmd.SelectionStart = comboCmd.Text.Length;
        }

        private void changelevel_Click(object sender, EventArgs e)
        {
            switch (Convert.ToString(sender))
            {
                case "de_santorini":
                {
                    string cmd = "host_workshop_map 546623875";
                    comboCmd.Text = cmd;
                    comboCmd.SelectionStart = comboCmd.Text.Length;
                    return;
                }
                case "de_season":
                {
                    string cmd = "host_workshop_map 322837144";
                    comboCmd.Text = cmd;
                    comboCmd.SelectionStart = comboCmd.Text.Length;
                    return;
                }
            }

            string map = Convert.ToString(sender);
            comboCmd.Text = "changelevel " + map;
            comboCmd.SelectionStart = comboCmd.Text.Length;
        }

        private void clearCmdMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Are you sure you want to clear the command history?";
            string caption = "Clear command history";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result = MessageBox.Show(text, caption, button, icon);

            if (result == DialogResult.Yes)
            {
                List<string> commandHistory = new List<string>();
                Properties.Settings.Default.cmdHistory = commandHistory;
                Properties.Settings.Default.Save();
                comboCmd.Items.Clear();
                comboCmd.Text = "";
            }
        }

        private void btnSendStatus_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1)
            {
                string startTime = DateTime.Now.ToString("HH:mm:ss");
                const string cmd = "status";
                txtOutput.SelectionColor = Color.Crimson;
                txtOutput.AppendText($"- {startTime}: {cmd.ToUpper()}\n");
                txtOutput.SelectionColor = txtOutput.ForeColor;

                const string err = "Error! Either the server failed to respond or you've entered an invalid RCON password.";
                string rconAddr = lvMainView.SelectedItems[0].SubItems[2].Text;

                string rconResp = Query.sendStatus(rconAddr, cmd);

                if (String.IsNullOrEmpty(rconResp))
                {
                    showErrors(err);
                }
                else
                {
                    txtOutput.AppendText($"{rconResp}\n\n");
                }
            }
        }

        private void copyAddrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1)
            {
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;
                System.Windows.Forms.Clipboard.SetText(addr);
            }
        }

        private void copyMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1)
            {
                string map = lvMainView.SelectedItems[0].SubItems[4].Text;
                System.Windows.Forms.Clipboard.SetText(map);
            }
        }

        private void addInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1)
            {
                string info = Microsoft.VisualBasic.Interaction.InputBox("Enter server color info or whatever the hell you want here. I DONT CARE JUST SOMETHING.",
                "Add Info");
                string ip = lvMainView.SelectedItems[0].SubItems[2].Text;
                lvMainView.SelectedItems[0].SubItems[8].Text = info;
                SQLite.addInfo(ip, info);
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
                "Restart Server", "123.45.67.890:12345");

            ServerTools.serverList(svAddr);
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            txtOutput.SelectionStart = txtOutput.Text.Length;
            txtOutput.ScrollToCaret();
        }

        private void btnUpdatePlayers_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1)
            {
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;
                JArray playerInfo = Query.getPlayerInfo(addr);

                if (playerInfo != null && playerInfo.Count == 2)
                {
                    playersListView.Items.Clear();
                    List<string[]> players = new List<string[]>();

                    foreach (JToken key in playerInfo.First<JToken>())
                    {
                        string[] playerData_T = {(string)key["name"], (string)key["team"], (string)key["frags"], (string)key["deaths"]};
                        players.Add(playerData_T);
                    }

                    foreach (JToken key in playerInfo.Last<JToken>())
                    {
                        string[] playerData_CT = {(string)key["name"], (string)key["team"], (string)key["frags"], (string)key["deaths"]};
                        players.Add(playerData_CT);
                    }

                    int totalPlayers = players.Count;
                    for (int i = 0; i < totalPlayers; i++)
                    {
                        string team = players[i][1];
                        string[] k_d = { players[i][2], players[i][3] };
                        switch (team)
                        {
                            case "T":
                                var group_T = playersListView.Groups["groupT"];
                                var item_T = new ListViewItem { Text = players[i][0], Group = group_T };
                                playersListView.Items.Add(item_T).SubItems.AddRange(k_d);
                                break;
                            case "CT":
                                var group_CT = playersListView.Groups["groupCT"];
                                var item_CT = new ListViewItem { Text = players[i][0], Group = group_CT };
                                playersListView.Items.Add(item_CT).SubItems.AddRange(k_d);
                                break;
                        }
                    }
                }
                else
                {
                    string err;
                    if (playerInfo == null)
                    {
                        err = "Error! Couldn't fetch players...Is the ASQT Pug Stats plugin loaded? (sm plugins list)";
                        showErrors(err);
                        return;
                    }
                    err = "Error parsing teams. Resulting team count was not equal to 2";
                    showErrors(err);
                }
            }
        }

        private void copyPlayerMenuItem_Click(object sender, EventArgs e)
        {
            if (playersListView.SelectedItems.Count == 1)
            {
                string playerName = playersListView.SelectedItems[0].SubItems[0].Text;
                System.Windows.Forms.Clipboard.SetText(playerName);
            }
        }

        private void copySteamIDPlayerMenuItem_Click(object sender, EventArgs e)
        {
            if (playersListView.SelectedItems.Count == 1 && lvMainView.SelectedItems.Count == 1)
            {
                string playerName = Regex.Escape(playersListView.SelectedItems[0].SubItems[0].Text);
                string svAddr = lvMainView.SelectedItems[0].SubItems[2].Text;
                string pattern = $"(.{playerName}.)(.STEAM_)([0-1]:[0-1]:[0-9]+)";

                const string cmd = "status";
                const string err = "Failed to reach the server...";
                string matchErr = $"Could not find a regex match for the SteamID of \"{playerName}\" on the server.";
                
                string rconResp = Query.sendStatus(svAddr, cmd);

                if (String.IsNullOrEmpty(rconResp))
                {
                    showErrors(err);
                }
                else
                {
                    var match = Regex.Match(rconResp, pattern);
                    if (!String.IsNullOrEmpty(match.Groups[0].Value))
                    {
                        string copy = (match.Groups[2].Value + match.Groups[3].Value).Trim();
                        System.Windows.Forms.Clipboard.SetText(copy);
                    }
                    else
                    {
                        showErrors(matchErr);
                    }
                }
            }
        }

        private void banPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Regex to validate input for ban length
            Regex regex = new Regex(@"^[0-9]+$");

            if (playersListView.SelectedItems.Count == 1 && lvMainView.SelectedItems.Count == 1)
            {
                string player = playersListView.SelectedItems[0].Text;
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;

                InputBoxItem[] items = new InputBoxItem[]
                {
                    new InputBoxItem("Length of ban in minutes (0 for perm):", ""),
                    new InputBoxItem("Ban reason (leave blank to skip):", false)
                };

                InputBox input = InputBox.Show("Ban Player From Server", items, InputBoxButtons.OKCancel);

                if (input.Result == InputBoxResult.OK)
                {
                    string banLength = input.Items["Length of ban in minutes (0 for perm):"];
                    string banReason = input.Items["Ban reason (leave blank to skip):"];

                    if (!regex.IsMatch(banLength))
                    {
                        string text = "Invalid ban length. Did you fuck up? -___-";
                        string caption = "Oops";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        MessageBoxIcon icon = MessageBoxIcon.Error;
                        DialogResult dialogResult = MessageBox.Show(text, caption, button, icon);
                        return;
                    }

                    progressBar.Show();
                    int num = 0;
                    int failed = 0;
                    string result = "";

                    for (int i = 0; i < lvMainView.Items.Count; i++)
                    {
                        progressBar.PerformStep();
                        string res = Query.banPlayerFromServer(lvMainView.Items[i].SubItems[2].Text, player, banLength, banReason);
                        if (String.IsNullOrEmpty(res))
                        {
                            failed++;
                        }
                        num++;
                    }

                    if (failed > 0)
                    {
                        int adjusted = num - failed;
                        string grammar = "";

                        switch (failed)
                        {
                            case 1:
                                grammar = "server";
                                break;
                            default:
                                grammar = "servers";
                                break;
                        }

                        progressBar.Hide();
                        result = $"Successfully banned \"{player}\" from {adjusted} servers. (Failed on {failed} {grammar}).";
                        showErrors(result);
                    }
                    else
                    {
                        progressBar.Hide();
                        result = $"Successfully banned \"{player}\" from {num} servers.";
                        showErrors(result);
                    }
                }
            }
        }

        private void banServersTSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kickPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playersListView.SelectedItems.Count == 1 && lvMainView.SelectedItems.Count == 1)
            {
                string player = playersListView.SelectedItems[0].Text;
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;

                string kickReason = Microsoft.VisualBasic.Interaction.InputBox("Tell 'em why they were kicked, or leave blank to skip.",
                "Kick Reason");

                txtOutput.SelectionColor = Color.Crimson;
                txtOutput.AppendText(Query.kickPlayer(addr, player, kickReason));
                txtOutput.SelectionColor = txtOutput.ForeColor;

            }
        }

        private void btnNewServerList_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9()_-]+$");
            string slName = Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the new server list.",
                "New Server List");

            if (!String.IsNullOrEmpty(slName))
            {
                if (regex.IsMatch(slName))
                {
                    if (File.Exists(_SL_PATH + $"{slName}.sqlite"))
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
                                File.Delete(_SL_PATH + $"{slName}.sqlite");
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

                            string[] owFiles = Directory.GetFiles(_SL_PATH, $"{slName}.sqlite");
                            comboServerList.Items.Add(Path.GetFileName(owFiles[0]));
                            comboServerList.SelectedItem = Path.GetFileName(owFiles[0]);

                            Dictionary<string, string> dict = SQLite.loadDB(Convert.ToString(comboServerList.SelectedItem));
                            int i = 1;

                            foreach (KeyValuePair<string, string> addr_info in dict)
                            {
                                string[] addrInsert = { "", addr_info.Key, "", "", "", "", "", addr_info.Value };
                                lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);
                                i++;
                            }
                        }
                    }
                    else
                    {
                        SQLite.createDB(slName);
                        lvMainView.Items.Clear();

                        string[] files = Directory.GetFiles(_SL_PATH, $"{slName}.sqlite");
                        comboServerList.Items.Add(Path.GetFileName(files[0]));
                        comboServerList.SelectedItem = Path.GetFileName(files[0]);

                        Dictionary<string, string> dict = SQLite.loadDB(Convert.ToString(comboServerList.SelectedItem));
                        int i = 1;

                        foreach (KeyValuePair<string, string> addr_info in dict)
                        {
                            string[] addrInsert = { "", addr_info.Key, "", "", "", "", "", addr_info.Value };
                            lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);
                            i++;
                        }
                    }
                }
                else
                {
                    string msg = $"Could not create server list \"{slName}\" because it contains an illegal character.";
                    string cap = "Illegal Character";
                    MessageBoxButtons ok = MessageBoxButtons.OK;
                    MessageBoxIcon ico = MessageBoxIcon.Error;
                    MessageBox.Show(msg, cap, ok, ico);
                    return;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = _SL_PATH;
            openFile.Filter = "sqlite database | *.sqlite";
            openFile.Title = "Open Server List";
            DialogResult db_SQLite = openFile.ShowDialog();

            if (db_SQLite == DialogResult.OK)
            {
                lvMainView.Items.Clear();
                Dictionary<string, string> dict = SQLite.loadDB(Convert.ToString(openFile.FileName));
                Properties.Settings.Default.lastLoadedList = Convert.ToString(comboServerList.SelectedItem);
                Properties.Settings.Default.Save();
                int i = 1;

                foreach (KeyValuePair<string, string> addr_info in dict)
                {
                    string[] addrInsert = { "", addr_info.Key, "", "", "", "", "", addr_info.Value };
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
            Dictionary<string, string> dict = SQLite.loadDB(Convert.ToString(comboServerList.SelectedItem));
            Properties.Settings.Default.lastLoadedList = Convert.ToString(comboServerList.SelectedItem);
            Properties.Settings.Default.Save();
            int i = 1;

            foreach (KeyValuePair<string, string> addr_info in dict)
            {
                string[] addrInsert = { "", addr_info.Key, "", "", "", "", "", addr_info.Value };
                lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);
                i++;
            }
        }

        private void toolBtnRCONAll_Click(object sender, EventArgs e)
        {
            if (lvMainView.Items.Count != 0)
            {
                string strRCONAll = Microsoft.VisualBasic.Interaction.InputBox("Type a command to send to all servers in the list:",
                "RCON2All");
                progressBar.Value = 0;
                progressBar.Step = 100 / lvMainView.Items.Count;

                if (!String.IsNullOrEmpty(strRCONAll))
                {
                    progressBar.Show();
                    int num = 0;
                    int failed = 0;
                    string result = "";

                    for (int i=0; i < lvMainView.Items.Count; i++)
                    {
                        progressBar.PerformStep();
                        string ret = Query.rcon2All(lvMainView.Items[i].SubItems[2].Text, strRCONAll);
                        if (String.IsNullOrEmpty(ret))
                        {
                            failed++;
                        }
                        num++;
                    }

                    if (failed > 0)
                    {
                        int adjusted = num - failed;
                        string grammar = "";

                        switch (failed)
                        {
                            case 1:
                                grammar = "server";
                                break;
                           default:
                                grammar = "servers";
                                break;
                        }

                        progressBar.Hide();
                        result = $"\"{strRCONAll}\" was sent successfully to {adjusted} servers. (Failed on {failed} {grammar}).";
                        showErrors(result);
                    }
                    else
                    {
                        progressBar.Hide();
                        result = $"\"{strRCONAll}\" was sent successfully to {num} servers.";
                        showErrors(result);
                    }              
                }
            }
        }

        private void toolBtnScoreToggle_Click(object sender, EventArgs e)
        {
            if (toolBtnScoreToggle.Checked)
            {
                Properties.Settings.Default.disableScore = false;
            }
            else
            {
                Properties.Settings.Default.disableScore = true;
            }
        }

        private void toolBtnDeleteList_Click(object sender, EventArgs e)
        {
            string msg;
            string cap;
            MessageBoxIcon ico;

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
                string queuedList = comboServerList.SelectedItem.ToString();
                msg = $"The server list \"{queuedList}\" will be permanently deleted. Do you wish to proceed?";
                cap = $"Delete \"{queuedList}\"?";
                MessageBoxButtons yesNo = MessageBoxButtons.YesNo;
                ico = MessageBoxIcon.Exclamation;
                DialogResult result = MessageBox.Show(msg, cap, yesNo, ico);

                if (result == DialogResult.Yes)
                {
                    SQLite.closeConnection();
                    lvMainView.Items.Clear();
                    comboServerList.Items.Clear();

                    if (File.Exists(_SL_PATH + queuedList))
                    {
                        try
                        {
                            File.Delete(_SL_PATH + queuedList);
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

                    string[] files = Directory.GetFiles(_SL_PATH, "*.sqlite");
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

        private void serverListLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_SL_PATH);
            }
            catch (Exception ex)
            {
                if (ex is Win32Exception || ex is FileNotFoundException)
                {
                    string msg = "Couldn't find the server list location :'( \n It must not be in the right place...";
                    string cap = "Error";
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBoxButtons butt = MessageBoxButtons.OK;
                    MessageBox.Show(msg, cap, butt, icon);
                }
            }
        }

        private void chkTS3_CheckedChanged(object sender, EventArgs e)
        {
            Utils.Animate(tsMenu, Utils.Effect.Slide, 150, 180);
        }

        private void btnRconSave_Click(object sender, EventArgs e)
        {
            string pw = txtRconPW.Text;

            if (String.IsNullOrEmpty(pw))
            {
                Properties.Settings.Default.key = null;
                Properties.Settings.Default.IV = null;
                Properties.Settings.Default.rconPW = null;
                Properties.Settings.Default.Save();
            }
            else
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

        private void comboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRegion.SelectedItem != null)
            {
                string region = comboRegion.SelectedItem.ToString();
                Properties.Settings.Default.region = region;
                Properties.Settings.Default.Save();
            }
        }

        private void comboTS3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboTS3.SelectedItem != null)
            {
                if (comboRegion.SelectedItem != null)
                {
                    string selection = comboTS3.SelectedItem.ToString();
                    string region = comboRegion.SelectedItem.ToString();
                    bool chState = new bool();
                    bool msgMode = new bool();

                    switch (selection)
                    {
                        case "Enable Modal Message":
                            TS3Query.modalMessage(msgMode = true);
                            break;
                        case "Disable Modal Message":
                            TS3Query.modalMessage(msgMode);
                            break;
                        case "Move Servers Channel To Top":
                            TS3Query.moveSvParent(region);
                            break;
                        case "Mute RTP Channel":
                            TS3Query.muteUnmuteRTP(chState = true);
                            break;
                        case "Unmute RTP Channel":
                            TS3Query.muteUnmuteRTP(chState);
                            break;
                    }
                    comboTS3.SelectedIndex = -1;
                }
                else
                {
                    string msg = "You must select a region before issuing TS commands.";
                    string cap = "Choose region";
                    MessageBoxIcon icon = MessageBoxIcon.Warning;
                    MessageBoxButtons btn = MessageBoxButtons.OK;
                    MessageBox.Show(msg, cap, btn, icon);
                }
            }
        }

        private void mnuToolsChat_Click(object sender, EventArgs e)
        {
            if (lvMainView.SelectedItems.Count == 1 
                && !String.IsNullOrEmpty(Properties.Settings.Default.key)
                && !String.IsNullOrEmpty(Properties.Settings.Default.IV)
                && !String.IsNullOrEmpty(Properties.Settings.Default.rconPW))
            {
                string addr = lvMainView.SelectedItems[0].SubItems[2].Text;
                //AdminChat.getChats(addr, txtOutput);
            }
        }

        // ColumnClick event handler for playerListView columns to provide sorting
        private void plvColumnClick(object o, ColumnClickEventArgs e)
        {
            // Set the ListViewItemSorter property to a new ListViewItemComparer 
            // object and use it to sort the ListView.
            this.playersListView.ListViewItemSorter = new ListViewItemComparer(e.Column);
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



        // Implements the sorting used by the playersListView when 
        // clicking on a column header
        private class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                if (col == 0)
                {
                    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                }
                return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
            }
        }

        // ListView subclass to enable optimized double buffering
        public class BufferedListView : ListView
        {
            public BufferedListView()
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            }
        }
    }
}

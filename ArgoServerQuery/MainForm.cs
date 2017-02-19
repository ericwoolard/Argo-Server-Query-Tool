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

namespace ArgoServerQuery
{
    public partial class MainForm : Form
    {

        // Create an instance of the BackgroundWorker class to update the server info on a background thread.
        private BackgroundWorker bgWorker = new BackgroundWorker();

        public MainForm()
        {

            InitializeComponent();

            // Hook up the handlers for our BackgroundWorker
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            // RunWorkerAsync() starts the BackgroundWorker and fires the DoWork() event handler.
            bgWorker.RunWorkerAsync();

            // Console.WriteLine("RunWorkerAsync Fired");

        }


        // This event handler does our work asynchronously in the background thread. Making calls to our
        // GUI controls in this method is not thread-safe and will throw an exception. Once this finishes
        // updating the server info, it will fire the RunWorkerCompleted() event.
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            // Console.WriteLine("DoWork Fired");

            if (!dict_ServerInfo.ContainsKey("addr"))
            {
                Console.WriteLine("Did not contain key 'addr'");
                Thread.Sleep(3000);
            }

            else
            {
                e.Result = Query.sendQuery(dict_ServerInfo["addr"]);
                Thread.Sleep(3000);
            }
        }


        // This event is called on the main thread that created our GUI, so calling our controls
        // here is thread-safe. Report the results of our background work and use it to update
        // the server listView object with the updated server info.
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            // Console.WriteLine("RunWorkerCompleted Fired");

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }

            else if (lvMainView.Items.Count != 0)
            {

                for (int i=0; i < lvMainView.Items.Count; i++)
                {
                    ServerInfo castObj = (ServerInfo)e.Result;

                    if (castObj != null)
                    {
                        lvMainView.Items[i].SubItems[1].Text = castObj.Ping.ToString() + "ms";
                        lvMainView.Items[i].SubItems[2].Text = castObj.Address;
                        lvMainView.Items[i].SubItems[3].Text = castObj.Name;
                        lvMainView.Items[i].SubItems[4].Text = castObj.Map;
                        lvMainView.Items[i].SubItems[5].Text = castObj.Players.ToString();
                        lvMainView.Items[i].SubItems[6].Text = castObj.GameVersion;
                        lvMainView.Items[i].SubItems[7].Text = "T's = 0, CT's = 0";
                        lvMainView.Items[i].SubItems[8].Text = "Amber Dallas";
                    }
                }
            }

            // Start the background worker again after it has finished updating the server list
            bgWorker.RunWorkerAsync();
        }
 

        // This dict can be accessed by our bgworker to query a server and update its UI info 
        private Dictionary<string, string> dict_ServerInfo = new Dictionary<string, string>();
        private int i = 0;

        // Event handler for adding a new server to the server list
        private void mnuServersAdd_Click(object sender, EventArgs e)
        {
            i++;
            string addr = Microsoft.VisualBasic.Interaction.InputBox("Enter server IP followed by port e.g. '123.45.67.890:12345'", 
                "Add Server", "104.206.97.211:27060", -1, -1);

            if (addr == " ")
            {
                string text = "The IP Address you entered is not valid.";
                string caption = "Invalid Address";
                MessageBoxButtons button = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Warning;
                MessageBox.Show(text, caption, button, icon);
            }
            else if (addr == "")
            {
                return;
            }

            //------------------------------------------------------------------------------
            //------------------------------------------------------------------------------
            // CODE FROM HERE UNTIL THE END OF THIS EVENT HANDLER IS SHITTY TEMPORARY SHIT.
            //------------------------------------------------------------------------------
            //------------------------------------------------------------------------------
            string[] addrInsert = { "", addr, "", "", "", "", "", "" };
            string[] olvTest = { "", "", "", addr, "", "", "", "", "", "" };

            lvMainView.Items.Add(Convert.ToString(i)).SubItems.AddRange(addrInsert);
            objListView.AddObject(olvTest);

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
            newContextMenu.MenuItems.Add()*/
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


        private void lvMainView_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArgoServerQuery
{
    public partial class TsMenu : UserControl
    {
        public TsMenu()
        {
            InitializeComponent();

            this.Hide();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTsAddress.Text = Properties.Settings.Default.ts3Addr;
            txtSQUser.Text = Properties.Settings.Default.ts3SQUser;
            txtSQPassword.Text = getSQPassword();
            txtSQPort.Text = Properties.Settings.Default.ts3SQPort;
        }

        private static string getSQPassword()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.ts3SQPW)
                && !String.IsNullOrEmpty(Properties.Settings.Default.keyTS)
                && !String.IsNullOrEmpty(Properties.Settings.Default.IVTS))
            {
                try
                {
                    using (RijndaelManaged aesDecryptTS = new RijndaelManaged())
                    {
                        aesDecryptTS.Key = Convert.FromBase64String(Properties.Settings.Default.keyTS);
                        aesDecryptTS.IV = Convert.FromBase64String(Properties.Settings.Default.IVTS);
                        byte[] encrypted = Convert.FromBase64String(Properties.Settings.Default.ts3SQPW);

                        return PasswordStorage.DecryptStringFromBytes(encrypted, aesDecryptTS.Key, aesDecryptTS.IV);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    string message = $"ERROR: Couldn't decrypt ServerQuery password.\n\nINFO: {ex.Message} \n\nSRC: {ex.Source}";
                    string cap = "Error";
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBoxButtons btn = MessageBoxButtons.OK;
                    MessageBox.Show(message, cap, btn, icon);
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        private void btnTsSave_Click(object sender, EventArgs e)
        {
            string addr = txtTsAddress.Text;
            string user = txtSQUser.Text;
            string pw = txtSQPassword.Text;
            string port = txtSQPort.Text;

            if (!String.IsNullOrEmpty(addr) && !String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(pw) && !String.IsNullOrEmpty(port))
            {
                try
                {
                    // Create a new instance of the RijndaelManaged class and generate
                    // a new key and initialization vector.
                    using (RijndaelManaged aesCipherTS = new RijndaelManaged())
                    {
                        aesCipherTS.GenerateKey();
                        aesCipherTS.GenerateIV();
                        string keyb64 = Convert.ToBase64String(aesCipherTS.Key);
                        string ivb64 = Convert.ToBase64String(aesCipherTS.IV);
                        Properties.Settings.Default.keyTS = keyb64;
                        Properties.Settings.Default.IVTS = ivb64;

                        // Encrypt the string to an array of bytes
                        byte[] encrypted = PasswordStorage.EncryptStringToBytes(pw, aesCipherTS.Key, aesCipherTS.IV);
                        string base64 = Convert.ToBase64String(encrypted);

                        Properties.Settings.Default.ts3SQPW = base64;
                        Properties.Settings.Default.ts3Addr = addr;
                        Properties.Settings.Default.ts3SQUser = user;
                        Properties.Settings.Default.ts3SQPort = port;
                        Properties.Settings.Default.Save();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    string message = $"ERROR: Unable to encrypt or store SQ password. \n\nINFO: {ex.Message} \n\nSRC: {ex.Source}";
                    string cap = "Error";
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBoxButtons btn = MessageBoxButtons.OK;
                    MessageBox.Show(message, cap, btn, icon);
                }
            }

            lblTsSaved.Show();
            var timer = new Timer {Interval = 1800};
            timer.Tick += (start, end) =>
            {
                lblTsSaved.Hide();
                timer.Stop();
            };
            timer.Start();
        }
    }
}

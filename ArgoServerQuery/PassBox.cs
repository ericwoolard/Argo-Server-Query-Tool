using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ArgoServerQuery
{
    internal class PassBox
    {
        private Form frm;
        private TextBox txt;
        public string Show(string prompt, string title)
        {
            frm = new Form();
            FlowLayoutPanel FL = new FlowLayoutPanel();
            Label lbl = new Label();
            txt = new TextBox();
            CheckBox hide = new CheckBox();
            Button ok = new Button();
            Button cancel = new Button();

            frm.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MinimizeBox = false;
            frm.MaximizeBox = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Width = 300;
            frm.Height = 200;

            frm.Text = title;
            lbl.Text = prompt;
            ok.Text = "Ok";
            cancel.Text = "Cancel";
            txt.PasswordChar = '*';

            ok.FlatStyle = FlatStyle.Flat;
            ok.BackColor = SystemColors.ButtonShadow;
            ok.ForeColor = SystemColors.ButtonHighlight;
            ok.Cursor = Cursors.Hand;

            cancel.FlatStyle = FlatStyle.Flat;
            cancel.BackColor = SystemColors.ButtonShadow;
            cancel.ForeColor = SystemColors.ButtonHighlight;
            cancel.Cursor = Cursors.Hand;

            FL.Left = 0;
            FL.Top = 0;
            FL.Width = frm.Width;
            FL.Height = frm.Height;
            FL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            FL.Padding = new Padding(22,12,0,0);
            txt.Margin = new Padding(0,0,0,6);
            FL.FlowDirection = FlowDirection.TopDown;

            hide.Text = "Show";
            hide.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            hide.Margin = new Padding(0,0,0,10);

            ok.Width = FL.Width - 100;
            ok.Height = 25;
            txt.Width = FL.Width - 60;
            cancel.Width = ok.Width;
            cancel.Height = 25;
            lbl.Width = txt.Width;
            ok.Margin = new Padding(20,0,0,5);
            cancel.Margin = new Padding(20,0,0,0);

            ok.Click += new System.EventHandler(okClick);
            cancel.Click += new System.EventHandler(cancelClick);
            txt.KeyPress += new KeyPressEventHandler(txtEnter);
            hide.CheckedChanged += new System.EventHandler(this.hideClick);

            FL.Controls.Add(lbl);
            FL.Controls.Add(txt);
            FL.Controls.Add(hide);
            FL.Controls.Add(ok);
            FL.Controls.Add(cancel);
            frm.Controls.Add(FL);

            frm.ShowDialog();
            DialogResult DR = frm.DialogResult;
            frm.Dispose();
            frm = null;
            if (DR == DialogResult.OK)
            {
                return txt.Text;
            }
            else
            {
                return "";
            }
        }
        private void okClick(object sender, System.EventArgs e)
        {
            frm.DialogResult = DialogResult.OK;
            frm.Close();
        }
        private void cancelClick(object sender, System.EventArgs e)
        {
            frm.DialogResult = DialogResult.Cancel;
            frm.Close();
        }
        private void txtEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { okClick(null, null); }
        }
        private void hideClick(object sender, System.EventArgs e)
        {
            if (sender != null)
            {
                bool isChecked = (sender as CheckBox).Checked;
                txt.PasswordChar = isChecked ? '\0' : '*';
            }
        }
    }
}

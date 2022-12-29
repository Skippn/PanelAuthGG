using PanelAuthGG.Utils;
using PanelAuthGG.Winforms;
using Leaf.xNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PanelAuthGG
{
    public partial class Initialform : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        public static string AuthorizationKey { get; set; }
        public Initialform()
        {
            InitializeComponent();
            textBox1.Select();
        }

        private void checkAuthKey_Click(object sender, EventArgs e)
        {
            AuthorizationKey = textBox1.Text;
            if (checkBox1.Checked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\BlitzWare\AdminPanel", "AuthKey", textBox1.Text);
            }
            if (!checkBox1.Checked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\BlitzWare\AdminPanel", "AuthKey", "");
            }
            try
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=count&authorization=" + Initialform.AuthorizationKey).ToString();
                    if (result.Contains("\"status\":\"failed\""))
                    {
                        MessageBox.Show("Invalid Authorization Key!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (result.Contains("\"status\":\"success\""))
                    {
                        Mainform form2 = new Mainform();
                        this.Hide();
                        form2.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex.Message);
                Environment.Exit(0);
            }
        }

        private void authKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExitProgram_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MinimizeProgram_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region menuGrab
        private void Initialform_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Initialform_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Initialform_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        #endregion

        private void Initialform_Load(object sender, EventArgs e)
        {
            string keyName = @"HKEY_CURRENT_USER\Software\BlitzWare\AdminPanel";
            string valueName = "AuthKey";
            if (Registry.GetValue(keyName, valueName, null) == null)
            {
                //code if key Not Exist
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\BlitzWare\AdminPanel", "AuthKey", "");
            }
            else
            {
                //code if key Exist
            }

            var AuthKey = Registry.GetValue(@"HKEY_CURRENT_USER\Software\BlitzWare\AdminPanel", "AuthKey", null);
            if (AuthKey.Equals("") || AuthKey == "")
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\BlitzWare\AdminPanel", "AuthKey", "");
            }
            if (!AuthKey.Equals("") || AuthKey != "")
            {
                textBox1.Text = (string)AuthKey;
            }
        }
    }
}

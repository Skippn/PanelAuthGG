using PanelAuthGG.Utils;
using Leaf.xNet;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PanelAuthGG.Winforms
{
    public partial class Mainform : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        public Mainform()
        {
            InitializeComponent();
            using (HttpRequest httpRequest = new HttpRequest())
            {
                string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=count&authorization=" + Initialform.AuthorizationKey).ToString();
                userCount user = JsonConvert.DeserializeObject<userCount>(result);
                label3.Text = "User Count: " + user.value;
            }
        }

        #region MainMenuButtons
        private void UsersMenu_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button5.Text = "Fetch Users' Info";
            button6.Visible = true;
            button6.Text = "Delete User";
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button9.Location = new Point(89, 239);
            label3.Visible = true;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            this.textBox2.Size = new Size(138, 22);
            label1.Visible = false;
            label2.Visible = false;
            label3.BackColor = Color.FromArgb(31, 35, 41);
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            this.label3.Location = new Point(13, 252);
            label3.Text = "Users: N/A";
            label1.Text = "Username:";
            label4.Visible = false;
        }

        private void LicenseMenu_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            button5.Visible = true;
            button5.Text = "License Generator";
            button6.Visible = true;
            button6.Text = "License Editor";
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = true;
            button9.Location = new Point(89, 180);
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label3.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label4.Visible = true;
            label4.Location = new Point(13, 194);
        }

        private void HwidMenu_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label1.Text = "Username:";
            label2.Visible = false;
            button5.Visible = true;
            button5.Text = "User HWID Info";
            button6.Visible = true;
            button6.Text = "Reset User HWID";
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            this.textBox2.Size = new Size(138, 22);
            label3.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
        }
        #endregion

        #region SubMenuButtons
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Fetch Users' Info")
            {
                label1.Visible = true;
                label2.Visible = false;
                button10.Visible = true;
                textBox1.Visible = true;
                textBox1.ReadOnly = true;
                textBox2.Visible = true;
                this.label1.Location = new Point(405, 408);
                this.textBox1.Location = new Point(174, 128);
                this.textBox2.Location = new Point(466, 405);
                this.textBox2.Location = new Point(466, 405);
                this.button10.Location = new Point(610, 405);
                this.textBox1.Size = new Size(511, 269);
                button10.Text = "Get Info";
                textBox1.Clear();
                textBox2.Clear();
            }
            else if (button5.Text == "License Generator")
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label3.BackColor = Color.FromArgb(40, 40, 50);
                button10.Visible = true;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                textBox1.Visible = true;
                textBox1.ReadOnly = false;
                textBox2.Visible = true;
                this.textBox2.Size = new Size(138, 22);
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox4.ReadOnly = true;
                this.textBox1.Size = new Size(138, 22);
                this.label1.Location = new Point(174, 128);
                this.textBox1.Location = new Point(174, 142);
                this.label2.Location = new Point(174, 174);
                this.textBox2.Location = new Point(174, 188);
                this.label3.Location = new Point(174, 220);
                this.textBox3.Location = new Point(174, 234);
                this.button10.Location = new Point(174, 260);
                this.textBox4.Location = new Point(380, 92);
                this.textBox4.Size = new Size(300, 340);
                label1.Text = "Amount (max. 25):";
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
                label2.Text = "Duration in days:";
                label3.Text = "Level:";
                button10.Text = "Generate";
                textBox4.Clear();
            }
            else if (button5.Text == "User HWID Info")
            {
                label1.Visible = true;
                label2.Visible = false;
                button10.Visible = true;
                textBox1.Visible = true;
                textBox1.ReadOnly = true;
                textBox2.Visible = true;
                this.label1.Location = new Point(405, 408);
                this.textBox1.Location = new Point(174, 128);
                this.textBox2.Location = new Point(466, 405);
                this.textBox2.Location = new Point(466, 405);
                this.button10.Location = new Point(610, 405);
                this.textBox1.Size = new Size(511, 269);
                button10.Text = "Get HWID";
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Delete User")
            {
                label1.Visible = true;
                label2.Visible = false;
                button10.Visible = true;
                textBox1.Visible = true;
                textBox1.ReadOnly = true;
                textBox2.Visible = true;
                this.label1.Location = new Point(405, 408);
                this.textBox1.Location = new Point(174, 128);
                this.textBox2.Location = new Point(466, 405);
                this.button10.Location = new Point(610, 405);
                this.textBox1.Size = new Size(511, 269);
                button10.Text = "Delete";
                textBox1.Clear();
                textBox2.Clear();
            }
            else if (button6.Text == "License Editor")
            {
                label1.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                button10.Visible = true;
                button11.Visible = true;
                button12.Visible = true;
                button13.Visible = true;
                textBox1.Visible = true;
                textBox1.ReadOnly = true;
                textBox2.Visible = true;
                textBox3.Visible = false;
                textBox4.Visible = false;
                this.label1.Location = new Point(174, 128);
                this.textBox2.Location = new Point(174, 142);
                this.button10.Location = new Point(360, 142);
                this.textBox1.Location = new Point(174, 188);
                this.button11.Location = new Point(174, 350);
                this.button12.Location = new Point(263, 350);
                this.button13.Location = new Point(352, 350);
                this.textBox1.Size = new Size(260, 150);
                this.textBox2.Size = new Size(178, 22);
                label1.Text = "License:";
                button10.Text = "Check";
                textBox1.Clear();
                textBox2.Clear();
            }
            else if (button6.Text == "Reset User HWID")
            {
                label1.Visible = true;
                label2.Visible = false;
                button10.Visible = true;
                textBox1.Visible = true;
                textBox1.ReadOnly = true;
                textBox2.Visible = true;
                this.label1.Location = new Point(405, 408);
                this.textBox1.Location = new Point(174, 128);
                this.textBox2.Location = new Point(466, 405);
                this.textBox2.Location = new Point(466, 405);
                this.button10.Location = new Point(610, 405);
                this.textBox1.Size = new Size(511, 269);
                button10.Text = "Reset";
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        [Obsolete]
        private void button7_Click(object sender, EventArgs e)
        {
            button10.Visible = true;
            textBox1.Visible = true;
            textBox1.ReadOnly = false;
            textBox2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            this.textBox1.Size = new Size(138, 22);
            this.label1.Location = new Point(174, 128);
            this.textBox1.Location = new Point(174, 142);
            this.label2.Location = new Point(174, 174);
            this.textBox2.Location = new Point(174, 188);
            this.button10.Location = new Point(174, 215);
            button10.Text = "Update Variable";
            label2.Text = "New Variable:";
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button10.Visible = true;
            textBox1.Visible = true;
            textBox1.ReadOnly = false;
            textBox2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            this.textBox1.Size = new Size(138, 22);
            this.label1.Location = new Point(174, 128);
            this.textBox1.Location = new Point(174, 142);
            this.label2.Location = new Point(174, 174);
            this.textBox2.Location = new Point(174, 188);
            this.button10.Location = new Point(174, 215);
            button10.Text = "Update Password";
            label2.Text = "New Password:";
            textBox1.Clear();
            textBox2.Clear();
        }
        #endregion

        #region idkWhatToNameIt
        /*  button10 is used for all operations, when clicked on a submenu the text of button10 gets changed.
            If button 10 gets clicked on it checks what the current text is,
            if match -> runs the code in the if statement                                                       */
        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text == "Get Info")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string userFetch = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=fetch&authorization=" + Initialform.AuthorizationKey + "&user=" + userFetch).ToString();
                        if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("Something went wrong. Try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        informationUser user = JsonConvert.DeserializeObject<informationUser>(result);
                        textBox1.Text = "Username: " +  user.username + Environment.NewLine + Environment.NewLine + "\nEmail: " + user.email + Environment.NewLine + Environment.NewLine 
                            + "\nRank: " + user.rank + Environment.NewLine + Environment.NewLine + "\nHWID: " + user.hwid + Environment.NewLine + Environment.NewLine + "\nVariable: " + user.variable + Environment.NewLine
                             + Environment.NewLine + "\nLast Login: " + user.lastlogin + Environment.NewLine + Environment.NewLine + "\nLast IP: "+ user.lastip + Environment.NewLine 
                             + Environment.NewLine + "\nExpiry: " + user.expiry;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
            else if (button10.Text == "Delete")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string userSearch = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=delete&authorization=" + Initialform.AuthorizationKey + "&user=" + userSearch).ToString();
                        if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("Something went wrong. Try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        userDelete user = JsonConvert.DeserializeObject<userDelete>(result);
                        textBox1.Text = "Status: " + user.status + Environment.NewLine + Environment.NewLine + "\nInfo: " + user.info;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
            else if (button10.Text == "Update Variable")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string userSearch = textBox1.Text;
                    string newVariable = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=editvar&authorization=" + Initialform.AuthorizationKey + "&user=" + userSearch + "&value=" + newVariable).ToString();
                        if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("Something went wrong. Try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        editVariable user = JsonConvert.DeserializeObject<editVariable>(result);
                        MessageBox.Show("Status: " + user.status + Environment.NewLine + "\nInfo: " + user.info, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
            else if (button10.Text == "Update Password")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string userSearch = textBox1.Text;
                    string newPassword = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=changepw&authorization=" + Initialform.AuthorizationKey + "&user=" + userSearch + "&password=" + newPassword).ToString();
                        if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("Something went wrong. Try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        editVariable user = JsonConvert.DeserializeObject<editVariable>(result);
                        MessageBox.Show("Status: " + user.status + Environment.NewLine + "\nInfo: " + user.info, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
            else if (button10.Text == "Generate")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    int amount = int.Parse(textBox1.Text);
                    string days = textBox2.Text;
                    string level = textBox3.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=generate&days=" + days + "&amount=" + amount + "&level=" + level + "&format=2" + "&authorization=" + Initialform.AuthorizationKey).ToString();
                        if (amount > 25)
                        {
                            MessageBox.Show("You can only generate 25 licenses at once!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("All fields must be filled in!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            textBox4.Clear();
                            string licenseKey = licenseAjust(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
            else if (button10.Text == "Check")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string license = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=fetch&authorization=" + Initialform.AuthorizationKey + "&license=" + license).ToString();
                        informationLicense infoLicense = JsonConvert.DeserializeObject<informationLicense>(result);
                        if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("Something went wrong. Try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        textBox1.Text = "Status: " + infoLicense.status + Environment.NewLine + Environment.NewLine + "\nLicense: " + infoLicense.license + Environment.NewLine + Environment.NewLine
                           + "\nRank: " + infoLicense.rank + Environment.NewLine + Environment.NewLine + "\nUsed: " + infoLicense.used + Environment.NewLine + Environment.NewLine 
                           + "\nUsed By: " + infoLicense.used_by + Environment.NewLine + Environment.NewLine + "\nCreated: " + infoLicense.created;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
            else if (button10.Text == "Get HWID")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string userFetch = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/HWID/?type=fetch&authorization=" + Initialform.AuthorizationKey + "&user=" + userFetch).ToString();
                        if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("Something went wrong. Try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        HWIDInformation user = JsonConvert.DeserializeObject<HWIDInformation>(result);
                        textBox1.Text = "Status: " + user.status + Environment.NewLine + Environment.NewLine + "\nHWID: " + user.value;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
            else if (button10.Text == "Reset")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string license = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/HWID/?type=reset&authorization=" + Initialform.AuthorizationKey + "&user=" + license).ToString();
                        if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("Something went wrong. Try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        HWIDInformation user = JsonConvert.DeserializeObject<HWIDInformation>(result);
                        textBox1.Text = "Status: " + user.status + Environment.NewLine + Environment.NewLine + "\nHWID: " + user.value;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
        }
        #endregion

        #region UserAndLicenseCountButton
        private void UserAndLicenseCount_Click(object sender, EventArgs e)
        {
            if (label3.Text.Contains("User"))
            {
                label1.Visible = false;
                label2.Visible = false;
                button10.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string userSearch = textBox1.Text;
                    string newPassword = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/USERS/?type=count&authorization=" + Initialform.AuthorizationKey).ToString();
                        if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("Something went wrong. Try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        userCount user = JsonConvert.DeserializeObject<userCount>(result);
                        label3.Text = "Users: " + user.value;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
            if (label4.Visible)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string userSearch = textBox1.Text;
                    string newPassword = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=count&authorization=" + Initialform.AuthorizationKey).ToString();
                        if (result.Contains("\"status\":\"failed\""))
                        {
                            MessageBox.Show("Something went wrong. Try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        licensesCount countLi = JsonConvert.DeserializeObject<licensesCount>(result);
                        label4.Text = "Licenses: " + countLi.value;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
        }
        #endregion

        #region LicenseMenuButtons
        private void UseLicense_Click(object sender, EventArgs e)
        {
            if (button11.Text == "Use")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string license = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=use&license=" + license + "&authorization=" + Initialform.AuthorizationKey).ToString();
                        useLicense unuse = JsonConvert.DeserializeObject<useLicense>(result);  
                        MessageBox.Show("Status: " + unuse.status + Environment.NewLine + "Info: " + unuse.info, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void UnuseLicense_Click(object sender, EventArgs e)
        {
            if (button12.Text == "Unuse")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string license = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=unuse&license=" + license + "&authorization=" + Initialform.AuthorizationKey).ToString();
                        useLicense unuse = JsonConvert.DeserializeObject<useLicense>(result);
                        MessageBox.Show("Status: " + unuse.status + Environment.NewLine + "Info: " + unuse.info, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void DeleteLicense_Click(object sender, EventArgs e)
        {
            if (button13.Text == "Delete")
            {
                using (HttpRequest httpRequest = new HttpRequest())
                {
                    string license = textBox2.Text;
                    try
                    {
                        string result = httpRequest.Get("https://developers.auth.gg/LICENSES/?type=delete&license=" + license + "&authorization=" + Initialform.AuthorizationKey).ToString();
                        useLicense unuse = JsonConvert.DeserializeObject<useLicense>(result);
                        MessageBox.Show("Status: " + unuse.status + Environment.NewLine + "Info: " + unuse.info, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(" " + ex.Message);
                        Environment.Exit(0);
                    }
                }
            }
        }
        #endregion

        // needed to generate keys
        public string licenseAjust(string text)
        {
            string result = text.Replace("{\"0\"", string.Empty).Replace("\"1\"", string.Empty).Replace("\"2\"", string.Empty).Replace("\"3\"", string.Empty).Replace("\"4\"", string.Empty).Replace("\"5\"", string.Empty).Replace("\"6\"", string.Empty).Replace("\"7\"", string.Empty).Replace("\"8\"", string.Empty).Replace("\"9\"", string.Empty).Replace("\"10\"", string.Empty).Replace("\"11\"", string.Empty).Replace("\"12\"", string.Empty).Replace("\"13\"", string.Empty).Replace("\"14\"", string.Empty).Replace("\"15\"", string.Empty).Replace("\"16\"", string.Empty).Replace("\"17\"", string.Empty).Replace("\"18\"", string.Empty).Replace("\"19\"", string.Empty).Replace("\"20\"", string.Empty).Replace("\"21\"", string.Empty).Replace("\"22\"", string.Empty).Replace("\"23\"", string.Empty).Replace("\"24\"", string.Empty).Replace("\"25\"", string.Empty).Replace("}", string.Empty).Replace(":\"", string.Empty).Replace("\"", string.Empty).Replace(" ", string.Empty);
            string[] licenseFinish = result.Split(',');
            foreach (var licenses in licenseFinish)
            {
                textBox4.Text += licenses + Environment.NewLine;
                Console.WriteLine(licenses, Color.White);
            }
            return "done";
        }

        // on mainform load, click on button1 so it displays the side submenu buttons
        private void Mainform_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
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
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
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

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

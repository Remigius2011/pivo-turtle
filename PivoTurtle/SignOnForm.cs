using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PivoTurtle
{
    public partial class SignOnForm : Form
    {
        private string userId;
        private string password;
        private bool saveServerToken = false;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool SaveServerToken
        {
            get { return saveServerToken; }
            set { saveServerToken = value; }
        }

        public static bool SignOn(ref string userId, ref string password)
        {
            SignOnForm form = new SignOnForm();
            form.UserId = userId.Length > 0 ? userId : Properties.Settings.Default.UserId;
            form.Password = password;
            form.SaveServerToken = Properties.Settings.Default.SaveServerToken;
            if (form.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            userId = form.UserId;
            password = form.Password;
            Properties.Settings.Default.UserId = userId;
            Properties.Settings.Default.SaveServerToken = form.SaveServerToken;
            return true;
        }

        public SignOnForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            userId = textBoxUserid.Text;
            password = textBoxPassword.Text;
            saveServerToken = checkBoxSaveServerToken.Checked;
        }

        private void SignOnDialog_Load(object sender, EventArgs e)
        {
            textBoxUserid.Text = userId;
            textBoxPassword.Text = password;
            checkBoxSaveServerToken.Checked = saveServerToken;
        }
    }
}

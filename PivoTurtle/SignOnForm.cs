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

        public static bool SignOn(ref string userId, ref string password)
        {
            SignOnForm form = new SignOnForm();
            form.UserId = userId;
            form.Password = password;
            if (form.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            userId = form.UserId;
            password = form.Password;
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
        }

        private void SignOnDialog_Load(object sender, EventArgs e)
        {
            textBoxUserid.Text = userId;
            textBoxPassword.Text = password;
        }
    }
}

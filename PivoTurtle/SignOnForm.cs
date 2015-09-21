/*
 Copyright 2012 Descom Consulting Ltd.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

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
            
            // update property values

            Properties.Settings.Default.UserId = userId;
            Properties.Settings.Default.SaveServerToken = form.SaveServerToken;

            // Added 1/1/2014 - Persist the changed property values if required to

            if (form.SaveServerToken) 
                Properties.Settings.Default.Save();   

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

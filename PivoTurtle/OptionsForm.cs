using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PivoTurtle
{
    public partial class OptionsForm : Form
    {
        public static bool ShowOptions()
        {
            OptionsForm form = new OptionsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            return false;
        }

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void buttonResetToken_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TokenGuid = "";
            Properties.Settings.Default.TokenId = -1;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
        }
    }
}

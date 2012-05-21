using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PivoTurtle
{
    public partial class ErrorForm : Form
    {
        private Exception x;

        public static void ShowException(Exception x, string caption)
        {
            ErrorForm form = new ErrorForm(x);
            form.Text = caption;
            form.ShowDialog();
        }

        public ErrorForm(Exception x)
        {
            this.x = x;
            InitializeComponent();
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            textBoxMessage.Text = x.Message;
            textBoxStackTrace.Text = x.StackTrace.ToString();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(x.Message + "\r\n\r\n" + x.StackTrace.ToString());
        }
    }
}

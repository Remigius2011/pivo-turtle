namespace PivoTurtle
{
    partial class SignOnForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUserid = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxSaveCredentials = new System.Windows.Forms.CheckBox();
            this.textBoxUserid = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelUserid
            // 
            this.labelUserid.AutoSize = true;
            this.labelUserid.Location = new System.Drawing.Point(12, 15);
            this.labelUserid.Name = "labelUserid";
            this.labelUserid.Size = new System.Drawing.Size(37, 13);
            this.labelUserid.TabIndex = 0;
            this.labelUserid.Text = "Userid";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 41);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(264, 107);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(183, 107);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveCredentials
            // 
            this.checkBoxSaveCredentials.AutoSize = true;
            this.checkBoxSaveCredentials.Location = new System.Drawing.Point(15, 72);
            this.checkBoxSaveCredentials.Name = "checkBoxSaveCredentials";
            this.checkBoxSaveCredentials.Size = new System.Drawing.Size(106, 17);
            this.checkBoxSaveCredentials.TabIndex = 4;
            this.checkBoxSaveCredentials.Text = "Save Credentials";
            this.checkBoxSaveCredentials.UseVisualStyleBackColor = true;
            // 
            // textBoxUserid
            // 
            this.textBoxUserid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserid.Location = new System.Drawing.Point(122, 12);
            this.textBoxUserid.Name = "textBoxUserid";
            this.textBoxUserid.Size = new System.Drawing.Size(217, 20);
            this.textBoxUserid.TabIndex = 5;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(122, 38);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(217, 20);
            this.textBoxPassword.TabIndex = 6;
            // 
            // SignOnDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(351, 142);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserid);
            this.Controls.Add(this.checkBoxSaveCredentials);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserid);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignOnDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sign On to Pivotal Tracker";
            this.Load += new System.EventHandler(this.SignOnDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserid;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxSaveCredentials;
        private System.Windows.Forms.TextBox textBoxUserid;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}
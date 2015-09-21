namespace PivoTurtle
{
    partial class OptionsForm
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
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonResetToken = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxDataDirectory = new System.Windows.Forms.TextBox();
			this.labelDataDirectory = new System.Windows.Forms.Label();
			this.checkBoxAllowOffline = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(255, 80);
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
			this.buttonCancel.Location = new System.Drawing.Point(336, 80);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonResetToken
			// 
			this.buttonResetToken.Location = new System.Drawing.Point(1, 80);
			this.buttonResetToken.Name = "buttonResetToken";
			this.buttonResetToken.Size = new System.Drawing.Size(139, 23);
			this.buttonResetToken.TabIndex = 0;
			this.buttonResetToken.Text = "Reset Server Token";
			this.buttonResetToken.UseVisualStyleBackColor = true;
			this.buttonResetToken.Click += new System.EventHandler(this.buttonResetToken_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBoxDataDirectory);
			this.groupBox1.Controls.Add(this.labelDataDirectory);
			this.groupBox1.Controls.Add(this.checkBoxAllowOffline);
			this.groupBox1.Location = new System.Drawing.Point(1, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(410, 72);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Debugging";
			// 
			// textBoxDataDirectory
			// 
			this.textBoxDataDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDataDirectory.Location = new System.Drawing.Point(87, 41);
			this.textBoxDataDirectory.Name = "textBoxDataDirectory";
			this.textBoxDataDirectory.Size = new System.Drawing.Size(295, 20);
			this.textBoxDataDirectory.TabIndex = 11;
			// 
			// labelDataDirectory
			// 
			this.labelDataDirectory.AutoSize = true;
			this.labelDataDirectory.Location = new System.Drawing.Point(6, 44);
			this.labelDataDirectory.Name = "labelDataDirectory";
			this.labelDataDirectory.Size = new System.Drawing.Size(75, 13);
			this.labelDataDirectory.TabIndex = 10;
			this.labelDataDirectory.Text = "Data Directory";
			// 
			// checkBoxAllowOffline
			// 
			this.checkBoxAllowOffline.AutoSize = true;
			this.checkBoxAllowOffline.Location = new System.Drawing.Point(6, 19);
			this.checkBoxAllowOffline.Name = "checkBoxAllowOffline";
			this.checkBoxAllowOffline.Size = new System.Drawing.Size(102, 17);
			this.checkBoxAllowOffline.TabIndex = 9;
			this.checkBoxAllowOffline.Text = "Allow offline use";
			this.checkBoxAllowOffline.UseVisualStyleBackColor = true;
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(413, 105);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonResetToken);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "PivoTurtle Options";
			this.Load += new System.EventHandler(this.OptionsForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonResetToken;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDataDirectory;
        private System.Windows.Forms.Label labelDataDirectory;
        private System.Windows.Forms.CheckBox checkBoxAllowOffline;
    }
}
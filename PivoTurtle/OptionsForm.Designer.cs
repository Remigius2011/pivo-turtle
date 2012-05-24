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
            this.checkBoxEnforceMessage = new System.Windows.Forms.CheckBox();
            this.checkBoxEnforceStory = new System.Windows.Forms.CheckBox();
            this.checkBoxProhibitModify = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(326, 227);
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
            this.buttonCancel.Location = new System.Drawing.Point(245, 227);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonResetToken
            // 
            this.buttonResetToken.Location = new System.Drawing.Point(12, 227);
            this.buttonResetToken.Name = "buttonResetToken";
            this.buttonResetToken.Size = new System.Drawing.Size(139, 23);
            this.buttonResetToken.TabIndex = 0;
            this.buttonResetToken.Text = "Reset Server Token";
            this.buttonResetToken.UseVisualStyleBackColor = true;
            this.buttonResetToken.Click += new System.EventHandler(this.buttonResetToken_Click);
            // 
            // checkBoxEnforceMessage
            // 
            this.checkBoxEnforceMessage.AutoSize = true;
            this.checkBoxEnforceMessage.Location = new System.Drawing.Point(12, 12);
            this.checkBoxEnforceMessage.Name = "checkBoxEnforceMessage";
            this.checkBoxEnforceMessage.Size = new System.Drawing.Size(144, 17);
            this.checkBoxEnforceMessage.TabIndex = 3;
            this.checkBoxEnforceMessage.Text = "Enforce original message";
            this.checkBoxEnforceMessage.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnforceStory
            // 
            this.checkBoxEnforceStory.AutoSize = true;
            this.checkBoxEnforceStory.Location = new System.Drawing.Point(208, 12);
            this.checkBoxEnforceStory.Name = "checkBoxEnforceStory";
            this.checkBoxEnforceStory.Size = new System.Drawing.Size(133, 17);
            this.checkBoxEnforceStory.TabIndex = 4;
            this.checkBoxEnforceStory.Text = "Enforce story selection";
            this.checkBoxEnforceStory.UseVisualStyleBackColor = true;
            // 
            // checkBoxProhibitModify
            // 
            this.checkBoxProhibitModify.AutoSize = true;
            this.checkBoxProhibitModify.Location = new System.Drawing.Point(12, 35);
            this.checkBoxProhibitModify.Name = "checkBoxProhibitModify";
            this.checkBoxProhibitModify.Size = new System.Drawing.Size(153, 17);
            this.checkBoxProhibitModify.TabIndex = 5;
            this.checkBoxProhibitModify.Text = "Prohibit modified messages";
            this.checkBoxProhibitModify.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(413, 262);
            this.Controls.Add(this.checkBoxProhibitModify);
            this.Controls.Add(this.checkBoxEnforceStory);
            this.Controls.Add(this.checkBoxEnforceMessage);
            this.Controls.Add(this.buttonResetToken);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PivoTurtle Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonResetToken;
        private System.Windows.Forms.CheckBox checkBoxEnforceMessage;
        private System.Windows.Forms.CheckBox checkBoxEnforceStory;
        private System.Windows.Forms.CheckBox checkBoxProhibitModify;
    }
}
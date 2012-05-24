namespace PivoTurtle
{
    partial class ErrorForm
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.labelStackTrace = new System.Windows.Forms.Label();
            this.textBoxStackTrace = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(301, 285);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 15);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(75, 13);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Error Message";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.HideSelection = false;
            this.textBoxMessage.Location = new System.Drawing.Point(116, 12);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.Size = new System.Drawing.Size(260, 54);
            this.textBoxMessage.TabIndex = 1;
            // 
            // labelStackTrace
            // 
            this.labelStackTrace.AutoSize = true;
            this.labelStackTrace.Location = new System.Drawing.Point(12, 88);
            this.labelStackTrace.Name = "labelStackTrace";
            this.labelStackTrace.Size = new System.Drawing.Size(66, 13);
            this.labelStackTrace.TabIndex = 2;
            this.labelStackTrace.Text = "Stack Trace";
            // 
            // textBoxStackTrace
            // 
            this.textBoxStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStackTrace.HideSelection = false;
            this.textBoxStackTrace.Location = new System.Drawing.Point(15, 104);
            this.textBoxStackTrace.Multiline = true;
            this.textBoxStackTrace.Name = "textBoxStackTrace";
            this.textBoxStackTrace.ReadOnly = true;
            this.textBoxStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxStackTrace.Size = new System.Drawing.Size(361, 175);
            this.textBoxStackTrace.TabIndex = 3;
            this.textBoxStackTrace.WordWrap = false;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(15, 285);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.buttonCopy.TabIndex = 4;
            this.buttonCopy.Text = "to Clipboard";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // ErrorForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 320);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.textBoxStackTrace);
            this.Controls.Add(this.labelStackTrace);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxMessage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label labelStackTrace;
        private System.Windows.Forms.TextBox textBoxStackTrace;
        private System.Windows.Forms.Button buttonCopy;
    }
}
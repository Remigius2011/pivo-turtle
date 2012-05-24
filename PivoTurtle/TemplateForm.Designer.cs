namespace PivoTurtle
{
    partial class TemplateForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateForm));
            this.labelTemplate = new System.Windows.Forms.Label();
            this.labelPreview = new System.Windows.Forms.Label();
            this.textBoxTemplate = new System.Windows.Forms.TextBox();
            this.textBoxPreview = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.imageListOkFail = new System.Windows.Forms.ImageList(this.components);
            this.labelOkFail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTemplate
            // 
            this.labelTemplate.AutoSize = true;
            this.labelTemplate.Location = new System.Drawing.Point(12, 15);
            this.labelTemplate.Name = "labelTemplate";
            this.labelTemplate.Size = new System.Drawing.Size(51, 13);
            this.labelTemplate.TabIndex = 0;
            this.labelTemplate.Text = "Template";
            // 
            // labelPreview
            // 
            this.labelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPreview.AutoSize = true;
            this.labelPreview.Location = new System.Drawing.Point(12, 121);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(45, 13);
            this.labelPreview.TabIndex = 3;
            this.labelPreview.Text = "Preview";
            // 
            // textBoxTemplate
            // 
            this.textBoxTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTemplate.Location = new System.Drawing.Point(93, 12);
            this.textBoxTemplate.Multiline = true;
            this.textBoxTemplate.Name = "textBoxTemplate";
            this.textBoxTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTemplate.Size = new System.Drawing.Size(411, 100);
            this.textBoxTemplate.TabIndex = 1;
            this.textBoxTemplate.WordWrap = false;
            this.textBoxTemplate.TextChanged += new System.EventHandler(this.textBoxTemplate_TextChanged);
            this.textBoxTemplate.Enter += new System.EventHandler(this.textBoxTemplate_Enter);
            this.textBoxTemplate.Leave += new System.EventHandler(this.textBoxTemplate_Leave);
            // 
            // textBoxPreview
            // 
            this.textBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPreview.Location = new System.Drawing.Point(93, 118);
            this.textBoxPreview.Multiline = true;
            this.textBoxPreview.Name = "textBoxPreview";
            this.textBoxPreview.ReadOnly = true;
            this.textBoxPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPreview.Size = new System.Drawing.Size(411, 100);
            this.textBoxPreview.TabIndex = 4;
            this.textBoxPreview.WordWrap = false;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(429, 236);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(338, 236);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // imageListOkFail
            // 
            this.imageListOkFail.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListOkFail.ImageStream")));
            this.imageListOkFail.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListOkFail.Images.SetKeyName(0, "IconOk32.png");
            this.imageListOkFail.Images.SetKeyName(1, "IconFail32.png");
            // 
            // labelOkFail
            // 
            this.labelOkFail.ImageIndex = 0;
            this.labelOkFail.ImageList = this.imageListOkFail;
            this.labelOkFail.Location = new System.Drawing.Point(25, 40);
            this.labelOkFail.Name = "labelOkFail";
            this.labelOkFail.Size = new System.Drawing.Size(32, 32);
            this.labelOkFail.TabIndex = 2;
            // 
            // TemplateForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(516, 271);
            this.Controls.Add(this.labelOkFail);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxPreview);
            this.Controls.Add(this.textBoxTemplate);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.labelTemplate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Template";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTemplate;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.TextBox textBoxTemplate;
        private System.Windows.Forms.TextBox textBoxPreview;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ImageList imageListOkFail;
        private System.Windows.Forms.Label labelOkFail;
    }
}
﻿namespace PivoTurtle
{
    partial class IssuesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssuesForm));
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.listViewStories = new System.Windows.Forms.ListView();
			this.columnHeaderCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageListCheckbox = new System.Windows.Forms.ImageList(this.components);
			this.comboBoxProjects = new System.Windows.Forms.ComboBox();
			this.labelProject = new System.Windows.Forms.Label();
			this.labelStories = new System.Windows.Forms.Label();
			this.linkLabelPivotal = new System.Windows.Forms.LinkLabel();
			this.contextMenuStripStories = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openInPivotalTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttonOptions = new System.Windows.Forms.Button();
			this.labelOriginal = new System.Windows.Forms.Label();
			this.labelResult = new System.Windows.Forms.Label();
			this.textBoxOriginal = new System.Windows.Forms.TextBox();
			this.textBoxResult = new System.Windows.Forms.TextBox();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.buttonTemplate = new System.Windows.Forms.Button();
			this.timerStateUpdate = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioDeliver1 = new System.Windows.Forms.RadioButton();
			this.radioFixed1 = new System.Windows.Forms.RadioButton();
			this.radioChore1 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.contextMenuStripStories.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(543, 477);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 12;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.Location = new System.Drawing.Point(462, 477);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 13;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// listViewStories
			// 
			this.listViewStories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewStories.CheckBoxes = true;
			this.listViewStories.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderCheck,
            this.columnHeaderId,
            this.columnHeaderDescription});
			this.listViewStories.FullRowSelect = true;
			this.listViewStories.Location = new System.Drawing.Point(113, 70);
			this.listViewStories.Name = "listViewStories";
			this.listViewStories.Size = new System.Drawing.Size(505, 170);
			this.listViewStories.SmallImageList = this.imageListCheckbox;
			this.listViewStories.TabIndex = 7;
			this.listViewStories.UseCompatibleStateImageBehavior = false;
			this.listViewStories.View = System.Windows.Forms.View.Details;
			this.listViewStories.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewStories_ColumnClick);
			this.listViewStories.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewStories_ItemChecked);
			this.listViewStories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewStories_MouseClick);
			// 
			// columnHeaderCheck
			// 
			this.columnHeaderCheck.Text = "";
			this.columnHeaderCheck.Width = 27;
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "ID";
			this.columnHeaderId.Width = 80;
			// 
			// columnHeaderDescription
			// 
			this.columnHeaderDescription.Text = "Description";
			this.columnHeaderDescription.Width = 375;
			// 
			// imageListCheckbox
			// 
			this.imageListCheckbox.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCheckbox.ImageStream")));
			this.imageListCheckbox.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListCheckbox.Images.SetKeyName(0, "IconCheckboxUnchecked.png");
			this.imageListCheckbox.Images.SetKeyName(1, "IconCheckboxChecked.png");
			this.imageListCheckbox.Images.SetKeyName(2, "IconCheckboxIndeterminate.png");
			// 
			// comboBoxProjects
			// 
			this.comboBoxProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxProjects.FormattingEnabled = true;
			this.comboBoxProjects.Location = new System.Drawing.Point(113, 12);
			this.comboBoxProjects.Name = "comboBoxProjects";
			this.comboBoxProjects.Size = new System.Drawing.Size(504, 21);
			this.comboBoxProjects.TabIndex = 1;
			this.comboBoxProjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjects_SelectedIndexChanged);
			// 
			// labelProject
			// 
			this.labelProject.AutoSize = true;
			this.labelProject.Location = new System.Drawing.Point(12, 15);
			this.labelProject.Name = "labelProject";
			this.labelProject.Size = new System.Drawing.Size(40, 13);
			this.labelProject.TabIndex = 0;
			this.labelProject.Text = "Project";
			// 
			// labelStories
			// 
			this.labelStories.AutoSize = true;
			this.labelStories.Location = new System.Drawing.Point(12, 70);
			this.labelStories.Name = "labelStories";
			this.labelStories.Size = new System.Drawing.Size(39, 13);
			this.labelStories.TabIndex = 6;
			this.labelStories.Text = "Stories";
			// 
			// linkLabelPivotal
			// 
			this.linkLabelPivotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabelPivotal.AutoSize = true;
			this.linkLabelPivotal.Location = new System.Drawing.Point(12, 482);
			this.linkLabelPivotal.Name = "linkLabelPivotal";
			this.linkLabelPivotal.Size = new System.Drawing.Size(157, 13);
			this.linkLabelPivotal.TabIndex = 8;
			this.linkLabelPivotal.TabStop = true;
			this.linkLabelPivotal.Text = "https://www.pivotaltracker.com";
			this.linkLabelPivotal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPivotal_LinkClicked);
			// 
			// contextMenuStripStories
			// 
			this.contextMenuStripStories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInPivotalTrackerToolStripMenuItem});
			this.contextMenuStripStories.Name = "contextMenuStripStories";
			this.contextMenuStripStories.Size = new System.Drawing.Size(195, 26);
			// 
			// openInPivotalTrackerToolStripMenuItem
			// 
			this.openInPivotalTrackerToolStripMenuItem.Name = "openInPivotalTrackerToolStripMenuItem";
			this.openInPivotalTrackerToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.openInPivotalTrackerToolStripMenuItem.Text = "Open in PivotalTracker";
			this.openInPivotalTrackerToolStripMenuItem.Click += new System.EventHandler(this.openInPivotalTrackerToolStripMenuItem_Click);
			// 
			// buttonOptions
			// 
			this.buttonOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonOptions.Image")));
			this.buttonOptions.Location = new System.Drawing.Point(348, 477);
			this.buttonOptions.Name = "buttonOptions";
			this.buttonOptions.Size = new System.Drawing.Size(23, 23);
			this.buttonOptions.TabIndex = 11;
			this.buttonOptions.UseVisualStyleBackColor = true;
			this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
			// 
			// labelOriginal
			// 
			this.labelOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelOriginal.AutoSize = true;
			this.labelOriginal.Location = new System.Drawing.Point(12, 247);
			this.labelOriginal.Name = "labelOriginal";
			this.labelOriginal.Size = new System.Drawing.Size(71, 13);
			this.labelOriginal.TabIndex = 2;
			this.labelOriginal.Text = "Log Message";
			// 
			// labelResult
			// 
			this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelResult.AutoSize = true;
			this.labelResult.Location = new System.Drawing.Point(12, 378);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(45, 13);
			this.labelResult.TabIndex = 4;
			this.labelResult.Text = "Preview";
			// 
			// textBoxOriginal
			// 
			this.textBoxOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxOriginal.Location = new System.Drawing.Point(113, 244);
			this.textBoxOriginal.Multiline = true;
			this.textBoxOriginal.Name = "textBoxOriginal";
			this.textBoxOriginal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxOriginal.Size = new System.Drawing.Size(504, 127);
			this.textBoxOriginal.TabIndex = 3;
			this.textBoxOriginal.WordWrap = false;
			this.textBoxOriginal.TextChanged += new System.EventHandler(this.textBoxOriginal_TextChanged);
			this.textBoxOriginal.Enter += new System.EventHandler(this.textBoxOriginal_Enter);
			this.textBoxOriginal.Leave += new System.EventHandler(this.textBoxOriginal_Leave);
			// 
			// textBoxResult
			// 
			this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxResult.Location = new System.Drawing.Point(113, 375);
			this.textBoxResult.Multiline = true;
			this.textBoxResult.Name = "textBoxResult";
			this.textBoxResult.ReadOnly = true;
			this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxResult.Size = new System.Drawing.Size(504, 98);
			this.textBoxResult.TabIndex = 5;
			this.textBoxResult.WordWrap = false;
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
			this.buttonRefresh.Location = new System.Drawing.Point(319, 477);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(23, 23);
			this.buttonRefresh.TabIndex = 10;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// buttonTemplate
			// 
			this.buttonTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonTemplate.Image = ((System.Drawing.Image)(resources.GetObject("buttonTemplate.Image")));
			this.buttonTemplate.Location = new System.Drawing.Point(290, 477);
			this.buttonTemplate.Name = "buttonTemplate";
			this.buttonTemplate.Size = new System.Drawing.Size(23, 23);
			this.buttonTemplate.TabIndex = 9;
			this.buttonTemplate.UseVisualStyleBackColor = true;
			this.buttonTemplate.Click += new System.EventHandler(this.buttonTemplate_Click);
			// 
			// timerStateUpdate
			// 
			this.timerStateUpdate.Tick += new System.EventHandler(this.timerStateUpdate_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioDeliver1);
			this.groupBox1.Controls.Add(this.radioFixed1);
			this.groupBox1.Controls.Add(this.radioChore1);
			this.groupBox1.Location = new System.Drawing.Point(113, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(191, 31);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			// 
			// radioDeliver1
			// 
			this.radioDeliver1.AutoSize = true;
			this.radioDeliver1.Location = new System.Drawing.Point(121, 11);
			this.radioDeliver1.Name = "radioDeliver1";
			this.radioDeliver1.Size = new System.Drawing.Size(58, 17);
			this.radioDeliver1.TabIndex = 2;
			this.radioDeliver1.TabStop = true;
			this.radioDeliver1.Tag = "STORY_STATE.ssDelivered";
			this.radioDeliver1.Text = "Deliver";
			this.radioDeliver1.UseVisualStyleBackColor = true;
			this.radioDeliver1.Click += new System.EventHandler(this.Status_Change);
			// 
			// radioFixed1
			// 
			this.radioFixed1.AutoSize = true;
			this.radioFixed1.Location = new System.Drawing.Point(65, 11);
			this.radioFixed1.Name = "radioFixed1";
			this.radioFixed1.Size = new System.Drawing.Size(50, 17);
			this.radioFixed1.TabIndex = 1;
			this.radioFixed1.TabStop = true;
			this.radioFixed1.Tag = "STORY_STATE.ssFixed";
			this.radioFixed1.Text = "Fixed";
			this.radioFixed1.UseVisualStyleBackColor = true;
			this.radioFixed1.Click += new System.EventHandler(this.Status_Change);
			// 
			// radioChore1
			// 
			this.radioChore1.AutoSize = true;
			this.radioChore1.Location = new System.Drawing.Point(6, 11);
			this.radioChore1.Name = "radioChore1";
			this.radioChore1.Size = new System.Drawing.Size(53, 17);
			this.radioChore1.TabIndex = 0;
			this.radioChore1.TabStop = true;
			this.radioChore1.Tag = "STORY_STATE.ssChore";
			this.radioChore1.Text = "Chore";
			this.radioChore1.UseVisualStyleBackColor = true;
			this.radioChore1.Click += new System.EventHandler(this.Status_Change);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "State";
			// 
			// IssuesForm
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(629, 512);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonTemplate);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBoxOriginal);
			this.Controls.Add(this.labelOriginal);
			this.Controls.Add(this.linkLabelPivotal);
			this.Controls.Add(this.labelProject);
			this.Controls.Add(this.comboBoxProjects);
			this.Controls.Add(this.textBoxResult);
			this.Controls.Add(this.buttonOptions);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.listViewStories);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelStories);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IssuesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pivotal Tracker Issues";
			this.Shown += new System.EventHandler(this.IssuesForm_Shown);
			this.contextMenuStripStories.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ListView listViewStories;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.ColumnHeader columnHeaderCheck;
        private System.Windows.Forms.ComboBox comboBoxProjects;
        private System.Windows.Forms.Label labelProject;
        private System.Windows.Forms.Label labelStories;
        private System.Windows.Forms.LinkLabel linkLabelPivotal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStories;
        private System.Windows.Forms.ToolStripMenuItem openInPivotalTrackerToolStripMenuItem;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.TextBox textBoxOriginal;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonTemplate;
        private System.Windows.Forms.ImageList imageListCheckbox;
        private System.Windows.Forms.Timer timerStateUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioDeliver1;
        private System.Windows.Forms.RadioButton radioFixed1;
        private System.Windows.Forms.RadioButton radioChore1;
		private System.Windows.Forms.Label label1;
    }
}
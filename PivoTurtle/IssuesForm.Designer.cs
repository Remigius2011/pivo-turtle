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
            this.contextMenuStripStories.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(461, 361);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(542, 361);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
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
            this.listViewStories.Location = new System.Drawing.Point(12, 188);
            this.listViewStories.Name = "listViewStories";
            this.listViewStories.Size = new System.Drawing.Size(605, 167);
            this.listViewStories.TabIndex = 3;
            this.listViewStories.UseCompatibleStateImageBehavior = false;
            this.listViewStories.View = System.Windows.Forms.View.Details;
            this.listViewStories.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewStories_ColumnClick);
            this.listViewStories.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewStories_ItemChecked);
            this.listViewStories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewStories_MouseClick);
            // 
            // columnHeaderCheck
            // 
            this.columnHeaderCheck.Text = "";
            this.columnHeaderCheck.Width = 22;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 80;
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 496;
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Location = new System.Drawing.Point(113, 12);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(423, 21);
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
            this.labelStories.Location = new System.Drawing.Point(9, 163);
            this.labelStories.Name = "labelStories";
            this.labelStories.Size = new System.Drawing.Size(39, 13);
            this.labelStories.TabIndex = 2;
            this.labelStories.Text = "Stories";
            // 
            // linkLabelPivotal
            // 
            this.linkLabelPivotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelPivotal.AutoSize = true;
            this.linkLabelPivotal.Location = new System.Drawing.Point(12, 366);
            this.linkLabelPivotal.Name = "linkLabelPivotal";
            this.linkLabelPivotal.Size = new System.Drawing.Size(157, 13);
            this.linkLabelPivotal.TabIndex = 4;
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
            this.buttonOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonOptions.Image")));
            this.buttonOptions.Location = new System.Drawing.Point(594, 11);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(23, 23);
            this.buttonOptions.TabIndex = 7;
            this.buttonOptions.UseVisualStyleBackColor = true;
            this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Location = new System.Drawing.Point(12, 42);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(42, 13);
            this.labelOriginal.TabIndex = 8;
            this.labelOriginal.Text = "Original";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(12, 68);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 9;
            this.labelResult.Text = "Result";
            // 
            // textBoxOriginal
            // 
            this.textBoxOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOriginal.Location = new System.Drawing.Point(113, 39);
            this.textBoxOriginal.Name = "textBoxOriginal";
            this.textBoxOriginal.Size = new System.Drawing.Size(504, 20);
            this.textBoxOriginal.TabIndex = 10;
            this.textBoxOriginal.TextChanged += new System.EventHandler(this.textBoxOriginal_TextChanged);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Location = new System.Drawing.Point(113, 65);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxResult.Size = new System.Drawing.Size(504, 81);
            this.textBoxResult.TabIndex = 11;
            this.textBoxResult.WordWrap = false;
            // 
            // IssuesForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(629, 396);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxOriginal);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.linkLabelPivotal);
            this.Controls.Add(this.labelProject);
            this.Controls.Add(this.labelStories);
            this.Controls.Add(this.buttonOptions);
            this.Controls.Add(this.comboBoxProjects);
            this.Controls.Add(this.listViewStories);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssuesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pivotal Tracker Issues";
            this.Shown += new System.EventHandler(this.IssuesForm_Shown);
            this.contextMenuStripStories.ResumeLayout(false);
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
    }
}
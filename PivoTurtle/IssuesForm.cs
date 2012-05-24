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
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PivoTurtle
{
    public partial class IssuesForm : Form
    {
        private PivotalServiceClient pivotalClient;
        private List<PivotalProject> projects = new List<PivotalProject>();
        private List<PivotalStory> stories = new List<PivotalStory>();
        private long selectedProjectId = -1;
        private string originalMessage;
        private string commitMessage;
        private string selectedStories;
        private StoryMessageTemplate template = new StoryMessageTemplate();
        private bool whileDisplayingStories = false;
        private bool whileDisplayingProjects = false;
        private bool whileChangingAllSelections = false;

        public IssuesForm()
        {
            InitializeComponent();
            pivotalClient = new PivotalServiceClient();
        }

        public List<PivotalProject> Projects
        {
            get { return projects; }
        }

        public List<PivotalStory> Stories
        {
            get { return stories; }
        }

        public long SelectedProjectId
        {
            get { return selectedProjectId; }
            set { if (value != selectedProjectId) projects.Clear(); selectedProjectId = value; }
        }

        public string SelectedStories
        {
            get { return selectedStories; }
            set { selectedStories = value; }
        }

        public string OriginalMessage
        {
            get { return originalMessage; }
            set { originalMessage = value; }
        }

        public string CommitMessage
        {
            get { return commitMessage; }
        }

        public void SetParameters(string parameters)
        {
            try
            {
                SelectedProjectId = long.Parse(parameters);
            }
            catch (Exception x)
            {
                // do nothing
            }
        }

        public List<PivotalStory> GetSelectedStories()
        {
            List<PivotalStory> result = new List<PivotalStory>();
            foreach (PivotalStory story in stories)
            {
                if (IsSelected(story.Id))
                {
                    result.Add(story);
                }
            }
            return result;
        }

        public bool IsSelected(long storyId)
        {
            string checkSelection = "," + selectedStories + ",";
            return checkSelection.Contains("," + storyId + ",");
        }

        private void SignOn()
        {
            if (!pivotalClient.IsSignedOn())
            {
                string userId = "";
                string password = "";
                if (SignOnForm.SignOn(ref userId, ref password))
                {
                    PivotalToken token = pivotalClient.SignOn(userId, password);
                    if (Properties.Settings.Default.SaveServerToken)
                    {
                        Properties.Settings.Default.TokenGuid = token.Guid;
                        Properties.Settings.Default.TokenId = token.Id;
                    }
                }
            }
        }

        private void LoadPivotalData()
        {
            LoadPivotalProjects();
            if (selectedProjectId >= 0)
            {
                LoadPivotalStories(selectedProjectId);
            }
        }

        private void LoadPivotalProjects()
        {
            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SignOn();
                projects = pivotalClient.GetProjects();
            }
            finally
            {
                this.Cursor = cursor;
            }
        }

        private void LoadPivotalStories(long projectId)
        {
            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                SignOn();
                stories = pivotalClient.GetStories(projectId.ToString());
            }
            finally
            {
                this.Cursor = cursor;
            }
        }

        private void DisplayPivotalData()
        {
            DisplayPivotalProjects();
            DisplayPivotalStories();
        }

        private void DisplayPivotalProjects()
        {
            whileDisplayingProjects = true;
            try
            {
                PivotalProject selectedProject = null;
                comboBoxProjects.BeginUpdate();
                comboBoxProjects.Items.Clear();
                comboBoxProjects.ValueMember = "Id";
                comboBoxProjects.DisplayMember = "DisplayName";
                foreach (PivotalProject project in projects)
                {
                    comboBoxProjects.Items.Add(project);
                    if (project.Id == selectedProjectId)
                    {
                        selectedProject = project;
                    }
                }
                if (selectedProject != null)
                {
                    comboBoxProjects.SelectedItem = selectedProject;
                }
            }
            finally
            {
                whileDisplayingProjects = false;
                comboBoxProjects.EndUpdate();
            }
        }

        private void DisplayPivotalStories()
        {
            whileDisplayingStories = true;
            try
            {
                listViewStories.BeginUpdate();
                listViewStories.Items.Clear();
                foreach (PivotalStory story in stories)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "";
                    item.SubItems.Add(story.Id.ToString());
                    item.SubItems.Add(story.Name);
                    item.Tag = story;
                    item.Checked = IsSelected(story.Id);

                    listViewStories.Items.Add(item);
                }
            }
            finally
            {
                whileDisplayingStories = false;
                listViewStories.EndUpdate();
            }
        }

        private void UpdateServerToken()
        {
            if (!Properties.Settings.Default.SaveServerToken)
            {
                return;
            }
            string tokenGuid = Properties.Settings.Default.TokenGuid;
            long tokenId = Properties.Settings.Default.TokenId;
            if (tokenId >= 0 && tokenGuid.Length > 0)
            {
                PivotalToken token = new PivotalToken(tokenGuid, tokenId);
                pivotalClient.Token = token;
            }
            else
            {
                pivotalClient.Token = null;
            }
        }

        private void UpdateTemplate(string newTemplate)
        {
            string previousTemplate = template.Template;
            try
            {
                string templateStr = newTemplate;
                if (templateStr.Length == 0)
                {
                    templateStr = StoryMessageTemplate.defaultTemplate;
                }
                template.Template = templateStr;
                UpdateMessage();
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Parse Message Template");
                template.Template = previousTemplate;
            }
        }

        private void UpdateMessage()
        {
            if (whileDisplayingStories)
            {
                return;
            }
            try
            {
                List<PivotalStory> selectedStoryList = GetSelectedStories();
                string result = template.Evaluate(selectedStoryList, textBoxOriginal.Text);
                textBoxResult.Text = result;
                commitMessage = result;
                buttonOk.Enabled = textBoxOriginal.Text.Length > 0 && selectedStoryList.Count > 0;
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Evaluate Message Template");
            }
        }

        private void UpdateSelectedStories()
        {
            StringBuilder result = new StringBuilder();
            foreach (ListViewItem item in listViewStories.Items)
            {
                if (item == null)
                {
                    // this seems to be a strange artifact during the second or later
                    // construction phase of the form - we don't have to continue in this case
                    return;
                }
                else
                {
                    if (item.Checked)
                    {
                        PivotalStory story = item.Tag as PivotalStory;
                        if (result.Length > 0)
                        {
                            result.Append(',');
                        }
                        result.Append(story.Id);
                    }
                }
            }
            selectedStories = result.ToString();
        }

        private void UpdateSelectAllCheckbox()
        {
            bool allChecked = listViewStories.Items.Count > 0;
            bool allUnchecked = true;
            foreach (ListViewItem item in listViewStories.Items)
            {
                bool check = item.Checked;
                allChecked &= check;
                allUnchecked &= !check;
            }
            columnHeaderCheck.ImageIndex = allUnchecked ? 0 : allChecked ? 1 : 2;
        }

        private void IssuesForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (pivotalClient.Token == null)
                {
                    UpdateServerToken();
                }
                if (string.IsNullOrEmpty(selectedStories) || !selectedStories.Equals(Properties.Settings.Default.SelectedStories))
                {
                    selectedStories = Properties.Settings.Default.SelectedStories;
                }
                if (selectedProjectId != Properties.Settings.Default.SelectedProject)
                {
                    selectedProjectId = Properties.Settings.Default.SelectedProject;
                    projects.Clear();
                    stories.Clear();
                }
                if (projects.Count == 0)
                {
                    LoadPivotalData();
                    if (projects.Count == 0)
                    {
                        throw new ApplicationException("No projects obtained from Pivotal Tracker.\nYou must be assigned to at least one project.");
                    }
                }
                DisplayPivotalData();
                UpdateSelectAllCheckbox();
                UpdateTemplate(Properties.Settings.Default.MessageTemplate);
                textBoxOriginal.Select();
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error Displaying Issues Form - will close");
                Close();
            }
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (whileDisplayingProjects)
                {
                    return;
                }
                PivotalProject project = comboBoxProjects.SelectedItem as PivotalProject;
                LoadPivotalStories(project.Id);
                DisplayPivotalStories();
                UpdateMessage();
                selectedProjectId = project.Id;
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void textBoxOriginal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateMessage();
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void listViewStories_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                if (e.Column != 0)
                {
                    return;
                }
                whileChangingAllSelections = true;
                try
                {
                    bool check = false;
                    foreach (ListViewItem item in listViewStories.Items)
                    {
                        check |= !item.Checked;
                    }
                    foreach (ListViewItem item in listViewStories.Items)
                    {
                        item.Checked = check;
                    }
                }
                finally
                {
                    whileChangingAllSelections = false;
                }
                UpdateSelectAllCheckbox();
                UpdateSelectedStories();
                UpdateMessage();
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void listViewStories_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (whileDisplayingStories || whileChangingAllSelections)
                {
                    return;
                }
                UpdateSelectAllCheckbox();
                UpdateSelectedStories();
                UpdateMessage();
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void listViewStories_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    ListViewHitTestInfo hitTestInfo = listViewStories.HitTest(e.X, e.Y);
                    if (hitTestInfo.Item != null)
                    {
                        contextMenuStripStories.Items[0].Tag = hitTestInfo.Item.Tag;
                        Point point = listViewStories.PointToScreen(e.Location);
                        contextMenuStripStories.Show(point);
                    }
                }
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void openInPivotalTrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PivotalStory story = (sender as ToolStripItem).Tag as PivotalStory;
                System.Diagnostics.Process.Start(story.Url);
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void linkLabelPivotal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string link = "https://www.pivotaltracker.com";
                if (selectedProjectId >= 0)
                {
                    link += "/projects/" + selectedProjectId;
                }
                System.Diagnostics.Process.Start(link);
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void buttonTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                string editTemplate = template.Template;
                List<PivotalStory> selectedStoryList = GetSelectedStories();
                if (TemplateForm.EditTemplate(ref editTemplate, selectedStoryList, textBoxOriginal.Text))
                {
                    UpdateTemplate(editTemplate);
                    Properties.Settings.Default.MessageTemplate = editTemplate;
                }
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadPivotalData();
                DisplayPivotalData();
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            try
            {
                OptionsForm.ShowOptions();
                UpdateServerToken();
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "An Error Occurred");
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SelectedStories = selectedStories;
            Properties.Settings.Default.SelectedProject = selectedProjectId;
        }

        private void textBoxOriginal_Enter(object sender, EventArgs e)
        {
            AcceptButton = null;
        }

        private void textBoxOriginal_Leave(object sender, EventArgs e)
        {
            AcceptButton = buttonOk;
        }
    }
}

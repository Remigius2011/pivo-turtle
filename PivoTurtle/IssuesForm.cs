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
        private List<PivotalStory> selectedStories = new List<PivotalStory>();
        private string originalMessage;
        private string commitMessage;
        private StoryMessageTemplate template = new StoryMessageTemplate();
        private bool whileDisplayingStories = false;
        private bool whileDisplayingProjects = false;

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
            set { selectedProjectId = value; }
        }

        public List<PivotalStory> SelectedStories
        {
            get { return selectedStories; }
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
                selectedProjectId = long.Parse(parameters);
            }
            catch (System.Exception ex)
            {
                // do nothing
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
                comboBoxProjects.BeginUpdate();
                comboBoxProjects.Items.Clear();
                comboBoxProjects.ValueMember = "Id";
                comboBoxProjects.DisplayMember = "DisplayName";
                foreach (PivotalProject project in projects)
                {
                    comboBoxProjects.Items.Add(project);
                    if (project.Id == selectedProjectId)
                    {
                        comboBoxProjects.SelectedItem = project;
                    }
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

                    foreach (PivotalStory selected in selectedStories)
                    {
                        if (selected.Id == story.Id)
                        {
                            item.Checked = true;
                            break;
                        }
                    }

                    listViewStories.Items.Add(item);
                }
            }
            finally
            {
                whileDisplayingStories = false;
                listViewStories.EndUpdate();
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

        private void LoadPivotalProjects()
        {
            SignOn();
            projects = pivotalClient.GetProjects();
        }

        private void LoadPivotalStories(long projectId)
        {
            SignOn();
            stories = pivotalClient.GetStories(projectId.ToString());
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
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

        private void IssuesForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.SaveServerToken)
                {
                    UpdateServerToken();
                }
                if (projects.Count == 0)
                {
                    LoadPivotalData();
                }
                DisplayPivotalData();
                whileDisplayingStories = true;
                string selectedIds = Properties.Settings.Default.SelectedStories;
                if (selectedIds.Length > 0)
                {
                    foreach (ListViewItem item in listViewStories.Items)
                    {
                        PivotalStory story = item.Tag as PivotalStory;
                        if (story != null)
                        {
                            item.Checked = selectedIds.Contains("," + story.Id + ",");
                        }
                    }
                }
                whileDisplayingStories = false;
                UpdateTemplate();
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error Displaying Issues Form - will close");
                Close();
            }
        }

        private void linkLabelPivotal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = "https://www.pivotaltracker.com";
            if (selectedProjectId >= 0)
            {
                link += "/projects/" + selectedProjectId;
            }
            System.Diagnostics.Process.Start(link);
        }

        private void openInPivotalTrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PivotalStory story = (sender as ToolStripItem).Tag as PivotalStory;
            System.Diagnostics.Process.Start(story.Url);
        }

        private void listViewStories_MouseClick(object sender, MouseEventArgs e)
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

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            OptionsForm.ShowOptions();
            UpdateServerToken();
            if (!Properties.Settings.Default.MessageTemplate.Equals(template.Template))
            {
                UpdateTemplate();
            }
        }

        private void UpdateServerToken()
        {
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

        private void UpdateTemplate()
        {
            try
            {
                string templateStr = Properties.Settings.Default.MessageTemplate;
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
                Properties.Settings.Default.MessageTemplate = "";
                template.Template = StoryMessageTemplate.defaultTemplate;
            }
        }

        private void listViewStories_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
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
        }

        private void UpdateMessage()
        {
            if (whileDisplayingStories)
            {
                return;
            }
            try
            {
                selectedStories.Clear();
                StringBuilder selectedIds = new StringBuilder(",");
                foreach (ListViewItem item in listViewStories.Items)
                {
                    if (item.Checked)
                    {
                        PivotalStory story = item.Tag as PivotalStory;
                        selectedStories.Add(story);
                        selectedIds.Append(story.Id);
                        selectedIds.Append(",");
                    }
                }
                string result = template.Evaluate(selectedStories, textBoxOriginal.Text);
                textBoxResult.Text = result;
                commitMessage = result;
                Properties.Settings.Default.SelectedStories = selectedIds.ToString();
                buttonOk.Enabled = textBoxOriginal.Text.Length > 0 && selectedStories.Count > 0;
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Evaluate Message Template");
            }
        }

        private void textBoxOriginal_TextChanged(object sender, EventArgs e)
        {
            UpdateMessage();
        }

        private void listViewStories_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateMessage();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadPivotalData();
            DisplayPivotalData();
        }
    }
}

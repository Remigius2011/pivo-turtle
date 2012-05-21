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

        public IssuesForm()
        {
            InitializeComponent();
            pivotalClient = new PivotalServiceClient();
            if (Properties.Settings.Default.SaveServerToken)
            {
                UpdateServerToken();
            }
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
            selectedProjectId = long.Parse(parameters);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            selectedStories.Clear();
            StringBuilder result = new StringBuilder();
            StringBuilder selectedIds = new StringBuilder(",");
            foreach (ListViewItem item in listViewStories.Items)
            {
                PivotalStory story = item.Tag as PivotalStory;
                if (story != null && item.Checked)
                {
                    selectedStories.Add(story);
                    result.AppendFormat(story.Url);
                    result.Append(" ");
                    selectedIds.Append(story.Id);
                    selectedIds.Append(",");
                }
            }
            result.Append(originalMessage);

            commitMessage = result.ToString();
            Properties.Settings.Default.SelectedStories = selectedIds.ToString();
        }

        private void DisplayPivotalData()
        {
            DisplayPivotalProjects();
            DisplayPivotalStories();
        }

        private void DisplayPivotalProjects()
        {
            comboBoxProjects.BeginUpdate();
            comboBoxProjects.Items.Clear();
            comboBoxProjects.ValueMember = "Id";
            comboBoxProjects.DisplayMember = "Name";
            foreach (PivotalProject project in projects)
            {
                comboBoxProjects.Items.Add(project);
                if (project.Id == selectedProjectId)
                {
                    comboBoxProjects.SelectedItem = project;
                }
            }
            comboBoxProjects.EndUpdate();
        }

        private void DisplayPivotalStories()
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
                        item.Selected = true;
                        break;
                    }
                }

                listViewStories.Items.Add(item);
            }
            listViewStories.EndUpdate();
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
            PivotalProject project = comboBoxProjects.SelectedItem as PivotalProject;
            LoadPivotalStories(project.Id);
            DisplayPivotalStories();
        }

        private void IssuesForm_Shown(object sender, EventArgs e)
        {
            try
            {
                LoadPivotalData();
                DisplayPivotalData();
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
    }
}

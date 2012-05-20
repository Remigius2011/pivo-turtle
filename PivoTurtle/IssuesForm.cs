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

        private void IssuesForm_Load(object sender, EventArgs e)
        {
            LoadPivotalData();
            DisplayPivotalData();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            selectedStories.Clear();
            foreach (ListViewItem item in listViewStories.Items)
            {
                PivotalStory story = item.Tag as PivotalStory;
                if (story != null && item.Checked)
                {
                    selectedStories.Add(story);
                }
            }
            DialogResult = DialogResult.OK;
            Close();
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
            SignOn();
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
                    pivotalClient.SignOn(userId, password);
                }
            }
        }

        private void LoadPivotalProjects()
        {
            projects = pivotalClient.GetProjects();
        }

        private void LoadPivotalStories(long projectId)
        {
            stories = pivotalClient.GetStories(projectId.ToString());
        }

        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            PivotalProject project = (PivotalProject)comboBoxProjects.SelectedItem;
            LoadPivotalStories(project.Id);
            DisplayPivotalStories();
        }
    }
}

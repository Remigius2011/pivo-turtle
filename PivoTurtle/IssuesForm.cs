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
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace PivoTurtle
{
	public partial class IssuesForm : Form
	{
		public enum STORY_STATE
		{
			ssChore,
			ssFixed,
			ssDelivered
		}

		public class STORY_STATUS
		{
			public long Id { get; set; }
			public STORY_STATE Status { get; set; }

			public STORY_STATUS(long _id, STORY_STATE _state)
			{
				Id = _id;
				Status = _state;
			}
		}

		private ProjectSettings settings;
		private PivotalServiceClient pivotalClient;
		private List<PivotalProject> projects = new List<PivotalProject>();
		private List<PivotalStory> stories = new List<PivotalStory>();
		private long selectedProjectId = 0;
		private string originalMessage;
		private string commitMessage;
		private List<long> selectedStories = new List<long>();
		private STORY_STATE initState = STORY_STATE.ssChore;  
		private StoryMessageTemplate template = new StoryMessageTemplate();

		private bool whileDisplayingStories = false;
		private bool whileDisplayingProjects = false;
		private bool whileChangingAllSelections = false;
		private bool isConnected = true;


		public IssuesForm(ProjectSettings settings)
		{
			this.settings = settings;
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

		public List<long> SelectedStories
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
				SelectedProjectId = Convert.ToInt32(parameters);
			}
			catch
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
					result.Add(story);
			}
			return result;
		}

		// Update 2/1/2014 - LAE  selected stories now at list of longs

		public bool IsSelected(long storyId)
		{
			return selectedStories.Contains(storyId);  
		}

		public STORY_STATE GetStoryStatus(long storyId)
		{
			return STORY_STATE.ssChore;
		}

		private bool SignOn()
		{
			if (!pivotalClient.IsSignedOn())
			{
				string userId = "";
				string password = "";

				if (!SignOnForm.SignOn(ref userId, ref password))
					return false;

				PivotalToken token = pivotalClient.SignOn(userId, password);

				if (token == null)
					return false;

				if (Properties.Settings.Default.SaveServerToken)
				{
					Properties.Settings.Default.TokenGuid = token.Guid;
					Properties.Settings.Default.TokenId = token.Id;

					// Added 1/1/2014 - LAE Persist the settings for quick start next time
					Properties.Settings.Default.Save();   
				}
			}

			return true;
		}

		private bool LoadPivotalData()
		{
			try
			{
				if (LoadPivotalProjects())
				{
					if (selectedProjectId != 0)
					{
						return LoadPivotalStories(selectedProjectId);
					}
				}

				return false;
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "Error retreiving Pivotal data");
			}

			return false;
		}

		private bool LoadPivotalProjects()
		{
			Cursor cursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;

			try
			{
				if (SignOn())
				{
					projects = pivotalClient.GetProjects();
					return (projects != null && projects.Count > 0);
				}

				return false;
			}
			finally
			{
				this.Cursor = cursor;
			}
		}

		private bool LoadPivotalStories(long projectId)
		{
			Cursor cursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;
			try
			{
				if (!SignOn())
					return false;

				stories = pivotalClient.GetStories(projectId.ToString());
				return (stories != null && stories.Count > 0);
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

			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
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
				switch (initState)
				{
					case STORY_STATE.ssFixed:       { radioFixed1.Checked = true; break; }
					case STORY_STATE.ssDelivered:   { radioDeliver1.Checked = true; break; }
					default:                        { radioChore1.Checked = true; break; }
				}

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
				return;

			try
			{
				string tokenGuid = Properties.Settings.Default.TokenGuid;
				long tokenId = Properties.Settings.Default.TokenId;

				if (tokenId >= 0 && tokenGuid.Length > 0)
				{
					PivotalToken token = new PivotalToken();
					token.Guid = tokenGuid;
					token.Id = tokenId;
					pivotalClient.Token = token;
				}
				else
				{
					pivotalClient.Token = null;
				}
			}
			catch
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
					templateStr = StoryMessageTemplate.standardTemplates[0];
				}
				template.Template = templateStr;
				UpdateMessage();
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "Parse Message Template");
				template.Template = previousTemplate;
			}
		}

		private void UpdateMessage()
		{
			if (whileDisplayingStories)
				return;

			try
			{
				List<PivotalStory> selectedStoryList = GetSelectedStories();

				string status = "chore";

				if (this.radioFixed1.Checked)
					status = "fixes";
				else
				if (this.radioDeliver1.Checked)
					status = "deliver";

				string result = template.Evaluate(selectedStoryList, status, textBoxOriginal.Text);

				textBoxResult.Text = result;
				commitMessage = result;
				// Added 1/1/2014 - the user's input will persist between instances of this form showing
				originalMessage = textBoxOriginal.Text; 
				buttonOk.Enabled = textBoxOriginal.Text.Length > 0 && selectedStoryList.Count > 0;
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "Evaluate Message Template");
			}
		}

		//// Updated 2/1/2014 - LAE make a list of selected story id's

		private void UpdateSelectedStories()
		{
			List<long> selected = new List<long>();

			foreach (ListViewItem item in listViewStories.Items)
			{
				if (item.Checked)
				{
					PivotalStory story = item.Tag as PivotalStory;
					selected.Add(story.Id);
				}
			}

			selectedStories = selected;
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

		private void UpdateConnected()
		{
			isConnected = InternetCheck.CheckInternetConnection();
			pivotalClient.IsConnected = isConnected;
			buttonRefresh.Enabled = isConnected;
		}

		private void IssuesForm_Shown(object sender, EventArgs e)
		{
			try
			{
				pivotalClient.AllowOffline = Properties.Settings.Default.AllowOffline;
				pivotalClient.DataDirectory = Properties.Settings.Default.DataDirectory;

				// Added 1/1/2014 - LAE force dialog to be fully drawn before going
				// talking out to internet. Helps avoid partly drawn form.

				Refresh();
 
				UpdateConnected();
				timerStateUpdate.Enabled = true;
				
				if (pivotalClient.Token == null)
					UpdateServerToken();

				// auto-select last project

				if (selectedProjectId != settings.ProjectId)
				{
					selectedProjectId = settings.ProjectId;
					projects.Clear();
					stories.Clear();
				}

				if (projects.Count == 0)
				{
					if (LoadPivotalData() == false)
						MessageBox.Show ("No projects obtained from Pivotal Tracker.\nYou must be assigned to at least one project.");
				}

				// Added 2/1/2013 - LAE get previous selected story indecies

				ExtractPivotalFieldsFromMessage(OriginalMessage);
 
				// show data

				DisplayPivotalData();
				UpdateSelectAllCheckbox();
				UpdateTemplate(Properties.Settings.Default.MessageTemplate);
				textBoxOriginal.Select();
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "Error Displaying Issues Form - will close");
			}
		}

		// Added 2/1/2014 - LAE extract the story id's from the original message

		private void ExtractPivotalFieldsFromMessage(string Msg)
		{
			string bracketPat = @"(?:[\[](?<1>[^\]]*)[\]])";    // search for [#nnnn,#nnnn]
			string srchId = @"(?:[#\s](?<1>\d+))";
			string srchStatus = @"(?<1>\w+)";

			selectedStories.Clear();
			string newStr = Msg;

			// replace \n with \r\n
			newStr = Regex.Replace(newStr, @"\r\n?|\n", Environment.NewLine);

			if (!String.IsNullOrEmpty(Msg))
			{
				try
				{
					//

					foreach (Match substr in Regex.Matches(Msg, bracketPat))
					{
						// remove found ref field from original string

						newStr = Regex.Replace(newStr, bracketPat, "");

						// extract the story IDs

						initState = STORY_STATE.ssChore;
  
						foreach (Match m in Regex.Matches(substr.Groups[1].Value, srchStatus))
						{
							switch (m.Groups[1].Value.ToUpper())
							{
								case "FIXES":
								case "FIXED":
								case "FINISHED":
									initState = STORY_STATE.ssFixed; 
									break;
								case "DELIVER":
								case "DELIVERED":
									initState = STORY_STATE.ssDelivered;  
									break;
							}
						}

						// process the id's found

						foreach (Match Id in Regex.Matches(substr.Groups[1].Value, srchId))
						{
							int id = Convert.ToInt32(Id.Groups[1].Value);

							if (id == 0) 
								continue;

							// add id to list if it doesn't already exist

							if (!IsSelected(id))
								selectedStories.Add(id);
						}

					}

					// see if any story url's can be found in the original message

					foreach (PivotalStory story in stories)
					{
						string pattern = story.Url;
						foreach (Match substr in Regex.Matches(Msg, pattern))
						{
							// remove found ref field from original string
							newStr = Regex.Replace(newStr, pattern, "");

							// add story id to list if doesn't already exist
							if (!IsSelected(story.Id))
								selectedStories.Add(story.Id);
						}
					}
				}
				catch (Exception ex)
				{
					ErrorForm.ShowException(ex, "Error extracting Id fields");
				}
			}

			OriginalMessage = newStr.Trim(); 
			textBoxOriginal.Text = OriginalMessage;
		}


		private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (whileDisplayingProjects)
					return;
				
				PivotalProject project = comboBoxProjects.SelectedItem as PivotalProject;
				LoadPivotalStories(project.Id);
				DisplayPivotalStories();
				UpdateMessage();
				selectedProjectId = project.Id;
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
			}
		}

		private void textBoxOriginal_TextChanged(object sender, EventArgs e)
		{
			try
			{
				UpdateMessage();
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
			}
		}

		private void listViewStories_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			try
			{
				if (e.Column != 0)
					return;

				whileChangingAllSelections = true;

				try
				{
					bool check = false;
					
					foreach (ListViewItem item in listViewStories.Items)
					{
						check |= !item.Checked;
						// Added 1/1/2014 - LAE stop as soon as we find a check item
						if (check) break;
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
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
			}
		}

		private void listViewStories_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			try
			{
				if (whileDisplayingStories || whileChangingAllSelections)
					return;

				UpdateSelectAllCheckbox();
				UpdateSelectedStories();
				UpdateMessage();
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
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
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
			}
		}

		private void openInPivotalTrackerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				PivotalStory story = (sender as ToolStripItem).Tag as PivotalStory;
				System.Diagnostics.Process.Start(story.Url);
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
			}
		}

		private void linkLabelPivotal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				string link = "https://www.pivotaltracker.com";
				if (selectedProjectId != 0)
				{
					link += "/projects/" + selectedProjectId;
				}

				System.Diagnostics.Process.Start(link);
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
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
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
			}
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			try
			{
				LoadPivotalData();
				DisplayPivotalData();
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
			}
		}

		private void buttonOptions_Click(object sender, EventArgs e)
		{
			try
			{
				// Added - 1/1/2014 LAE - Make sure always got a valid settings filename
				// The settings file will hold some per repository attributes settings

				if (String.IsNullOrEmpty(settings.FileName))
					settings.FileName = ProjectSettings.fileName;

				string settingsFile = settings.FileName;

				if (OptionsForm.ShowOptions(settings))
				{
					if (!String.IsNullOrEmpty(settingsFile) && !settingsFile.Equals(settings.FileName))
					{
						File.Move(settingsFile, settings.FileName);
					}

					SettingsFile.SaveXML(settings.FileName, settings);   

					pivotalClient.AllowOffline = Properties.Settings.Default.AllowOffline;
					pivotalClient.DataDirectory = Properties.Settings.Default.DataDirectory;
				}

				UpdateServerToken();
			}
			catch (Exception ex)
			{
				ErrorForm.ShowException(ex, "An Error Occurred");
			}
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			StringBuilder IDs = new StringBuilder();

			foreach (long id in selectedStories)
			{
				if (IDs.Length > 0)
					IDs.Append(",");

				IDs.Append(id.ToString());
			}

			// persist projectid
			settings.ProjectId = selectedProjectId;
		}

		private void textBoxOriginal_Enter(object sender, EventArgs e)
		{
			AcceptButton = null;
		}

		private void textBoxOriginal_Leave(object sender, EventArgs e)
		{
			AcceptButton = buttonOk;
		}

		private void timerStateUpdate_Tick(object sender, EventArgs e)
		{
			UpdateConnected();
		}

		private void Status_Change(object sender, EventArgs e)
		{
			UpdateMessage();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			// persist projectid
			settings.ProjectId = selectedProjectId;
		}
	}

	// Added 1/1/2014 - LAE provide a way of timing functions

	public class HiPerfTimer
	{
		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceCounter(
			out long lpPerformanceCount);

		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceFrequency(
			out long lpFrequency);

		private long startTime, stopTime;
		private long freq;

		public long Frequency { get { return freq; } }

		// Constructor
		public HiPerfTimer()
		{
			startTime = 0;
			stopTime = 0;

			if (QueryPerformanceFrequency(out freq) == false)
			{
				// high-performance counter not supported
				throw new Win32Exception();
			}
		}

		// Start the timer
		public void Start()
		{
			// lets do the waiting threads there work
			Thread.Sleep(0);

			QueryPerformanceCounter(out startTime);
		}

		// Stop the timer
		public void Stop()
		{
			QueryPerformanceCounter(out stopTime);
		}

		// Returns the duration of the timer (in seconds)
		public double Duration
		{
			get
			{
				return (double)(stopTime - startTime) / (double)freq;
			}
		}
	}
}

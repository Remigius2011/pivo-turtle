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
using System.Windows.Forms;

namespace PivoTurtle
{
	public partial class OptionsForm : Form
	{
		private bool allowOffline;
		private string dataDirectory;
		private ProjectSettings settings;

		public bool AllowOffline
		{
			get { return allowOffline; }
			set { allowOffline = value; }
		}

		public string DataDirectory
		{
			get { return dataDirectory; }
			set { dataDirectory = value; }
		}

		public ProjectSettings Settings
		{
			get { return settings; }
			set { settings = value; }
		}

		public static bool ShowOptions(ProjectSettings settings)
		{
			OptionsForm form = new OptionsForm();

			form.AllowOffline = Properties.Settings.Default.AllowOffline;
			form.DataDirectory = Properties.Settings.Default.DataDirectory;
			form.Settings = settings;

			if (form.ShowDialog() == DialogResult.OK)
			{
				Properties.Settings.Default.AllowOffline = form.AllowOffline;
				Properties.Settings.Default.DataDirectory = form.DataDirectory;
				return true;
			}
			return false;
		}

		public OptionsForm()
		{
			InitializeComponent();
		}

		private void OptionsForm_Load(object sender, EventArgs e)
		{
			checkBoxAllowOffline.Checked = allowOffline;
			textBoxDataDirectory.Text = dataDirectory;
		}

		private void buttonResetToken_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.TokenGuid = "";
			Properties.Settings.Default.TokenId = -1;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			allowOffline = checkBoxAllowOffline.Checked;
			dataDirectory = textBoxDataDirectory.Text;

			// Added 1/1/2014 - LAE Persist the property values

			Properties.Settings.Default.Save();
		}
	}
}
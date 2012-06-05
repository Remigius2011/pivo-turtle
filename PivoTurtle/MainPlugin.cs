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
using System.Text;
using Interop.BugTraqProvider;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

// see http://stackoverflow.com/questions/2753631/building-an-issue-tracker-plugin-for-tortoisesvn
// see http://code.google.com/p/tortoisesvn/source/browse/#svn/trunk/contrib/issue-tracker-plugins
// see http://tortoisesvn.net/docs/nightly/TortoiseSVN_en/tsvn-dug-bugtracker.html
// see http://tortoisesvn.net/issuetrackerplugins.html
// see http://www.clean-code-developer.de/Tools.ashx
// see https://www.pivotaltracker.com/help/api?version=v3

// icons
// http://www.iconarchive.com/show/soft-icons-by-kyo-tux/Refresh-icon.html
// http://www.iconarchive.com/show/must-have-icons-by-visualpharm.html

// loader generator
// http://www.jquery4u.com/tools/online-loading-ajax-spinner-generators

namespace PivoTurtle
{
    [ComVisible(true), Guid("4A32C95D-0B66-4280-B370-F71410B521D6"), ClassInterface(ClassInterfaceType.None)]
    public class MainPlugin : IBugTraqProvider, IBugTraqProvider2
    {
        private IssuesForm form;
        private readonly ProjectSettings settings = new ProjectSettings();

        public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
        {
            string bugId = "";
            string[] revPropNames;
            string[] revPropValues;
            return GetCommitMessage2(hParentWnd, parameters, "", commonRoot, pathList, originalMessage, bugId, out bugId, out revPropNames, out revPropValues);
        }

        public string GetLinkText(IntPtr hParentWnd, string parameters)
        {
            return "Choose Pivotal Stories";
        }

        public bool ValidateParameters(IntPtr hParentWnd, string parameters)
        {
            try
            {
                return true;
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error Validating Parameters");
            }
            return false;
        }

        public string CheckCommit(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string commitMessage)
        {
            // return an empty string for OK or an error message to inhibit the commit
            if (form == null || commitMessage == null || !commitMessage.Equals(form.CommitMessage))
            {
                if (MessageBox.Show("The message has been edited outside PivoTurtle\nand therefore might not be compliant to the project guidelines.\n\nDo you want to continue anyway?", "Message modified", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return "Commit aborted after message modification";
                }
            }
            return "";
        }

        public string GetCommitMessage2(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string originalMessage, string bugID, out string bugIDOut, out string[] revPropNames, out string[] revPropValues)
        {
            bugIDOut = bugID;
            revPropNames = new string[0];
            revPropValues = new string[0];
            try
            {
                if (form == null)
                {
                    form = new IssuesForm(settings);
                }
                form.SetParameters(parameters);
                form.OriginalMessage = originalMessage;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.CommitMessage;
                }
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error Getting Commit Message");
            }
            finally
            {
                SaveSettings();
            }
            return originalMessage;
        }

        public bool HasOptions()
        {
            return true;
        }

        public string OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string logMessage, int revision)
        {
            // todo: link back to commit here
            // pathList contains a list of relative paths to the committed objects
            // todo: find a way to access commit hash in case of git
            // o optionally add comment with path list
            // o optionally add comment with commit hash / revision no
            // o optionally finish the issue
            // -> dialog to make sure everything is OK even if PivoTurtle was not invoked for the commit message
            /*
            try
            {

            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error After Commit");
            }
             * */
            return "";
        }

        public string ShowOptionsDialog(IntPtr hParentWnd, string parameters)
        {
            try
            {
                LoadSettings(parameters);
                string settingsFile = settings.FileName;
                if (OptionsForm.ShowOptions(settings))
                {
                    if (!settingsFile.Equals(settings.FileName))
                    {
                        File.Move(settingsFile, settings.FileName);
                    }
                    SaveSettings();
                }
            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error Showing Options Dialog");
            }
            return parameters;
        }

        private string GetSettingsPath(string parameters)
        {
            if (parameters.Length == 0) return ProjectSettings.fileName;
            return Path.Combine(parameters, ProjectSettings.fileName);
        }

        private void LoadSettings(string parameters)
        {
            string fileName = GetSettingsPath(parameters);
            settings.FileName = fileName;
            settings.Load();
        }

        private void SaveSettings()
        {
            settings.Save();
            Properties.Settings.Default.Save();
        }
    }
}

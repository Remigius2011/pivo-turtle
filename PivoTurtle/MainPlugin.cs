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
    public class MainPlugin : IBugTraqProvider //, IBugTraqProvider2
    {
        private IssuesForm form;
        private bool settingsLoaded = false;

        public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
        {
            try
            {
                if (form == null)
                {
                    form = new IssuesForm();
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

        public string GetLinkText(IntPtr hParentWnd, string parameters)
        {
            return "Choose Pivotal Issue";
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
            /*
            try
            {

            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error Checking Commit");
            }
             * */
            return commitMessage;
        }

        public string GetCommitMessage2(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string originalMessage, string bugID, out string bugIDOut, out string[] revPropNames, out string[] revPropValues)
        {
            /*
            try
            {

            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error Getting Commit Message");
            }
             * */
            throw new NotImplementedException();
        }

        public bool HasOptions()
        {
            return true;
        }

        public string OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string logMessage, int revision)
        {
            /*
            try
            {

            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error After Commit");
            }
             * */
            throw new NotImplementedException();
        }

        public string ShowOptionsDialog(IntPtr hParentWnd, string parameters)
        {
            /*
            try
            {

            }
            catch (Exception x)
            {
                ErrorForm.ShowException(x, "Error Showing Options Dialog");
            }
             * */
            throw new NotImplementedException();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}

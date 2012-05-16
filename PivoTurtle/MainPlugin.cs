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

namespace PivoTurtle
{
    [ComVisible(true), Guid("4A32C95D-0B66-4280-B370-F71410B521D6"), ClassInterface(ClassInterfaceType.None)]
    public class MainPlugin : IBugTraqProvider //, IBugTraqProvider2
    {
        public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
        {
            List<TicketItem> tickets = new List<TicketItem>();
            tickets.Add(new TicketItem(12, "Service doesn't start on Windows Vista"));
            tickets.Add(new TicketItem(19, "About box doesn't render correctly in large fonts mode"));

            IssuesForm form = new IssuesForm(tickets);
            if (form.ShowDialog() != DialogResult.OK)
                return originalMessage;

            StringBuilder result = new StringBuilder(originalMessage);
            if (originalMessage.Length != 0 && !originalMessage.EndsWith("\n"))
                result.AppendLine();

            foreach (TicketItem ticket in form.TicketsFixed)
            {
                result.AppendFormat("Fixed #{0}: {1}", ticket.Number, ticket.Summary);
                result.AppendLine();
            }

            return result.ToString();
        }

        public string GetLinkText(IntPtr hParentWnd, string parameters)
        {
            return "Choose Pivotal Issue";
        }

        public bool ValidateParameters(IntPtr hParentWnd, string parameters)
        {
            return true;
        }
        /*
        public string CheckCommit(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string commitMessage)
        {
            throw new NotImplementedException();
        }

        public string GetCommitMessage2(IntPtr hParentWnd, string parameters, string commonURL, string commonRoot, string[] pathList, string originalMessage, string bugID, out string bugIDOut, out string[] revPropNames, out string[] revPropValues)
        {
            throw new NotImplementedException();
        }

        public bool HasOptions()
        {
            throw new NotImplementedException();
        }

        public string OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string logMessage, int revision)
        {
            throw new NotImplementedException();
        }

        public string ShowOptionsDialog(IntPtr hParentWnd, string parameters)
        {
            throw new NotImplementedException();
        }*/
    }
}

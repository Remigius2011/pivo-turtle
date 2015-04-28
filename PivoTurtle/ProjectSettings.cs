using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PivoTurtle
{
    public class ProjectSettings : SettingsFile
    {
        public const string fileName = ".pivoturtle.xml";

        // make sure you set sensible defaults for these property values

        private string messageTemplate = "";
        private long projectId = 0;

        // exposing above as properties will allow them to persisted to file easily

        public string MessageTemplate { 
            get { return messageTemplate; } 
            set { messageTemplate = value; } 
        }

        public long ProjectId 
        {
            get { return projectId; }
            set { projectId = value; } 
        }

        public ProjectSettings()
        {
        }

        public ProjectSettings(string basePath)
        {
            FileName = Path.Combine(basePath, fileName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PivoTurtle
{
    public class ProjectSettings
    {
        public const string fileName = ".pivoturtle";

        public const string keyMessageTemplate = "messageTemplate";
        public const string keyEnforceMessage = "enforceMessage";
        public const string keyEnforceStory = "enforceStory";

        private Dictionary<string, string> properties = new Dictionary<string, string>();

        public Dictionary<string, string> Properties
        {
            get { return properties; }
        }

        public void Save(string basePath)
        {
            string filePath = basePath + "\\" + fileName;
        }

        public void Load(string basePath)
        {
            string filePath = basePath + "\\" + fileName;
        }
    }
}

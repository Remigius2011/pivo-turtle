using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PivoTurtle
{
    public class ProjectSettings : SettingsFile
    {
        public const string fileName = ".pivoturtle";

        private string messageTemplate;
        private bool enforceMessage;
        private bool enforceStory;

        public ProjectSettings()
        {
        }

        public ProjectSettings(string basePath)
        {
            FileName = Path.Combine(basePath, fileName);
        }
    }
}

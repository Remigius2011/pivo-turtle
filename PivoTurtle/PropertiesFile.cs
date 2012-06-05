using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PivoTurtle
{
    public class PropertiesFile : Dictionary<string, string>
    {
        public const string equals = "=";

        private string eol = "\r\n";
        private string comment = "#";

        public string Eol
        {
            get { return eol; }
            set { eol = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public PropertiesFile()
        {
        }

        public PropertiesFile(string filePath)
        {
            Read(filePath);
        }

        public void Write(string filePath)
        {
            string contents = "";
            foreach (KeyValuePair<string, string> entry in this)
            {
                contents += entry.Key + equals + entry.Value.ToString() + eol;
            }
            File.WriteAllText(filePath, contents);
        }

        public void Read(string filePath)
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                // read lines that contain a '=' sign and skip comment lines starting with a '#'
                if ((!string.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(comment)) &&
                    (line.Contains(eol)))
                {
                    int index = line.IndexOf(equals);
                    string key = line.Substring(0, index).Trim();
                    string value = line.Substring(index + 1).Trim();
                    Add(key, value);
                }
            }
        }
    }
}

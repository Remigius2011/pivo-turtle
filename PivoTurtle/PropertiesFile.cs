using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
  
namespace PivoTurtle
{
    public class PropertiesFile : Dictionary<string, string>
    {
        public const string equals = "=";

        private string eol = Environment.NewLine;
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
            MessageBox.Show("reading: " + filePath);
            Read(filePath);
        }

        public void Write(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
                return;

            string contents = "";
            foreach (KeyValuePair<string, string> entry in this)
            {
                contents += entry.Key + equals + entry.Value.ToString() + eol;
            }

            // Added 1/1/2014 - LAE write file if something to write else
            // remove the empty file

            try
            {
                if (!String.IsNullOrEmpty(contents))
                {
                    File.WriteAllText(filePath, contents);
                }
                else
                    File.Delete(filePath);
            }
            catch (Exception ex)
            {
                ErrorForm.ShowException(ex, "An Error Occurred");
            }
        }

        public void Read(string filePath)
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                // read lines that contain a '=' sign and skip comment lines starting with a '#'
                // UPDATED 2/1/2014 - removed the test for eol as the the above splits the lines anyway
                if ((!string.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(comment)))
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace PivoTurtle
{
    public class SettingsFile
    {
        public const string universalParser = "Parse";

        private bool loaded = false;
        private string fileName;
        private PropertiesFile properties = new PropertiesFile();

        public bool Loaded
        {
            get { return loaded; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public Dictionary<string, string> Properties
        {
            get { return properties; }
        }

        public SettingsFile()
        {
        }

        public SettingsFile(string fileName)
        {
            this.fileName = fileName;
        }

        public void Save()
        {
            ToDictionary(properties);
            properties.Write(fileName);
        }

        public void Load()
        {
            properties.Clear();
            properties.Read(fileName);
            FromDictionary(properties);
            loaded = true;
        }

        public void FromDictionary(Dictionary<string, string> dictionary)
        {
            PropertyInfo[] boundProperties = GetType().GetProperties();
            foreach (PropertyInfo property in boundProperties)
            {
                if (IsSettingsProperty(property) && dictionary.ContainsKey(property.Name))
                {
                    object value = ConvertValue(property.PropertyType, dictionary[property.Name]);
                    property.SetValue(this, value, null);
                }
            }
        }

        public void ToDictionary(Dictionary<string, string> dictionary)
        {
            PropertyInfo[] boundProperties = GetType().GetProperties();
            foreach (PropertyInfo property in boundProperties)
            {
                if (IsSettingsProperty(property))
                {
                    dictionary[property.Name] = property.GetValue(this, null).ToString();
                }
            }
        }

        public static bool IsSettingsProperty(PropertyInfo property)
        {
            return !property.DeclaringType.Equals(typeof(SettingsFile))
                && property.GetIndexParameters().Length == 0
                && (property.PropertyType.Equals(typeof(string)) || GetParserMethod(property.PropertyType) != null);
        }

        private static MethodInfo GetParserMethod(Type type)
        {
            try
            {
                MethodInfo parserMethod = type.GetMethod(universalParser, new Type[] { typeof(object) });
                if (parserMethod.IsStatic) return parserMethod;
            }
            catch (Exception x)
            {
                // do nothing
            }
            return null;
        }

        public static object ConvertValue(Type type, string value)
        {
            if (type.Equals(typeof(string)))
            {
                return value;
            }
            MethodInfo parserMethod = GetParserMethod(type);
            if (parserMethod == null) return null;
            return parserMethod.Invoke(null, new object[] { value });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
 
namespace PivoTurtle
{
    public class SettingsFile
    {
        public const string universalParser = "Parse";

        private bool loaded = false;
        private string fileName;

        [XmlIgnore]
        public bool Loaded
        {
            get { return loaded; }
            set { loaded = value; }
        }

        [XmlIgnore] 
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public SettingsFile()
        {
        }

        public SettingsFile(string fileName)
        {
            this.fileName = fileName;
        }

        public static void SaveXML(string fileName, object obj)
        {
            using (var writer = new System.IO.StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(writer, obj);
                writer.Flush();
            }
        }

        public static object LoadXML(string fileName, Type objClass)
        {
            using (var stream = System.IO.File.OpenRead(fileName))
            {
                var serializer = new XmlSerializer(objClass);
                return serializer.Deserialize(stream);
            }
        }

        public static bool IsSettingsProperty(PropertyInfo property)
        {
            return !property.DeclaringType.Equals(typeof(SettingsFile))
                && property.GetIndexParameters().Length == 0;
        }

        private static MethodInfo GetParserMethod(Type type)
        {
            try
            {
                MethodInfo parserMethod = type.GetMethod(universalParser, new Type[] { typeof(object) });
                if (parserMethod.IsStatic) return parserMethod;
            }
            catch
            {
                // do nothing
            }
            return null;
        }

        public static object ConvertValue(Type type, string value)
        {
            MethodInfo parserMethod = GetParserMethod(type);

            if (parserMethod == null)            
            {
                return value;
            }

            return parserMethod.Invoke(null, new object[] { value });
        }

 /*
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

        */
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PivoTurtle
{
    public class XmlHelper
    {
        static string getElementString(XmlElement parent, string name)
        {
            XmlNodeList nodes = parent.GetElementsByTagName(name);
            if(nodes.Count < 1) return null;
            return nodes.Item(0).InnerText;
        }

        static int? getElementInt(XmlElement parent, string name)
        {
            string value = getElementString(parent, name);
            if (value == null) return null;
            return int.Parse(value);
        }

        static long? getElementLong(XmlElement parent, string name)
        {
            string value = getElementString(parent, name);
            if (value == null) return null;
            return long.Parse(value);
        }
    }
}

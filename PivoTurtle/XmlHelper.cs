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

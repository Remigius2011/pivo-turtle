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
    /*
<token>
  <guid>c811ad969733b4227a32a39775e310be</guid>
  <id type="integer">103379</id>
</token>
    */
    public class PivotalToken
    {
        private readonly string guid;
        private readonly long id;

        public PivotalToken(string guid, long id)
        {
            this.guid = guid;
            this.id = id;
        }

        public string Guid
        {
            get { return guid; }
        }

        public long Id
        {
            get { return id; }
        }

        public static PivotalToken fromXml(XmlElement element)
        {
            string guid = element.GetElementsByTagName("guid").Item(0).InnerText;
            string idStr = element.GetElementsByTagName("id").Item(0).InnerText;
            long id = long.Parse(idStr);
            return new PivotalToken(guid, id);
        }
    }
}

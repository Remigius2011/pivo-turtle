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
<task>
  <id type="integer">7342401</id>
  <description>test</description>
  <position type="integer">1</position>
  <complete type="boolean">false</complete>
  <created_at type="datetime">2012/05/17 00:37:32 CEST</created_at>
</task>
     */
    public class PivotalTask
    {
        public const string dateTimeFormat = "yyyy/MM/dd HH:mm:ss";

        public const string tagId = "id";
        public const string tagDescription = "description";
        public const string tagPosition = "position";
        public const string tagComplete = "complete";
        public const string tagCreatedAt = "created_at";

        private long id;
        private string description;
        private int position;
        private bool complete;
        private DateTime createdAt;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool Complete
        {
            get { return complete; }
            set { complete = value; }
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        public static PivotalTask fromXml(XmlElement element)
        {
            PivotalTask task = new PivotalTask();
            task.Id = XmlHelper.getElementLong(element, tagId, -1);
            task.Description = XmlHelper.getElementString(element, tagDescription, "");
            task.Position = XmlHelper.getElementInt(element, tagPosition, -1);
            task.Complete = XmlHelper.getElementBool(element, tagComplete, false);
            task.CreatedAt = XmlHelper.getElementDateTime(element, tagCreatedAt, dateTimeFormat, new DateTime(0));
            return task;
        }
    }
}

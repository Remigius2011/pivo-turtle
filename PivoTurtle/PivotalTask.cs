﻿using System;
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
        private long id;
        private string description;
        private int position;
        private bool completed;
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

        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        public static PivotalTask fromXml(XmlElement element)
        {
            string idStr = element.GetElementsByTagName("id").Item(0).InnerText;
            long id = long.Parse(idStr);
            string description = element.GetElementsByTagName("description").Item(0).InnerText;
            string url = element.GetElementsByTagName("url").Item(0).InnerText;
            PivotalTask story = new PivotalTask();
            story.Id = id;
            story.Description = description;
            return story;
        }
    }
}

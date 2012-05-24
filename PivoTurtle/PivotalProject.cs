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
<projects type="array">
  <project>
    <id>114885</id>
    <name>Crawlers</name>
    <iteration_length type="integer">1</iteration_length>
    <week_start_day>Monday</week_start_day>
    <point_scale>0,1,2,3</point_scale>
    <account>Remigius Stalder</account>
    <first_iteration_start_time type="datetime">2012/05/14 00:00:00 CEST</first_iteration_start_time>
    <current_iteration_number type="integer">1</current_iteration_number>
    <enable_tasks type="boolean">true</enable_tasks>
    <velocity_scheme>Average of 3 iterations</velocity_scheme>
    <current_velocity>10</current_velocity>
    <initial_velocity>10</initial_velocity>
    <number_of_done_iterations_to_show>12</number_of_done_iterations_to_show>
    <labels/>
    <last_activity_at type="datetime">2010/10/12 15:00:02 CEST</last_activity_at>
    <allow_attachments>true</allow_attachments>
    <public>false</public>
    <use_https>false</use_https>
    <bugs_and_chores_are_estimatable>false</bugs_and_chores_are_estimatable>
    <commit_mode>false</commit_mode>
    <memberships type="array">
      <membership>
        <id>367719</id>
        <person>
          <email>remigius.stalder@descom-consulting.ch</email>
          <name>Remigius Stalder</name>
          <initials>RS</initials>
        </person>
        <role>Owner</role>
      </membership>
    </memberships>
    <integrations type="array">
    </integrations>
  </project>
</projects>
       */
    public class PivotalProject
    {
        private long id;
        private string name;
        private int iterationLength;
        private string weekStartDay;

        public string DisplayName
        {
            get { return name + " (" + id + ")"; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int IterationLength
        {
            get { return iterationLength; }
            set { iterationLength = value; }
        }

        public string WeekStartDay
        {
            get { return weekStartDay; }
            set { weekStartDay = value; }
        }

        public static PivotalProject fromXml(XmlElement element)
        {
            string idStr = element.GetElementsByTagName("id").Item(0).InnerText;
            long id = long.Parse(idStr);
            string name = element.GetElementsByTagName("name").Item(0).InnerText;
            PivotalProject project = new PivotalProject();
            project.Id = id;
            project.Name = name;
            return project;
        }
    }
}

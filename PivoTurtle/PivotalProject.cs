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
        public const string dateTimePattern = "yyyy/MM/dd hh:mm:ss";

        public const string tagId = "id";
        public const string tagName = "name";
        public const string tagIterationLength = "iteration_length";
        public const string tagWeekStart = "week_start";
        public const string tagPointScale = "point_scale";
        public const string tagAccount = "account";
        public const string tagFirstIterationStartTime = "first_iteration_start_time";
        public const string tagCurrentIterationNumber = "current_iteration_number";
        public const string tagEnableTasks = "enable_tasks";
        public const string tagVelocityScheme = "velocity_scheme";
        public const string tagCurrentVelocity = "current_velocity";
        public const string tagInitialVelocity = "initial_velocity";
        public const string tagNumberOfDoneIterationsToShow = "number_of_done_iterations_to_show";
        public const string tagLabels = "labels";
        public const string tagLastActivityAt = "last_activity_at";
        public const string tagAllowAttachments = "allow_attachments";
        public const string tagUseHttps = "use_https";
        public const string tagBugsAndChoresAreEstimable = "bugs_and_chores_are_estimatable";
        public const string tagCommitMode = "commit_mode";
        public const string tagMemberships = "memberships";
        public const string tagMembership = "membership";
        public const string tagIntegrations = "integrations";
        public const string tagIntegration = "integration";

        public static readonly char[] separators = { ',' };

        private long id;
        private string name;
        private int iterationLength;
        private string weekStart;
        private int[] pointScale;
        private string account;
        private DateTime firstIterationStartTime;
        private int currentIterationNumber;
        private bool enableTasks;
        private string velocityScheme;
        private int currentVelocity;
        private int initialVelocity;
        private int numberOfDoneIterationsToShow;
        private string[] labels;
        private DateTime lastActivityAt;
        private bool allowAttachments;
        private bool useHttps;
        private bool bugsAndChoresAreEstimable;
        private bool commitMode;
//        private List<PivotalMembrship> memberships;
//        private List<PivotalIntegration> integrations;
        
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

        public string WeekStart
        {
            get { return weekStart; }
            set { weekStart = value; }
        }

        public int[] PointScale
        {
            get { return pointScale; }
            set { pointScale = value; }
        }

        public string Account
        {
            get { return account; }
            set { account = value; }
        }

        public DateTime FirstIterationStartTime
        {
            get { return firstIterationStartTime; }
            set { firstIterationStartTime = value; }
        }

        public int CurrentIterationNumber
        {
            get { return currentIterationNumber; }
            set { currentIterationNumber = value; }
        }

        public bool EnableTasks
        {
            get { return enableTasks; }
            set { enableTasks = value; }
        }

        public string VelocityScheme
        {
            get { return velocityScheme; }
            set { velocityScheme = value; }
        }

        public int CurrentVelocity
        {
            get { return currentVelocity; }
            set { currentVelocity = value; }
        }

        public int InitialVelocity
        {
            get { return initialVelocity; }
            set { initialVelocity = value; }
        }

        public int NumberOfDoneIterationsToShow
        {
            get { return numberOfDoneIterationsToShow; }
            set { numberOfDoneIterationsToShow = value; }
        }

        public string[] Labels
        {
            get { return labels; }
            set { labels = value; }
        }

        public DateTime LastActivityAt
        {
            get { return lastActivityAt; }
            set { lastActivityAt = value; }
        }

        public bool AllowAttachments
        {
            get { return allowAttachments; }
            set { allowAttachments = value; }
        }

        public bool UseHttps
        {
            get { return useHttps; }
            set { useHttps = value; }
        }

        public bool BugsAndChoresAreEstimable
        {
            get { return bugsAndChoresAreEstimable; }
            set { bugsAndChoresAreEstimable = value; }
        }

        public bool CommitMode
        {
            get { return commitMode; }
            set { commitMode = value; }
        }

        public static PivotalProject fromXml(XmlElement element)
        {
            PivotalProject project = new PivotalProject();
            project.Id = XmlHelper.getElementLong(element, tagId, -1);
            project.Name = XmlHelper.getElementString(element, tagName, "");
            project.IterationLength = XmlHelper.getElementInt(element, tagIterationLength, -1);
            project.WeekStart = XmlHelper.getElementString(element, tagWeekStart, "");
            project.PointScale = XmlHelper.getElementIntArray(element, tagPointScale, separators, new int[] {});
            project.Account = XmlHelper.getElementString(element, tagAccount, "");
            project.FirstIterationStartTime = XmlHelper.getElementDateTime(element, tagFirstIterationStartTime, dateTimePattern, new DateTime(0));
            project.CurrentIterationNumber = XmlHelper.getElementInt(element, tagCurrentIterationNumber, -1);
            project.EnableTasks = XmlHelper.getElementBool(element, tagEnableTasks, false);
            project.VelocityScheme = XmlHelper.getElementString(element, tagVelocityScheme, "");
            project.CurrentVelocity = XmlHelper.getElementInt(element, tagCurrentVelocity, -1);
            project.InitialVelocity = XmlHelper.getElementInt(element, tagInitialVelocity, -1);
            project.NumberOfDoneIterationsToShow = XmlHelper.getElementInt(element, tagNumberOfDoneIterationsToShow, -1);
            project.Labels = XmlHelper.getElementStringArray(element, tagLabels, separators, new string[] {});
            project.LastActivityAt = XmlHelper.getElementDateTime(element, tagLastActivityAt, dateTimePattern, new DateTime(0));
            project.AllowAttachments = XmlHelper.getElementBool(element, tagAllowAttachments, false);
            project.UseHttps = XmlHelper.getElementBool(element, tagUseHttps, false);
            project.BugsAndChoresAreEstimable = XmlHelper.getElementBool(element, tagBugsAndChoresAreEstimable, false);
            project.CommitMode = XmlHelper.getElementBool(element, tagCommitMode, false);
            return project;
        }
    }
}

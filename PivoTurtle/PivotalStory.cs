using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PivoTurtle
{
    /*
<stories total="3" count="3" filter="mywork:remigius state:started" type="array">
  <story>
    <id type="integer">5165684</id>
    <project_id type="integer">114811</project_id>
    <story_type>chore</story_type>
    <url>https://www.pivotaltracker.com/story/show/5165684</url>
    <current_state>started</current_state>
    <description/>
    <name>Unit Tests vervollständigen</name>
    <requested_by>Remigius Stalder</requested_by>
    <owned_by>Remigius Stalder</owned_by>
    <created_at type="datetime">2010/09/14 17:59:45 CEST</created_at>
    <updated_at type="datetime">2012/05/17 00:37:39 CEST</updated_at>
    <labels>client,service</labels>
    <tasks type="array">
      <task>
        <id type="integer">7342401</id>
        <description>test</description>
        <position type="integer">1</position>
        <complete type="boolean">false</complete>
        <created_at type="datetime">2012/05/17 00:37:32 CEST</created_at>
      </task>
    </tasks>
  </story>
</stories>
    */
    public class PivotalStory
    {
        private long id;
        private long projectId;
        private string storyType;
        private string url;
        private string currentState;
        private string description;
        private string name;
        private string requestedBy;
        private string ownedBy;
        private DateTime createdAt;
        private DateTime updatedAt;
        private string[] labels;
        private List<PivotalTask> tasks = new List<PivotalTask>();

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public long ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        public string StoryType
        {
            get { return storyType; }
            set { storyType = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string RequestedBy
        {
            get { return requestedBy; }
            set { requestedBy = value; }
        }

        public string OwnedBy
        {
            get { return ownedBy; }
            set { ownedBy = value; }
        }

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set { updatedAt = value; }
        }

        public string[] Labels
        {
            get { return labels; }
            set { labels = value; }
        }

        public List<PivotalTask> Tasks
        {
            get { return tasks; }
        }

        public static PivotalStory fromXml(XmlElement element)
        {
            string idStr = element.GetElementsByTagName("id").Item(0).InnerText;
            long id = long.Parse(idStr);
            string name = element.GetElementsByTagName("name").Item(0).InnerText;
            string url = element.GetElementsByTagName("url").Item(0).InnerText;
            PivotalStory story = new PivotalStory();
            story.Id = id;
            story.Name = name;
            story.Url = url;
            return story;
        }
    }
}

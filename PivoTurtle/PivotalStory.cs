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
		public const string dateTimeFormat = "yyyy/MM/dd HH:mm:ss";

		public const string tagStory = "story";
		public const string tagStories = "stories";
		public const string tagId = "id";
		public const string tagProjectId = "project_id";
		public const string tagStoryType = "story_type";
		public const string tagUrl = "url";
		public const string tagCurrentState = "current_state";
		public const string tagDescription = "description";
		public const string tagName = "name";
		public const string tagRequestedBy = "requested_by";
		public const string tagOwnedBy = "owned_by";
		public const string tagCreatedAt = "created_at";
		public const string tagUpdatedAt = "updated_at";
		public const string tagLabels = "labels";

		public static readonly char[] separators = { ',' };

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
			PivotalStory story = new PivotalStory();
			story.Id = XmlHelper.getElementLong(element, tagId, -1);
			story.ProjectId = XmlHelper.getElementLong(element, tagProjectId, -1);
			story.StoryType = XmlHelper.getElementString(element, tagStoryType, "");
			story.Url = XmlHelper.getElementString(element, tagUrl, "");
			story.CurrentState = XmlHelper.getElementString(element, tagCurrentState, "");
			story.Description = XmlHelper.getElementString(element, tagDescription, "");
			story.Name = XmlHelper.getElementString(element, tagName, "");
			story.RequestedBy = XmlHelper.getElementString(element, tagRequestedBy, "");
			story.OwnedBy = XmlHelper.getElementString(element, tagOwnedBy, "");
			story.CreatedAt = XmlHelper.getElementDateTime(element, tagCreatedAt, dateTimeFormat, new DateTime(0));
			story.UpdatedAt = XmlHelper.getElementDateTime(element, tagUpdatedAt, dateTimeFormat, new DateTime(0));
			story.Labels = XmlHelper.getElementStringArray(element, tagLabels, separators, new string[] { });
			XmlNodeList taskList = element.GetElementsByTagName(PivotalTask.tagTasks);
			if (taskList.Count > 0)
			{
				XmlElement tasksElement = (XmlElement)taskList.Item(0);
				XmlNodeList nodeList = tasksElement.GetElementsByTagName(PivotalTask.tagTask);
				foreach (XmlNode node in nodeList)
				{
					XmlElement taskElement = (XmlElement)node;
					PivotalTask task = PivotalTask.fromXml(taskElement);
					story.Tasks.Add(task);
				}
			}
			return story;
		}
	}
}
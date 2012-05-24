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
using System.Net;
using System.IO;
using System.Xml;

namespace PivoTurtle
{
    public class PivotalServiceClient
    {
        private PivotalToken token;
        public PivotalToken Token
        {
            get { return token; }
            set { token = value; }
        }

        public bool IsSignedOn()
        {
            return token != null;
        }

        public PivotalToken SignOn(string userId, string passWord)
        {
            // curl -u remigius:remi1965$ -X GET https://www.pivotaltracker.com/services/v3/tokens/active
            token = null;
            XmlDocument result = executeRequest("https://www.pivotaltracker.com/services/v3/tokens/active", userId, passWord);
            token = PivotalToken.fromXml(result.DocumentElement);
            return token;
        }
        
        public List<PivotalProject> GetProjects()
        {
            // curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects
            XmlDocument result = executeRequest("https://www.pivotaltracker.com/services/v3/projects");
            List<PivotalProject> projects = new List<PivotalProject>();
            XmlNodeList nodeList = result.DocumentElement.GetElementsByTagName("project");
            foreach (XmlNode node in nodeList)
            {
                XmlElement element = (XmlElement)node;
                PivotalProject project = PivotalProject.fromXml(element);
                projects.Add(project);
            }
            return projects;
        }

        public List<PivotalStory> GetStories(string projectId)
        {
            // curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories
            // curl -H "X-TrackerToken: %TOKEN%" -X GET "https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories?filter=mywork:remigius%%20state:started"
            XmlDocument result = executeRequest("https://www.pivotaltracker.com/services/v3/projects/" + projectId + "/stories?filter=state:started");
            List<PivotalStory> stories = new List<PivotalStory>();
            XmlNodeList nodeList = result.DocumentElement.GetElementsByTagName("story");
            foreach (XmlNode node in nodeList)
            {
                XmlElement element = (XmlElement)node;
                PivotalStory story = PivotalStory.fromXml(element);
                stories.Add(story);
            }
            return stories;
        }

        public List<PivotalTask> GetTasks(string projectId, string storyId)
        {
            // curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories/%STORY_ID%/tasks
            XmlDocument result = executeRequest("https://www.pivotaltracker.com/services/v3/projects/" + projectId + "/stories/" + storyId + "/tasks");
            List<PivotalTask> tasks = new List<PivotalTask>();
            XmlNodeList nodeList = result.DocumentElement.GetElementsByTagName("task");
            foreach (XmlNode node in nodeList)
            {
                XmlElement element = (XmlElement)node;
                PivotalTask task = PivotalTask.fromXml(element);
                tasks.Add(task);
            }
            return tasks;
        }

        public XmlDocument executeRequest(string requestUrl)
        {
            return executeRequest(requestUrl, "", "");
        }

        public XmlDocument executeRequest(string requestUrl, string userId, string passWord)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            HttpWebResponse response = null;
            StreamReader reader = null;
            try
            {
                if (userId.Length > 0 && passWord.Length > 0)
                {
                    request.Credentials = new NetworkCredential(userId, passWord);
                }
                if (token != null)
                {
                    request.Headers.Add("X-TrackerToken", token.Guid);
                }
                request.KeepAlive = false;
                response = (HttpWebResponse)request.GetResponse();

                Stream receiveStream = response.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                reader = new StreamReader(receiveStream, encode);
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                return document;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (response != null) { response.Close(); }
            }
        }
    }
}

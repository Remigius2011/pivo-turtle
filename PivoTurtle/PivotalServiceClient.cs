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
            List<PivotalTask> tasks = new List<PivotalTask>();
            return tasks;
        }

        public XmlDocument executeRequest(string requestUrl)
        {
            return executeRequest(requestUrl, "", "");
        }

        public XmlDocument executeRequest(string requestUrl, string userId, string passWord)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            if (userId.Length > 0 && passWord.Length > 0)
            {
                request.Credentials = new NetworkCredential(userId, passWord);
            }
            if (token != null)
            {
                request.Headers.Add("X-TrackerToken", token.Guid);
            }
            request.KeepAlive = false;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                // todo: throw an exception here
                return null;
            }

            Stream receiveStream = response.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, encode);
            XmlDocument document = new XmlDocument();
            document.Load(readStream);

            readStream.Close();
            response.Close();
            return document;
        }
    }
}

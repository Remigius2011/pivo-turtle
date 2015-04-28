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
using System.Windows.Forms;
 
namespace PivoTurtle
{
    public class PivotalServiceClient
    {
        public delegate void ResponseHandler(Stream stream);

        public const string defaultEncoding = "utf-8";
        public const string fileNameProjects = "PivotalProjects";
        public const string fileNameStories = "PivotalStories";
        public const string fileNameTasks = "PivotalTasks";
        public const string fileSuffix = ".xml";

        private PivotalToken token = null;
        private string dataDirectory = "";
        private bool allowOffline = true;
        private bool isConnected = true;

        public PivotalToken Token
        {
            get { return token; }
            set { token = value; }
        }

        public string DataDirectory
        {
            get { return dataDirectory; }
            set { dataDirectory = value; }
        }

        public bool AllowOffline
        {
            get { return allowOffline; }
            set { allowOffline = value; }
        }

        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        public bool IsSignedOn()
        {
            return token != null;
        }

        public PivotalToken SignOn(string userId, string passWord)
        {
            // curl -u remigius:remi1965$ -X GET https://www.pivotaltracker.com/services/v3/tokens/active
            token = null;
            string requestUrl = "https://www.pivotaltracker.com/services/v3/tokens/active";

            ExecuteRequest(requestUrl, null, userId, passWord, 
                delegate(Stream stream)
                {
                    XmlDocument document = XmlHelper.parseStream(stream, defaultEncoding);
                    token = PivotalToken.fromXml(document.DocumentElement);
                }
            );

            return token;
        }
        
        public List<PivotalProject> GetProjects()
        {
            // curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects
            string requestUrl = "https://www.pivotaltracker.com/services/v3/projects";
            List<PivotalProject> projects = null;
            string fileName = fileNameProjects + fileSuffix;
            
            ExecuteRequest(requestUrl, fileName, 
                delegate(Stream stream)
                {
                    ParseProjects(stream, ref projects);
                }
            );

            return projects;
        }

        public List<PivotalStory> GetStories(string projectId)
        {
            // curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories
            // curl -H "X-TrackerToken: %TOKEN%" -X GET "https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories?filter=mywork:remigius%%20state:started"
            string requestUrl = "https://www.pivotaltracker.com/services/v3/projects/" + projectId + "/stories?filter=state:started";
            List<PivotalStory> stories = null;
            string fileName = fileNameStories + "-" + projectId + fileSuffix;
            
            ExecuteRequest(requestUrl, fileName, 
                delegate(Stream stream)
                {
                    ParseStories(stream, ref stories);
                }
            );

            return stories;
        }

        public List<PivotalTask> GetTasks(string projectId, string storyId)
        {
            // curl -H "X-TrackerToken: %TOKEN%" -X GET https://www.pivotaltracker.com/services/v3/projects/%PROJECT_ID%/stories/%STORY_ID%/tasks
            string requestUrl = "https://www.pivotaltracker.com/services/v3/projects/" + projectId + "/stories/" + storyId + "/tasks";
            List<PivotalTask> tasks = null;
            string fileName = fileNameTasks + "-" + projectId + "-" + storyId + fileSuffix;

            ExecuteRequest(requestUrl, fileName, 
                delegate(Stream stream)
                {
                    ParseTasks(stream, ref tasks);
                }
            );

            return tasks;
        }

        public void ParseProjects(Stream stream, ref List<PivotalProject> projects)
        {
            XmlDocument document = XmlHelper.parseStream(stream, defaultEncoding);
            XmlNodeList nodeList = document.DocumentElement.GetElementsByTagName(PivotalProject.tagProject);
            
            projects = new List<PivotalProject>();
            foreach (XmlNode node in nodeList)
            {
                XmlElement element = (XmlElement)node;
                PivotalProject project = PivotalProject.fromXml(element);
                projects.Add(project);
            }
        }

        public void ParseStories(Stream stream, ref List<PivotalStory> stories)
        {
            XmlDocument document = XmlHelper.parseStream(stream, defaultEncoding);
            XmlNodeList nodeList = document.DocumentElement.GetElementsByTagName(PivotalStory.tagStory);

            stories = new List<PivotalStory>();
            foreach (XmlNode node in nodeList)
            {
                XmlElement element = (XmlElement)node;
                PivotalStory story = PivotalStory.fromXml(element);
                stories.Add(story);
            }
        }

        public void ParseTasks(Stream stream, ref List<PivotalTask> tasks)
        {
            XmlDocument document = XmlHelper.parseStream(stream, defaultEncoding);
            XmlNodeList nodeList = document.DocumentElement.GetElementsByTagName(PivotalTask.tagTask);
            
            tasks = new List<PivotalTask>();
            foreach (XmlNode node in nodeList)
            {
                XmlElement element = (XmlElement)node;
                PivotalTask task = PivotalTask.fromXml(element);
                tasks.Add(task);
            }
        }

        public void ExecuteRequest(string requestUrl, string fileName, ResponseHandler handler)
        {
            ExecuteRequest(requestUrl, fileName, "", "", handler);
        }

        public void ExecuteRequest(string requestUrl, string fileName, string userId, string passWord, ResponseHandler handler)
        {
            HttpWebResponse response = null;
            Stream resultStream = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);

                // Added 1/1/2014 - LAE
                // by default WebRequest tries to work out the proxy settings to use from
                // IE settings. This simple thing takes bloody ages. So if you need to use
                // proxying might be better to get the settings from user rather than wait
                // for WebRequest to work them out
                // Anyway the line below will drastically speed up fetching replies from the
                // other end

                request.Proxy = null;

                if (isConnected)
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
                    resultStream = response.GetResponseStream();

                    // offline just means it saves the servers response into a
                    // data file for later perusal. A debugging aid

                    if (allowOffline)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        CopyStream(resultStream, memoryStream);
                        resultStream.Close();
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        // has user specified a directory into which to place the
                        // server responses

                        if (String.IsNullOrEmpty(dataDirectory) || !Directory.Exists(dataDirectory))
                            dataDirectory = Directory.GetCurrentDirectory();

                        if (String.IsNullOrEmpty(fileName))
                            fileName = "dbg_svr.xml";

                        string path = dataDirectory + Path.DirectorySeparatorChar + fileName;
                        FileStream fileOutput = new FileStream(path, FileMode.Create);
                        if (!File.Exists(path))
                        {
                            throw new ApplicationException("Couldn't create file: " + path);
                        }

                        try
                        {
                            CopyStream(memoryStream, fileOutput);
                        }
                        finally
                        {
                            fileOutput.Close();
                        }

                        memoryStream.Seek(0, SeekOrigin.Begin);
                        resultStream = memoryStream;
                    }
                }
                else if (allowOffline)
                {
                    string path = dataDirectory + Path.DirectorySeparatorChar + fileName;
                    resultStream = new FileStream(path, FileMode.Open);
                }
                if (resultStream != null)
                {
                    handler(resultStream);
                }
            }
            finally
            {
                if (response != null) { response.Close(); }
                if (resultStream != null) { resultStream.Close(); }
            }
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[4096];
            int read;

            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
    }
}

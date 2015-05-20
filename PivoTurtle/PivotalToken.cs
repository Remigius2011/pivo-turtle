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
		public const string tagGuid = "guid";
		public const string tagId = "id";

		private string guid;
		private long id;

		public string Guid
		{
			get { return guid; }
			set { guid = value; }
		}

		public long Id
		{
			get { return id; }
			set { id = value; }
		}

		public static PivotalToken fromXml(XmlElement element)
		{
			PivotalToken token = new PivotalToken();
			token.Guid = XmlHelper.getElementString(element, tagGuid, "");
			token.Id = XmlHelper.getElementLong(element, tagId, -1);
			return token;
		}
	}
}
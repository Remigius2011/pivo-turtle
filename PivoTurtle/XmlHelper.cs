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
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace PivoTurtle
{
	public class XmlHelper
	{
		public static XmlDocument parseStream(Stream stream, string encoding)
		{
			StreamReader reader = null;
			try
			{
				Encoding encode = System.Text.Encoding.GetEncoding(encoding);

				// Pipes the stream to a higher level stream reader with the required encoding format.
				reader = new StreamReader(stream, encode);
				XmlDocument document = new XmlDocument();
				document.Load(reader);
				return document;
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}
			}
		}

		public static string getElementString(XmlElement parent, string name, string defaultValue)
		{
			XmlNodeList nodes = parent.GetElementsByTagName(name);
			if (nodes.Count < 1)
			{
				return defaultValue;
			}
			return nodes.Item(0).InnerText;
		}

		public static bool getElementBool(XmlElement parent, string name, bool defaultValue)
		{
			string value = getElementString(parent, name, null);
			try
			{
				if (value != null)
				{
					return bool.Parse(value);
				}
			}
			catch
			{
				// do nothing
			}
			return defaultValue;
		}

		public static int getElementInt(XmlElement parent, string name, int defaultValue)
		{
			string value = getElementString(parent, name, null);
			try
			{
				if (value != null)
				{
					return int.Parse(value);
				}
			}
			catch
			{
				// do nothing
			}
			return defaultValue;
		}

		public static long getElementLong(XmlElement parent, string name, long defaultValue)
		{
			string value = getElementString(parent, name, null);
			try
			{
				if (value != null)
				{
					return long.Parse(value);
				}
			}
			catch
			{
				// do nothing
			}
			return defaultValue;
		}

		public static string[] getElementStringArray(XmlElement parent, string name, char[] separators, string[] defaultValue)
		{
			string value = getElementString(parent, name, null);
			try
			{
				if (value != null)
				{
					return value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
				}
			}
			catch
			{
				// do nothing
			}
			return defaultValue;
		}

		public static int[] getElementIntArray(XmlElement parent, string name, char[] separators, int[] defaultValue)
		{
			string[] values = getElementStringArray(parent, name, separators, null);
			try
			{
				if (values != null)
				{
					int[] result = new int[values.Length];
					for (int i = 0; i < result.Length; i++)
					{
						result[i] = int.Parse(values[i]);
					}
					return result;
				}
			}
			catch
			{
				// do nothing
			}
			return defaultValue;
		}

		public static DateTime getElementDateTime(XmlElement parent, string name, string format, DateTime defaultValue)
		{
			string value = getElementString(parent, name, null);
			try
			{
				if (value != null)
				{
					return ParsePivotalDateTime(value, format);
				}
			}
			catch
			{
				// do nothing
			}
			return defaultValue;
		}

		public static DateTime ParsePivotalDateTime(string value, string format)
		{
			if (value.Length > 19)
			{
				value = value.Substring(0, 19);
			}
			CultureInfo enUS = new CultureInfo("en-US");
			return DateTime.ParseExact(value, format, enUS, DateTimeStyles.AssumeLocal);
		}
	}
}
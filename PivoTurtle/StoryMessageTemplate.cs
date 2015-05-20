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

namespace PivoTurtle
{
	public class StoryMessageTemplate
	{
		public static readonly string[] standardTemplates = {
                                                      "[[%state% {#%id%,}]][ %original% ]",
                                                      //@"%original%\r\n\r\n{%name%, }",
                                                      //@"%original%\r\n\r\n[[ %state% {#%id% - %name%, }]]",
                                                      //@"%original%\r\n\r\n{%name%\r\n}",
                                                      //@"%original%\r\n\r\n[[ %state% {#%id% - %name%\r\n}]]",
                                                      @"%original%\r\n\r\n{%url%\r\n}",
                                                      //@"%original%\r\n\r\n{%url% %name%\r\n}",
                                                      //@"Message: %original%\r\n\r\nPivotal Tracker Stories:\r\n\r\n{%url% %name%\r\n}",
//                                                      @"Message: [[ %state% {#%id%,} ] %original%\r\n\r\nPivotal Tracker Stories:\r\n\r\n{%url%\r\n}"
                                                      @"Message: [[%state% {#%id%,}]] %original%\r\n\r\n{%url%\r\n}"
                                                  };

		public const string tokenId = "id";
		public const string tokenState = "state";
		public const string tokenName = "name";
		public const string tokenUrl = "url";
		public const string tokenOriginal = "original";

		public const char templateDelimiter = '%';
		public const char repeatStart = '{';
		public const char repeatEnd = '}';
		public const char optionalStart = '[';
		public const char optionalEnd = ']';
		public const char escapeChar = '\\';
		public const char escapeCr = 'r';
		public const char escapeNl = 'n';
		public const char escapeTab = 't';
		public const char escapeZero = '0';
		public const char escapeHex = 'x';

		private string template;
		private List<Fragment> fragments = new List<Fragment>();

		private enum FragmentToken
		{
			LITERAL, ID, STATE, NAME, URL, ORIGINAL, REPEAT_START, REPEAT_END, OPTIONAL_START, OPTIONAL_END
		}

		private class Fragment
		{
			public Fragment(FragmentToken token, string value)
			{
				this.token = token;
				this.value = value;
			}

			public Fragment(FragmentToken token)
			{
				this.token = token;
				this.value = "";
			}

			public FragmentToken token;
			public string value;
		}

		public string Template
		{
			get { return template; }
			set { ParseTemplate(value); template = value; }
		}

		public string Evaluate(List<PivotalStory> stories, string status, string originalMessage)
		{
			int repeatFrom = -1;
			StringBuilder result = new StringBuilder();
			int fragmentCount = fragments.Count;
			int storyCount = stories.Count;
			int storyIndex = 0;
			bool isRepeating = false;
			for (int i = 0; i < fragmentCount; i++)
			{
				Fragment fragment = fragments[i];
				switch (fragment.token)
				{
					case FragmentToken.REPEAT_START:
						repeatFrom = i;
						storyIndex = 0;
						isRepeating = true;
						break;

					case FragmentToken.REPEAT_END:
						storyIndex++;
						if (storyIndex < storyCount)
						{
							i = repeatFrom;
							result.Append(fragment.value);
						}
						else
						{
							isRepeating = false;
						}
						break;

					case FragmentToken.OPTIONAL_START:
						int k = i + 1;
						bool isEmpty = true;
						while (k < fragmentCount && fragments[k].token != FragmentToken.OPTIONAL_END && isEmpty)
						{
							if (fragments[k].token != FragmentToken.LITERAL)
							{
								string value = GetFragmentValue(fragments[k], null, 0, status, originalMessage);
								isEmpty = string.IsNullOrEmpty(value);
							}
							k++;
						}
						if (isEmpty)
						{
							i = k;
						}
						break;

					case FragmentToken.OPTIONAL_END:
						result.Append(fragment.value);
						break;

					default:
						if (!isRepeating || storyIndex < storyCount)
						{
							string value = GetFragmentValue(fragment, stories, storyIndex, status, originalMessage);
							result.Append(value);
						}
						break;
				}
			}
			return result.ToString();
		}

		private string GetFragmentValue(Fragment fragment, List<PivotalStory> stories, int index, string status, string originalMessage)
		{
			PivotalStory story = stories != null && index < stories.Count ? stories[index] : null;
			switch (fragment.token)
			{
				case FragmentToken.LITERAL:
					return fragment.value;

				case FragmentToken.STATE:
					return status;

				case FragmentToken.ID:
					if (story != null)
					{
						return story.Id.ToString();
					}
					break;

				case FragmentToken.NAME:
					if (story != null)
					{
						return story.Name;
					}
					break;

				case FragmentToken.URL:
					if (story != null)
					{
						return story.Url;
					}
					break;

				case FragmentToken.ORIGINAL:
					return originalMessage;
			}
			return "";
		}

		public void ParseTemplate(string template)
		{
			List<Fragment> newFragments = new List<Fragment>();
			int length = template.Length;
			bool isRepeat = false;
			bool isOptional = false;
			bool isToken = false;

			StringBuilder currentFragmentValue = new StringBuilder();

			// Updated 1/1/2014 - LAE Can't use 'for' loop due to extra character processing

			int i = 0;
			while (i < length)
			{
				switch (template[i])
				{
					case templateDelimiter:
						AddFragment(newFragments, currentFragmentValue, isToken);
						isToken = !isToken;
						break;

					case repeatStart:
						if (isRepeat)
						{
							throw new ApplicationException("Error in template: nested repeated sequence is not allowed");
						}
						if (isToken || isOptional)
						{
							throw new ApplicationException("Error in template: unterminated token or optional sequence encountered: " + currentFragmentValue.ToString());
						}
						AddFragment(newFragments, currentFragmentValue, false);
						AddFragment(newFragments, currentFragmentValue, FragmentToken.REPEAT_START);
						isRepeat = true;
						break;

					case repeatEnd:
						if (!isRepeat)
						{
							throw new ApplicationException("Error in template: end of repeated sequence without corresponding start");
						}
						if (isToken || isOptional)
						{
							throw new ApplicationException("Error in template: unterminated token or optional sequence encountered: " + currentFragmentValue.ToString());
						}
						AddFragment(newFragments, currentFragmentValue, FragmentToken.REPEAT_END);
						isRepeat = false;
						break;

					case optionalStart:

						// Added 1/1/2014 - LAE see if a square bracket literal is present ie [[

						if (!isRepeat && !isToken && (i + 1 < length) && (template[i + 1] == optionalStart))
						{
							currentFragmentValue.Append(template[i]);
							isOptional = false;
							++i;    // inc char index. Index stepped at end of loop as well
							break;
						}

						if (isOptional)
						{
							throw new ApplicationException("Error in template: nested optional sequence is not allowed");
						}

						if (isToken || isRepeat)
						{
							throw new ApplicationException("Error in template: unterminated token or repeated sequence encountered: " + currentFragmentValue.ToString());
						}
						AddFragment(newFragments, currentFragmentValue, false);
						AddFragment(newFragments, currentFragmentValue, FragmentToken.OPTIONAL_START);
						isOptional = true;
						break;

					case optionalEnd:

						// Added 1/1/2014 - LAE see if a square bracket literal is present ie ]]
						if (!isRepeat && !isToken && (i + 1 < length) && (template[i + 1] == optionalEnd))
						{
							currentFragmentValue.Append(template[i]);
							isOptional = false;
							++i;    // inc char index. Index stepped at end of loop as well
							break;
						}

						if (!isOptional)
						{
							throw new ApplicationException("Error in template: end of optional sequence without corresponding start");
						}
						if (isToken || isRepeat)
						{
							throw new ApplicationException("Error in template: unterminated token or repeated sequence encountered: " + currentFragmentValue.ToString());
						}
						isOptional = false;
						AddFragment(newFragments, currentFragmentValue, FragmentToken.OPTIONAL_END);
						break;

					default:
						currentFragmentValue.Append(template[i]);
						break;
				}

				++i;        // step to next char
			}

			if (isRepeat)
			{
				throw new ApplicationException("Error in template: start repeat without corresponding end");
			}
			if (isToken)
			{
				throw new ApplicationException("Error in template: unterminated token encountered: " + currentFragmentValue.ToString());
			}
			AddFragment(newFragments, currentFragmentValue, false);
			fragments = newFragments;
		}

		private void AddFragment(List<Fragment> newFragments, StringBuilder stringBuilder, FragmentToken token)
		{
			Fragment fragment = new Fragment(token, ConvertValue(stringBuilder));
			newFragments.Add(fragment);
			stringBuilder.Remove(0, stringBuilder.Length);
		}

		private void AddFragment(List<Fragment> newFragments, StringBuilder stringBuilder, bool isToken)
		{
			if (stringBuilder.Length == 0)
			{
				return;
			}
			if (isToken)
			{
				Fragment fragment;
				string value = stringBuilder.ToString();
				if (tokenId.Equals(value))
				{
					fragment = new Fragment(FragmentToken.ID);
				}
				else if (tokenState.Equals(value)) // Added 5/1/2014
				{
					fragment = new Fragment(FragmentToken.STATE);
				}
				else if (tokenName.Equals(value))
				{
					fragment = new Fragment(FragmentToken.NAME);
				}
				else if (tokenUrl.Equals(value))
				{
					fragment = new Fragment(FragmentToken.URL);
				}
				else if (tokenOriginal.Equals(value))
				{
					fragment = new Fragment(FragmentToken.ORIGINAL);
				}
				else
				{
					throw new ApplicationException("Error in template: invalid token encountered: " + value);
				}
				newFragments.Add(fragment);
			}
			else
			{
				Fragment fragment = new Fragment(FragmentToken.LITERAL, ConvertValue(stringBuilder));
				newFragments.Add(fragment);
			}
			stringBuilder.Remove(0, stringBuilder.Length);
		}

		public string ConvertValue(StringBuilder stringBuilder)
		{
			StringBuilder result = new StringBuilder();
			int length = stringBuilder.Length;
			int i = 0;
			while (i < length)
			{
				if (stringBuilder[i] == escapeChar && i + 1 < length)
				{
					switch (stringBuilder[i + 1])
					{
						case escapeCr:
							result.Append('\r');
							i += 2;
							break;

						case escapeNl:
							result.Append('\n');
							i += 2;
							break;

						case escapeTab:
							result.Append('\t');
							i += 2;
							break;

						case escapeZero:
							if (i + 4 < length && stringBuilder[i + 2] == escapeHex)
							{
								char d1 = stringBuilder[i + 3];
								char d2 = stringBuilder[i + 4];
								d1 = char.IsDigit(d1) ? (char)(d1 - '0') : char.IsUpper(d1) ? (char)(10 + d1 - 'A') : (char)(10 + d1 - 'a');
								d2 = char.IsDigit(d2) ? (char)(d2 - '0') : char.IsUpper(d2) ? (char)(10 + d2 - 'A') : (char)(10 + d2 - 'a');
								char c = (char)(16 * d1 + d2);
								result.Append(c);
								i += 5;
							}
							else
							{
								i++;
							}
							break;

						default:
							break;
					}
				}
				else
				{
					result.Append(stringBuilder[i++]);
				}
			}
			return result.ToString();
		}
	}
}
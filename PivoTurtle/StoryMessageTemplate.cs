using System;
using System.Collections.Generic;
using System.Text;

namespace PivoTurtle
{
    public class StoryMessageTemplate
    {
        public static readonly string defaultTemplate = "{%url% } %original%";

        public static readonly string tokenId = "id";
        public static readonly string tokenName = "name";
        public static readonly string tokenUrl = "url";
        public static readonly string tokenOriginal = "original";

        private string template;
        private List<Fragment> fragments = new List<Fragment>();

        private enum FragmentToken
        {
            LITERAL, ID, NAME, URL, ORIGINAL, REPEAT_START, REPEAT_END
        }

        private class Fragment
        {
            public Fragment(FragmentToken token, string value)
            {
                this.token = token;
                this.value = value;
            }

            public FragmentToken token;
            public string value;
        }

        public string Template
        {
            get { return template; }
            set { ParseTemplate(value); template = value; }
        }

        public string Evaluate(List<PivotalStory> stories, string originalMessage)
        {
            int repeatFrom = -1;
            StringBuilder result = new StringBuilder();
            int fragmentCount = fragments.Count;
            int storyCount = stories.Count;
            int storyIndex = 0;
            for (int i = 0; i < fragmentCount; i++)
            {
                Fragment fragment = fragments[i];
                switch (fragment.token)
                {
                    case FragmentToken.REPEAT_START:
                        repeatFrom = i + 1;
                        storyIndex = 0;
                        break;
                    case FragmentToken.REPEAT_END:
                        storyIndex++;
                        if (storyIndex < storyCount)
                        {
                            i = repeatFrom;
                            result.Append(fragment.value);
                        }
                        break;
                    default:
                        if (storyIndex < storyCount)
                        {
                            AppendFragmentValue(result, fragment, stories, storyIndex, originalMessage);
                        }
                        break;
                }
            }
            return result.ToString();
        }

        private void AppendFragmentValue(StringBuilder result, Fragment fragment, List<PivotalStory> stories, int index, string originalMessage)
        {
            PivotalStory story = index < stories.Count ? stories[index] : null;
            switch (fragment.token)
            {
                case FragmentToken.LITERAL:
                    result.Append(fragment.value);
                    break;
                case FragmentToken.ID:
                    if (story != null)
                    {
                        result.Append(story.Id);
                    }
                    break;
                case FragmentToken.NAME:
                    if (story != null)
                    {
                        result.Append(story.Name);
                    }
                    break;
                case FragmentToken.URL:
                    if (story != null)
                    {
                        result.Append(story.Url);
                    }
                    break;
                case FragmentToken.ORIGINAL:
                    result.Append(originalMessage);
                    break;
            }
        }

        public void ParseTemplate(string template)
        {
            List<Fragment> newFragments = new List<Fragment>();
            int length = template.Length;
            bool isRepeating = false;
            bool isToken = false;
            StringBuilder currentFragmentValue = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                switch (template[i])
                {
                    case '%':
                        AddFragment(newFragments, currentFragmentValue, isToken);
                        isToken = !isToken;
                        break;
                    case '{':
                        if (isRepeating)
                        {
                            throw new ApplicationException("Error in template: nested repeat is not allowed");
                        }
                        if (isToken)
                        {
                            throw new ApplicationException("Error in template: unterminated token encountered: " + currentFragmentValue.ToString());
                        }
                        AddFragment(newFragments, currentFragmentValue, isToken);
                        isRepeating = true;
                        newFragments.Add(new Fragment(FragmentToken.REPEAT_START, ""));
                        break;
                    case '}':
                        if (!isRepeating)
                        {
                            throw new ApplicationException("Error in template: end repeat without corresponding start");
                        }
                        if (isToken)
                        {
                            throw new ApplicationException("Error in template: unterminated token encountered: " + currentFragmentValue.ToString());
                        }
                        isRepeating = false;
                        newFragments.Add(new Fragment(FragmentToken.REPEAT_END, currentFragmentValue.ToString()));
                        break;
                    default:
                        currentFragmentValue.Append(template[i]);
                        break;
                }
            }
            if (isRepeating)
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
                    fragment = new Fragment(FragmentToken.ID, "");
                }
                else if (tokenName.Equals(value))
                {
                    fragment = new Fragment(FragmentToken.NAME, "");
                }
                else if (tokenUrl.Equals(value))
                {
                    fragment = new Fragment(FragmentToken.URL, "");
                }
                else if (tokenOriginal.Equals(value))
                {
                    fragment = new Fragment(FragmentToken.ORIGINAL, "");
                }
                else
                {
                    throw new ApplicationException("Error in template: invalid token encountered: " + value);
                }
                newFragments.Add(fragment);
            }
            else
            {
                Fragment fragment = new Fragment(FragmentToken.LITERAL, stringBuilder.ToString());
                newFragments.Add(fragment);
            }
            stringBuilder.Remove(0, stringBuilder.Length);
        }
    }
}

using FullStopNet.Web.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace FullStopNet.Web.Extensions
{
    public static class StringExtensions
    {
        public static string EnsurePostfix(this string s, string post)
        {
            if (string.IsNullOrWhiteSpace(s) || string.IsNullOrWhiteSpace(post)) return s;
            return s.EndsWith(post) ? s : s + post;
        }

        public static string RemoveTrailingSlash(this string s)
        {
            return s.EndsWith("/") ? s.Substring(0, s.Length - 1) : s;
        }

        /// <summary>
        /// Truncates string content to a the closest space to the
        /// the max character limit
        /// </summary>
        /// <param name="text">Text to truncate</param>
        /// <param name="maxCharacters">maximum number of characters to allow</param>
        /// <param name="renderEllipses">if true will render ellipses at end of truncation</param>
        /// <returns>truncated string</returns>
        public static string TruncateToSpace(this string text, int maxCharacters, bool renderEllipses = true)
        {
            var output = text;
            if (maxCharacters > 0)
            {
                var wordsToKeep = new List<string>();
                var words = text.Split(' ');
                var count = 0;
                foreach (var word in words)
                {
                    count += word.Length + 1;
                    if (count >= maxCharacters)
                    {
                        break;
                    }
                    wordsToKeep.Add(word);
                }

                output = String.Join(" ", wordsToKeep);

                if (renderEllipses && output.Length < text.Length)
                {
                    output = String.Format("{0}...", output);
                }
            }

            return output;
        }

        /// <summary>
        /// Will deserialize a given XML string generated from a Data Type Grid
        /// property into a list of the provided type based on the supplied action. 
        /// </summary>
        /// <typeparam name="T">Type to convert to </typeparam>
        /// <param name="s">XML string to convert from</param>
        /// <param name="action">Action used to make the conversion</param>
        /// <returns>IEnumerable of the specified type</returns>
        public static IEnumerable<T> DataGridSelect<T>(this string s, Func<XElement, int, T> action)
        {
            return s.DataGridSelect<T>("item", action);
        }

        public static IEnumerable<T> DataGridSelect<T>(this string s, string itemName, Func<XElement, int, T> action)
        {
            if (!s.IsSet()) return new List<T>();

            var items = XElement.Parse(s).Elements(itemName.IsSet() ? itemName : "item");
            if (!items.Any()) return new List<T>();

            return items.Select(action);
        }

        public static string StripHtml(this string s)
        {
            var htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
            return s == null ? null : htmlRegex.Replace(s, string.Empty);
        }

        /// <summary>
        /// Short hand extension for Is Null or White Space
        /// </summary>
        /// <param name="s">string to check if set</param>
        /// <returns>true if string is set</returns>
        public static bool IsSet(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        public static string MaxLength(this string s, int maxLength, bool showElipses = true)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }
            return s.Length > maxLength ? s.Substring(0, maxLength) + (showElipses ? "..." : string.Empty) : s;
        }

        public static string CapitalizeFirstLetter(this string s)
        {
            if (!s.IsSet()) return s;

            return (s.Length > 1) ?
                s.Substring(0, 1).ToUpper() + s.Substring(1) :
                s.Substring(0, 1).ToUpper();
        }

        public static string StripSpaces(this string s)
        {
            return !string.IsNullOrWhiteSpace(s) ? s.Replace(" ", string.Empty) : string.Empty;
        }

        /// <summary>
        /// Returns true if the string has at least one character, and the first character is a letter.
        /// </summary>
        /// <param name="obj">the string to test</param>
        /// <returns>true if the parameter is a non-empty string starting with a letter, false otherwise</returns>
        public static bool StartsWithLetter(this string obj)
        {
            return !string.IsNullOrEmpty(obj)
                   && char.IsLetter(obj, 0);
        }

        /// <summary>
        /// If the specified string starts with a letter, it is returned as a single-character string. Otherwise,
        /// null is returned.
        /// </summary>
        /// <param name="obj">the string whose first letter should be retrieved</param>
        /// <returns>the first letter of the string, or null</returns>
        public static string GetFirstLetter(this string obj)
        {
            return obj.StartsWithLetter()
                       ? obj.First().ToString()
                       : null;
        }

        public static bool Contains(this string s, string compareValue, StringComparison comparisonMethod)
        {
            return s.IndexOf(compareValue, comparisonMethod) > -1;
        }

        /// <summary>
        /// Will collapse multiple spaces into one, and trim any trailing whitespace
        /// </summary>
        public static string CollapseAndTrim(this string s)
        {
            return Regex.Replace(s, @"\s+", " ").Trim();
        }

        /// <summary>
        /// Replaces text url with an anchor tag to that url. 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceUrlsWithLinks(this string text, int maxCharacters = 0)
        {
            if (maxCharacters > 0)
            {
                text = text.TruncateToSpace(maxCharacters);
            }

            return Regex.Replace(text, @"(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*", Url);
        }

        private static string Url(Match match)
        {
            return string.Format("<a href='{0}' target='_blank'>{0}</a>", match);
        }

        public static string LowercaseFistLetter(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }
            return Char.ToLowerInvariant(s[0]) + s.Substring(1);
        }

        // if title contains (All) remove it. Otherwise, strip the parentheses and add a dash
        public static string FormatTopicTitle(this string title)
        {
            return title.Replace(" (", " - ").Replace(")", string.Empty);
        }

        /// <summary>
        /// Will replace all new line and return characters with
        /// BR tags
        /// </summary>
        /// <param name="s">string to replace new lines in</param>
        /// <param name="sClass">optional css class for the br</param>
        /// <returns>string containing replaced new lines</returns>
        public static string ConvertNewLinesToBrs(this string s, string sClass = "")
        {
            var tag = "<br " + (sClass.IsSet() ? string.Format("class='{0}'", sClass) : string.Empty) + "/>";
            return s == null
                    ? null
                    : s.Replace("\r\n", tag).Replace("\n", tag).Replace("\r", tag);
        }

        /// <summary>
        /// Ensures a given string has a specific prefix.
        /// Will check if already exists, if not, add it.
        /// </summary>
        /// <param name="s">String to check prefix on</param>
        /// <param name="prefix">Prefix to ensure is there</param>
        /// <returns>string with prefix</returns>
        public static string EnsurePrefix(this string s, string prefix)
        {
            if (String.IsNullOrWhiteSpace(s)) return s;
            if (!s.StartsWith(prefix))
            {
                s = prefix + s;
            }
            return s;
        }

        /// <summary>
        /// Returns the string split into individual lines.
        /// </summary>
        /// <param name="s">The string to split.</param>
        /// <returns>An array of all the lines in the string.</returns>
        public static string[] Lines(this string s)
        {
            return s.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
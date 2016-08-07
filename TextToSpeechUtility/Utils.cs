using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SpeechTest
{
    public static class Utils
    {
        /// <summary>
        /// Removes all the [1], [2], [edit], etc junk
        /// </summary>
        public static string WikiStringStrip(this string s)
        {
            string result = Regex.Replace(s, @"\[\d+\]", "", RegexOptions.Multiline);
			result = result.Replace("Contents  [show]", "");
            result = result.Replace("Содержание  [показать]", "");
            result = result.Replace((char)0xAE, ' ');
            //result = result.Replace("[edit]", "");
            //result = result.Replace("[citation needed]", "");
            //result = result.Replace("[править | править вики-текст]", "");
            //result = result.Replace("[en]", "");
            result = Regex.Replace(result, @"\[.+?\]", "", RegexOptions.Multiline);
            return result;
        }

        public static string RemoveAllNewlines(this string s)
        {
            string result = s;
            result = result.Replace("\n", " ");
            result = result.Replace("\r", " ");
            return result;
        }

        public static string FixAcronymsForReadability(this string s)
        {
            string result = s;
            result = result.Replace("GUID", "gooiid");
            return result;
        }

		public static string[] SplitIntoPages(this string s)
		{
			const int CharLimit = 20000;

			List<string> list = new List<string>();
			var sb = new StringBuilder();
			var lines = s.Split('\n');
			foreach (var line in lines) {
				var line2 = line.Trim();
				if (String.IsNullOrEmpty(line2))
					continue;
				sb.Append(line2);
				sb.Append('\n');
				if (sb.Length > CharLimit) {
					list.Add(sb.ToString());
					sb.Clear();
				}
			}
			if (sb.Length > 0)
				list.Add(sb.ToString());

			return list.ToArray();
		}

        /// <summary>
        /// ... From Miktemk
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> list, T obj, Func<T, T, bool> comparator)
        {
            var index = 0;
            foreach (var x in list)
            {
                if (comparator(x, obj))
                    return index;
                index++;
            }
            return -1;
        }

        internal static QLanguage WhatLanguage(string s)
        {
            const int MaxChar = 30;
            var nEng = 0;
            var nRus = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if ((s[i] >= 65 && s[i] <= 90) ||
                    (s[i] >= 97 && s[i] <= 122))
                {
                    nEng++;
                    if (nEng > MaxChar)
                        return QLanguage.Engrish;
                }
                if (s[i] >= 0x400 && s[i] <= 0x4FF)
                {
                    nRus++;
                    if (nRus > MaxChar)
                        return QLanguage.Russian;
                }
                
            }
            return QLanguage.WTF;
        }

    }
}

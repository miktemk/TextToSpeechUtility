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
            Regex rgx = new Regex(@"\[\d+\]", RegexOptions.Multiline);
            var shit = rgx.Match(s);
            string result = rgx.Replace(s, "");
			result = result.Replace("[edit]", "");
			result = result.Replace("Contents  [show]", "");
			result = result.Replace("[citation needed]", "");
			result = result.Replace("[править | править вики-текст]", "");
			result = result.Replace("Содержание  [показать]", "");
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
    }
}

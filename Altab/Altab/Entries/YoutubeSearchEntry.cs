using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Altab.Entries
{
    [Serializable]
    public class YoutubeSearchEntry : Entry
    {
        private static Regex _regex = new Regex("(?::y |youtube search )(.+)", RegexOptions.IgnoreCase);
        const string Case1 = ":Y ";
        const string Case2 = "YOUTUBE SEARCH ";
        const string BaseName = "Youtube Search (:y)";
        string _search = null;

        public YoutubeSearchEntry()
        {
            Name = "Youtube Search (:y)";
        }

        public override bool Matches(string search)
        {
            if (search == null || search == string.Empty)
            {
                Name = BaseName;
                return true;
            }
            if (Case1.StartsWith(search.Substring(0,Case1.Length > search.Length ? search.Length : Case1.Length).ToUpper()) 
                || Case2.StartsWith(search.Substring(0, Case2.Length > search.Length ? search.Length : Case2.Length).ToUpper()))
            {
                if (_regex.IsMatch(search))
                {
                    _search = _regex.Match(search).Groups[1].Value.Trim();
                    Name = $"Youtube \"{_search}\"";
                } else
                {
                    _search = null;
                    Name = BaseName;
                }
                return true;
            }
            return false;
        }

        public override bool Run()
        {
            if (_search == null) return false;
            try
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/results?search_query=" + WebUtility.UrlEncode(_search));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

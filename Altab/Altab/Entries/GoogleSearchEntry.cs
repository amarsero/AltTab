using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Altab.Entries
{
    public class GoogleSearchEntry : Entry
    {
        private static Regex _regex = new Regex("(?::g |google search )(.+)", RegexOptions.IgnoreCase);
        const string Case1 = ":G ";
        const string Case2 = "GOOGLE SEARCH ";
        const string BaseName = "Google Search (:g)";
        string _search = null;

        public GoogleSearchEntry()
        {
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
                    Name = $"Google \"{_search}\"";
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
                System.Diagnostics.Process.Start("https://www.google.com/search?q=" + WebUtility.UrlEncode(_search));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

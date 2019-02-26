using Altab.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Altab
{
    public class Deposit
    {

        public List<Entry> entries = new List<Entry>();
        private Regex regex = new Regex("");

        public List<Entry> SearchAll(string search)
        {
            if (search == "") return entries.ToList();
            regex = new Regex(search, RegexOptions.IgnoreCase, new TimeSpan(0, 0, 5));
            return entries.Where(list => regex.IsMatch(list.Name)).OrderBy(x => x.Name).ToList();
        }
    }
}

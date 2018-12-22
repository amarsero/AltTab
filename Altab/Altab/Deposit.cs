using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Altab
{
    public class Deposit
    {
        internal List<Entry> entries = new List<Entry>();
        private Regex regex = new Regex("");

        public List<Entry> SearchAll(string search)
        {
            regex = new Regex(search, RegexOptions.IgnoreCase, new TimeSpan(0, 0, 5));
            return entries.Where(list => regex.IsMatch(list.Name)).ToList();
        }
    }
}

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

        public List<Entry> SearchAll(string search)
        {
            //if (search == "") return entries.OrderBy(x => x.Name).ToList();
            List<Entry> list = new List<Entry>();

            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].Matches(search))
                {
                    list.Add(entries[i]);
                }
            }

            return list.OrderBy(x => x.Name).ToList();
        }
    }
}

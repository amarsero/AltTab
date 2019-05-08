using Altab.Entries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Altab
{
    public class Deposit
    {

        public List<Entry> Entries { get; set; } = new List<Entry>();
        internal long Count { get; set; }

        public List<Entry> SearchAll(string search)
        {
            if (search == "") return Entries.OrderBy(x => x.RunCount).ThenBy(x => x.Name).ToList();
            List<Entry> list = new List<Entry>();

            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Entries.Count; i++)
            {
                if (Entries[i].Matches(search))
                {
                    list.Add(Entries[i]);
                }
            }

            if (list.Count < 5)
            {
                search = search.ToUpper();
                string[] split = search.Split(' ');
                List<string>[] listOfEdits = new List<string>[split.Length];
                bool add = false;
                for (int k = 0; k < split.Length; k++)
                {
                    if (split[k].Length < 4) continue;
                    listOfEdits[k] = SpellChecker.Edits(split[k]);

                    for (int i = 0; i < Entries.Count; i++)
                    {
                        foreach (var entry in Entries[i].Name.ToUpper().Split(' '))
                        {
                            if (entry.Length < 4) continue;
                            for (int j = 0; j < listOfEdits[k].Count; j++)
                            {
                                if (entry == listOfEdits[k][j])
                                {
                                    add = true;
                                    break;
                                }
                            }
                            if (add)
                            {
                                if (!list.Contains(Entries[i]))
                                    list.Add(Entries[i]);
                                add = false;
                                break;
                            }
                        }
                    }
                }

                if (list.Count < 3 && search.Length < 11)
                {
                    for (int k = 0; k < split.Length; k++)
                    {
                        if (listOfEdits[k] == null) continue;
                        listOfEdits[k] = SpellChecker.Edits(listOfEdits[k]);
                        for (int i = 0; i < Entries.Count; i++)
                        {
                            foreach (var entry in Entries[i].Name.ToUpper().Split(' '))
                            {
                                if (entry.Length < 4) continue;
                                for (int j = 0; j < listOfEdits[k].Count; j++)
                                {
                                    if (entry == listOfEdits[k][j])
                                    {
                                        add = true;
                                        break;
                                    }
                                }
                                if (add)
                                {
                                    if (!list.Contains(Entries[i]))
                                        list.Add(Entries[i]);
                                    add = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return list.OrderBy(x => x.Name).ToList();
        }
    }
}

using Altab.Auxiliaries;
using Altab.Entries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Altab
{
    [Serializable]
    public class Deposit
    {
        public List<Entry> Entries { get; set; } = new List<Entry>();
        public ulong TotalRunCount;
        public List<Entry> SearchAll(string search)
        {
            if (search == "") return Entries.OrderBy(x => x.RunCount).ToList();
            SortedLinkedList<float, Entry> list = new SortedLinkedList<float, Entry>();
            string[] searchSplit = search.ToUpper().Split(' ');
            bool added;
            for (int i = 0; i < Entries.Count; i++)
            {
                added = false;
                string[] split = Entries[i].Name.ToUpper().Split(' ');
                for (int j = 0; j < split.Length; j++)
                {
                    for (int k = 0; k < searchSplit.Length; k++)
                    {
                        if (split[j] == searchSplit[k])
                        {
                            added = true;
                            list.Add(Entries[i].RunCount+1 * 20,Entries[i]);
                            break;
                        }
                    }
                    if (added)
                        break;
                }
                if (!added && Entries[i].Matches(search))
                {
                    list.Add((Entries[i].RunCount + 1)/2, Entries[i]);
                }
            }

            if (list.Count < 5)
            {
                search = search.ToUpper();
                string[] split = search.Split(' ');
                List<string>[] listOfEdits = new List<string>[split.Length];
                added = false;
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
                                    added = true;
                                    break;
                                }
                            }
                            if (added)
                            {
                                if (!list.ContainsValue(Entries[i]))
                                {
                                    list.Add((Entries[i].RunCount + 1) / 4, Entries[i]);
                                }
                                added = false;
                                break;
                            }
                        }
                    }
                }

                if (list.Count < 3 && search.Length < 11)
                {
                    added = false;
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
                                        added = true;
                                        break;
                                    }
                                }
                                if (added)
                                {
                                    if (!list.ContainsValue(Entries[i]))
                                    {
                                        list.Add((Entries[i].RunCount + 1) / 8, Entries[i]);
                                    }
                                    added = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return list.ToList();
        }

        internal void RemoveDuplicates()
        {
            for (int i = 0; i < Entries.Count; i++)
            {
                for (int j = Entries.Count - 1; j > i; j--)
                {
                    if (Entries[i].FullPath == Entries[j].FullPath && Entries[j].FullPath != null ||
                        Entries[i].Name == Entries[j].Name)
                    {
                        Entries.RemoveAt(j);
                    }
                }
            }
        }

        internal void Update(Deposit deposit)
        {
            Entries = deposit.Entries;
        }
    }
}

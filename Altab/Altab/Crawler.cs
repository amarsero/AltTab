using Altab.Entries;
using IWshRuntimeLibrary;
using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altab
{
    public class Crawler
    {
        private Deposit _deposit;

        public Crawler(Deposit deposit)
        {
            _deposit = deposit;
        }

        public void CrawlNewPath(string path)
        {
            Entry entry;
            foreach (var filePath in Directory.EnumerateFiles(path))
            {
                switch (Path.GetExtension(filePath))
                {
                    case ".lnk":
                    case ".exe":
                        {
                            entry = EntryFactory.GetEntry(filePath);
                            if (_deposit.Entries.Any(x => x.FullPath == filePath || entry.Name == x.Name))
                            {
                                continue;
                            }
                            if (entry is ShortcutEntry && _deposit.Entries.OfType<ShortcutEntry>().Any(x => x.TargetPath == ((ShortcutEntry)entry).TargetPath))
                            {
                                continue;
                            }
                            _deposit.Entries.Add(EntryFactory.GetEntry(filePath));
                            break;
                        }
                    default:
                        {

                        }
                        break;
                }
            }
        }
    }
}
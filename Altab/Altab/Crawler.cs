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
                if (_deposit.entries.Find(x => x.FullPath == filePath) == null)
                {
                    entry = new Entry(filePath);
                    _deposit.entries.Add(entry);
                }
            }
        }
    }
}
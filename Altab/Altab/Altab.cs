using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altab
{
    public class Altab
    {
        private string startupPath;

        public Deposit Deposit { get; } = new Deposit();
        public Crawler Crawler { get; private set; }

        public Persistence Persistence { get; private set; }

        public Altab(string startupPath)
        {
            this.startupPath = startupPath;
            Persistence = new Persistence(Deposit, startupPath);
            Persistence.Save();
            Crawler = new Crawler(Deposit);
            Task.Run(() =>
            {
                Crawler.CrawlNewPath(@"D:\Users\Agus\Desktop");
                Crawler.CrawlNewPath(@"D:\Users\Public\Desktop");
                Crawler.CrawlNewPath(@"C:\Users\Pun\Desktop");
                Crawler.CrawlNewPath(@"C:\Users\Public\Desktop");
            });
            Deposit.Entries.Add(new Entries.GoogleSearchEntry());
            Deposit.Entries.Add(new Entries.YoutubeSearchEntry());
        }

        public object Search(string text)
        {
            List<Entries.Entry> list = Deposit.SearchAll(text);
            return list;
        }
    }
}

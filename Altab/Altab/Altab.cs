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
        public Deposit Deposit { get; } = new Deposit();
        public Crawler Crawler { get; private set; }

        public Altab()
        {
            Crawler = new Crawler(Deposit);
            Task.Run(() => {
                Crawler.CrawlNewPath(@"D:\Users\Agus\Desktop");
                Crawler.CrawlNewPath(@"D:\Users\Public\Desktop");
                Crawler.CrawlNewPath(@"C:\Users\Pun\Desktop");
                Crawler.CrawlNewPath(@"C:\Users\Public\Desktop");
            });
            Deposit.entries.Add(new Entries.GoogleSearchEntry());
        }
    }
}

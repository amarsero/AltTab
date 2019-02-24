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

        async public Task CrawlNewPath(string path)
        {
            Directory.EnumerateFiles(path);
        }
        //Icon.ExtractAssociatedIcon(@"D:\Program Files (x86)\Mutant Year Zero - Road To Heaven\ZoneUE4\Binaries\Win64\ZoneUE4-Win64-Shipping.exe")
    }
}

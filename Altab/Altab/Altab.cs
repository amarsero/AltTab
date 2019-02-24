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

        public Altab()
        {
            Deposit.entries.Add(new Entry() { Name = "Tuviejaajajaj" });
            Deposit.entries.Add(new Entry() { Name = "Tu hermana" });
            Deposit.entries.Add(new Entry() { Name = "Mi padrino", Icon = Icon.ExtractAssociatedIcon(@"D:\Program Files (x86)\Mutant Year Zero - Road To Heaven\ZoneUE4\Binaries\Win64\ZoneUE4-Win64-Shipping.exe") });
        }
    }
}

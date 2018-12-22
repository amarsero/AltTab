using System;
using System.Collections.Generic;
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
            Deposit.entries.Add(new Entry() { Name = "Mi padrino" });
        }
    }
}

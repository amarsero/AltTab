using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altab.Entries
{
    public abstract class Entry
    {
        public string Name { get; internal set; }
        public Icon Icon { get; internal set; }
        public string FullPath { get; internal set; }

        public override string ToString()
        {
            return Name;
        }

        public abstract void Run();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Altab
{
    public class Entry
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Icon Icon { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

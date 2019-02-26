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

        /// <summary>
        /// Runs the entry
        /// </summary>
        /// <returns>Returns true if the entry runs succesfully</returns>
        public abstract bool Run();

        public abstract bool Matches(string search);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;
using System.Text.RegularExpressions;

namespace Altab.Entries
{
    public class ShortcutEntry : Entry
    {
        public string TargetPath { get; internal set; }

        public override bool Matches(string search)
        {
            return Name.ToUpper().Contains(search.ToUpper());
        }

        public override bool Run()
        {
            ++RunCount;
            try
            {
                if (TargetPath != null)
                {
                    Process.Start(TargetPath);
                }
                else
                {
                    Process.Start(FullPath);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

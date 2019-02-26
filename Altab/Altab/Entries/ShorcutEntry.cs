using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace Altab.Entries
{
    public class ShortcutEntry : Entry
    {
        public string TargetPath { get; internal set; }

        public override void Run()
        {
            if (TargetPath != null)
            {
                Process.Start(TargetPath);
            }
            else
            {
                Process.Start(FullPath);
            }
        }
    }
}

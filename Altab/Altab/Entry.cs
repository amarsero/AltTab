using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace Altab
{
    public class Entry
    {
        public string Name { get; private set; }
        public Icon Icon { get; private set; }
        public string FullPath { get; private set; }

        public Entry(string fullPath)
        {
            FileInfo info = new FileInfo(fullPath);
            FullPath = fullPath;
            Name = info.Name.Replace(info.Extension, "");

            if (info.Extension.ToLower() == ".lnk")
            {
                WshShell shell = new WshShell(); //Create a new WshShell Interface
                IWshShortcut link;
                link = (IWshShortcut)shell.CreateShortcut(FullPath); //Link the interface to our shortcut
                string targetPath = link.TargetPath;
                if (!File.Exists(link.TargetPath))
                {
                    targetPath = targetPath.Substring(1);
                    targetPath = "D" + targetPath;
                }
                if (!File.Exists(link.TargetPath))
                {
                    targetPath = targetPath.Replace(" (x86)", "");
                }
                if (!File.Exists(link.TargetPath))
                {
                    info = new FileInfo(link.TargetPath);
                    targetPath = Path.GetFullPath(link.TargetPath);
                }
                Icon = Icon.ExtractAssociatedIcon(targetPath);
            }
            else
            {
                Icon = Icon.ExtractAssociatedIcon(FullPath);
            }
        }
        public override string ToString()
        {
            return Name;
        }

        public void Run()
        {
            Process.Start(FullPath);
        }
    }
}

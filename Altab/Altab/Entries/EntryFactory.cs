
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altab.Entries
{
    public static class EntryFactory
    {
        public static Entry GetEntry(string fullPath)
        {
            FileInfo info = new FileInfo(fullPath);

            switch (Path.GetExtension(fullPath))
            {
                case ".lnk":
                case ".exe":
                    {
                        ShortcutEntry entry = new ShortcutEntry();
                        entry.FullPath = fullPath;
                        entry.Name = info.Name.Replace(info.Extension, "");

                        if (info.Extension.ToLower() == ".lnk")
                        {
                            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell(); //Create a new WshShell Interface
                            IWshRuntimeLibrary.IWshShortcut link;
                            link = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(fullPath); //Link the interface to our shortcut
                            string targetPath = link.TargetPath;
                            targetPath = FindFile(targetPath);
                            if (targetPath != null)
                            {
                                entry.Icon = Icon.ExtractAssociatedIcon(targetPath);
                                entry.TargetPath = targetPath;
                            }
                        }
                        else
                        {
                            entry.Icon = Icon.ExtractAssociatedIcon(fullPath);
                        }
                        return entry;
                    }
            }
            return null;
        }

        private static string FindFile(string path)
        {
            if (File.Exists(path)) return path;
            string targetPath = path;
                
            targetPath = targetPath.Substring(1);
            targetPath = "C" + targetPath;
            if (File.Exists(targetPath)) return targetPath;

            targetPath = targetPath.Replace(" (x86)", "");
            if (File.Exists(targetPath)) return targetPath;

            targetPath = path;
            targetPath = targetPath.Substring(1);
            targetPath = "D" + targetPath;
            if (File.Exists(targetPath)) return targetPath;;

            targetPath = targetPath.Replace(" (x86)", "");
            if (File.Exists(targetPath)) return targetPath;

            return null;
        }
    }
}

using Infiltratense.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Infiltratense.Service
{
    public static class ProcessService
    {
        public static void StartProcess(string ProgramPath, bool Debug)
        {
            if (!ProgramPath.Contains(@"\"))
            {
                ProgramPath = CellFileInfo.CurrentPath + @"\" + ProgramPath;
            }
            Logger.Print("Starting: " + ProgramPath);
            Process.Start(new ProcessStartInfo
            {
                FileName = ProgramPath,
                CreateNoWindow = !Debug,
                UseShellExecute = Debug
            });
        }
    }
}

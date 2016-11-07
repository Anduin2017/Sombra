using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infiltratense;

namespace Infiltratense.Models
{
    public static class ProcessInfo
    {
        public static Process[] AllProcess => Process.GetProcesses();
        public static bool OnlyMeProcess()
        {
            foreach (var Process in AllProcess)
            {
                var ProcessFileName = Process.ProcessName + ".exe";
                if (AvaliableProcess.Contains(ProcessFileName) && ProcessFileName == CellFileInfo.PartnerName)
                {
                    return false;
                }
            }
            return true;
        }
        public static string[] AvaliableProcess { get; set; } = new string[] { Strings.GNameExe, Strings.ANameExe, Strings.BNameExe };
    }

}

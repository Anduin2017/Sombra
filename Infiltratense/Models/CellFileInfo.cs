using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infiltratense.Models
{
    public static class CellFileInfo
    {
        public static bool OnlyMe()
        {
            if (AHere() && SelfName != Strings.ANameExe)
            {
                return false;
            }
            else if (BHere() && SelfName != Strings.BNameExe)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string ProgramFile => Assembly.GetEntryAssembly().Location;
        public static string CurrentPath => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static string SelfName => Path.GetFileName(ProgramFile);
        public static string PartnerName => Strings.ConvertName(SelfName);
        public static bool IsGod => SelfName != Strings.ANameExe && SelfName != Strings.BNameExe;
        public static bool AHere()
        {
            var Files = Directory.GetFiles(CurrentPath);
            foreach (var File in Files)
            {
                var FileName = Path.GetFileName(File);
                if (Strings.ANameExe == FileName)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool BHere()
        {
            var Files = Directory.GetFiles(CurrentPath);
            foreach (var File in Files)
            {
                var FileName = Path.GetFileName(File);
                if (Strings.BNameExe == FileName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

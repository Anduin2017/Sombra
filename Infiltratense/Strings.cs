using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiltratense
{
    public static class Strings
    {
        public static string ProjectName => "Infiltratense";
        public static string GNameExe => "Infiltratense.exe";
        public static string ANameExe => "Infiltratensea.exe";
        public static string BNameExe => "Infiltratenseb.exe";
        public static string ServerAddress = "https://Obisoft.com.cn";
        public static string Version => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string ConvertName(string Name)
        {
            return Name == ANameExe ? BNameExe : ANameExe;
        }
    }
}

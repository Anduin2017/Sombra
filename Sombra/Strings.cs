using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombra
{
    public static class Strings
    {
        public static string ProjectName => "Sombra";
        public static string GNameExe => "Sombra.exe";
        public static string ANameExe => "Sombraa.exe";
        public static string BNameExe => "Sombrab.exe";
        public static string ServerAddress = "https://Obisoft.com.cn";
        public static string Version => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static string ConvertName(string name)
        {
            return name == ANameExe ? BNameExe : ANameExe;
        }
    }
}

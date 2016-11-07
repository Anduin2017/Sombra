using Infiltratense.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Infiltratense.Service;
using Infiltratense.Middleware;
using System.Runtime.InteropServices;

namespace Infiltratense
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\n Infiltratense by Obisoft.\n\n Version : " + Strings.Version);
            if (args.Length > 0)
            {
                var Arg = args[0];
                switch (Arg.Trim('-').Substring(0,1))
                {
                    case "v":
                        break;
                    case "h":
                        Console.WriteLine("\n\n-v -version\t\tView current version number.");
                        Console.WriteLine("-h -help\t\tView help.");
                        break;
                }
                return;
            }
#if DEBUG
            var host = new HostService()
                .UseAutoUpdateService(CurrentVersion: Strings.Version, Debug: true, ForceCurrent: true)
                .UseProtectorService(Disable: false, Debug: true)
                .UseStartWithBootService(Set: false)
                .UseStartUp<StartUp>();
#else
            var host = new HostService()
                .UseAutoUpdateService(CurrentVersion: Strings.Version, Debug: false, ForceCurrent: false)
                .UseProtectorService(Disable: false, Debug: false)
                .UseStartWithBootService(Set: true)
                .UseStartUp<StartUp>();
#endif
            host.Run();
        }
    }
}

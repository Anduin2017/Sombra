using Sombra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sombra.Service
{
    public class StartUp : HostService, IService
    {
        public override void Run()
        {
            base.Run();
            Thread.Sleep(500);
            Logger.PrintInfo("Sombra Started. Waitting for order...");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo("                                                                                          ");
            Logger.PrintInfo("                                                                                          ");
            Logger.PrintInfo("                                                                                          ");
            Logger.PrintInfo("                                                                                          ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("                                             #                                            ");
            Logger.PrintInfo("      # # #       # # # #    #  # #   # #    #    # # # #       #     # #      # # #      ");
            Logger.PrintInfo("    #           #         #   #     #     #  # #          #       # #        #       #    ");
            Logger.PrintInfo("   #           #           #  #     #     #  #             #      #         #         #   ");
            Logger.PrintInfo("    #          #           #  #     #     #  #             #      #         #         #   ");
            Logger.PrintInfo("      # # #    #           #  #     #     #  #             #      #         #         #   ");
            Logger.PrintInfo("           #   #           #  #     #     #  #             #      #         #         #   ");
            Logger.PrintInfo("           #     #        #   #     #     #  #  #         #       #          #       # #  ");
            Logger.PrintInfo("   # # # #         # # #      #     #     #  #    # # # #         #            # # #    # ");
            Logger.PrintInfo("                                                                                          ");
            Logger.PrintInfo("                                                                                          ");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo($"--------------------------------------------------------------------Version :{Strings.Version}-- ");
            Logger.PrintInfo($"--------------------------------------------------------------------Obisoft Corporation-- ");
        }
    }
}

using Infiltratense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Infiltratense.Service
{
    public class StartUp : HostService, IService
    {
        public override void Run()
        {
            base.Run();
            Thread.Sleep(500);
            Logger.PrintInfo("Infiltratense Started. Waitting for order...");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo("                                                                                          ");
            Logger.PrintInfo("                                                                        # #               ");
            Logger.PrintInfo("        # # # # # #                                                   #     #             ");
            Logger.PrintInfo("            #                                                        #        #           ");
            Logger.PrintInfo("            #                                                        #                    ");
            Logger.PrintInfo("            #                                                        #                    ");
            Logger.PrintInfo("            #                                                        #                    ");
            Logger.PrintInfo("            #                                                 # # # # # # # #             ");
            Logger.PrintInfo("            #                                                        #                    ");
            Logger.PrintInfo("            #                                                        #                    ");
            Logger.PrintInfo("            #                  #    # # # #                          #                    ");
            Logger.PrintInfo("            #                   #  #        #                        #                    ");
            Logger.PrintInfo("            #                   # #          #                       #                    ");
            Logger.PrintInfo("            #                   #             #                      #                    ");
            Logger.PrintInfo("            #                   #             #                      #                    ");
            Logger.PrintInfo("            #                   #             #                      #                    ");
            Logger.PrintInfo("            #                   #             #                      #                    ");
            Logger.PrintInfo("            #                   #             #                      #                    ");
            Logger.PrintInfo("            #                   #             #                      #                    ");
            Logger.PrintInfo("      # # # # # # #             #             #                      #                    ");
            Logger.PrintInfo("                                                                                          ");
            Logger.PrintInfo("                                                                                          ");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo("----------------------------------------------------------------------------------------- ");
            Logger.PrintInfo($"--------------------------------------------------------------------Version :{Strings.Version}-- ");
            Logger.PrintInfo($"--------------------------------------------------------------------Obisoft Corporation-- ");
        }
    }
}

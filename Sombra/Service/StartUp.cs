using Sombra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sombra.Service
{
    public class StartUp : HostBuilder, IService
    {
        public StartUp(IApplicationServer server)
        {
            this.Server = server;
        }

        public ApplicationBuilder Middlewares { get; set; }
        public IApplicationServer Server { get; set; }

        public override void Run()
        {
            base.Run();
            Middlewares = new ApplicationBuilder();
            Configure(Middlewares);
            Server.SetEvent(Middlewares.OnMessage);

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

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles()
               .Use404();
        }
    }
}

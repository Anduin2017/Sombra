using Infiltratense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiltratense.Service
{
    public class StartUp : HostService, IService
    {
        public override void Run()
        {
            base.Run();
            Logger.PrintInfo("Infiltratense Started. Waitting for order...");
        }
    }
}

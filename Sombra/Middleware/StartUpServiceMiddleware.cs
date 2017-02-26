using Sombra.Models;
using Sombra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombra.Middleware
{
    public static class StartUpServiceMiddleware
    {
        public static IService UseStartUp(this IService app, IApplicationServer Server)
        {
            var StartUpClass = new StartUp(Server);
            app.InsertService(StartUpClass);
            return app;
        }
    }
}

using Sombra.Models;
using Sombra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombra.Middleware
{
    public static class ProtectorServiceMiddleware
    {
        public static IService UseProtectorService(this IService app,bool Disable =false, bool Debug = false)
        {
            var _protector = new Protector
            {
                Debug = Debug,
                Disable = Disable
            };
            app.InsertService(_protector);
            return app;
        }
    }
}

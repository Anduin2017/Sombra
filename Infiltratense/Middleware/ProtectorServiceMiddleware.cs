using Infiltratense.Models;
using Infiltratense.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiltratense.Middleware
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

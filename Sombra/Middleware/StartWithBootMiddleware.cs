using Sombra.Models;
using Sombra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombra.Middleware
{
    public static class StartWithBootMiddleware
    {
        public static IService UseStartWithBootService(this IService app, bool Set = false)
        {
            var _winBooter = new WinBooter(Set);
            app.InsertService(_winBooter);
            return app;
        }
    }
}

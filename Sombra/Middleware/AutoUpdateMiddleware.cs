using Sombra.Models;
using Sombra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombra.Middleware
{
    public static class AutoUpdateMiddleware
    {
        public static IService UseAutoUpdateService(this IService app, string currentVersion, bool debug = false, bool forceCurrent = false)
        {
            var _updator = new Updator(currentVersion, debug, forceCurrent);
            app.InsertService(_updator);
            return app;
        }
    }
}

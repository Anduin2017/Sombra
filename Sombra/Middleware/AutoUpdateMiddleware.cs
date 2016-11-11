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
        public static IService UseAutoUpdateService(this IService app, string CurrentVersion, bool Debug = false, bool ForceCurrent = false)
        {
            var _updator = new Updator(CurrentVersion, Debug, ForceCurrent);
            app.InsertService(_updator);
            return app;
        }
    }
}

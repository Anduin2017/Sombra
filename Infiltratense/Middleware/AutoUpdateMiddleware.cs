using Infiltratense.Models;
using Infiltratense.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiltratense.Middleware
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

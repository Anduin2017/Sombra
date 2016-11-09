using Infiltratense.Models;
using Infiltratense.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiltratense.Middleware
{
    public static class TaskSchedulerMiddleware
    {
        public static IService UseTaskSchedulerService(this IService app, bool Disabled = false)
        {
            var _scheduler = new Scheduler(Disabled);
            app.InsertService(_scheduler);
            return app;
        }
    }
}

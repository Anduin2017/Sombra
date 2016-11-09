﻿using Infiltratense.Models;
using Infiltratense.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiltratense.Middleware
{
    public static class ReportServiceMiddleware
    {
        public static IService UseReportService(this IService app, int TimeOut = 1000,bool Delay = true)
        {
            var _reporter = new Reporter(TimeOut, Delay);
            app.InsertService(_reporter);
            return app;
        }
    }
}
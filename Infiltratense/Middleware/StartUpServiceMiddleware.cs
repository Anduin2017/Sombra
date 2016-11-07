using Infiltratense.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiltratense.Middleware
{
    public static class StartUpServiceMiddleware
    {
        public static IService UseStartUp<T>(this IService app) where T : IService, new()
        {
            var StartUpClass = new T();
            app.InsertService(StartUpClass);
            return app;
        }
    }
}

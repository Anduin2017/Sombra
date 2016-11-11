using Sombra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombra.Middleware
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
    public static class ReactorMiddleware
    {
        public static IService UseReactor(this IService app, ReactorService reactor)
        {
            app.InsertService(reactor);
            return app;
        }
    }
}

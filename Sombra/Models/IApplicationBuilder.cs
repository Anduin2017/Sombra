using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombra.Models
{
    public class HTTPContext
    {
        public string Path { get; set; }
    }
    public class ActionResult : IActionResult
    {
        public string Result { get; set; }
        public ActionResult(string ResponseMessage)
        {
            this.Result = ResponseMessage;
        }
    }
    public interface IActionResult
    {
        string Result { get; set; }
    }

    public interface IApplicationServer : IService
    {
        //Func<HTTPContext, IActionResult> OnMessageEvent { get; set; }
        //void OnMessage(HTTPContext context);
        void SetEvent(Func<HTTPContext, IActionResult> newevent);
    }
    public class SombraServer : HostBuilder, IApplicationServer, IService
    {
        public override void Run()
        {
            base.Run();


            //在这里启动服务器
            var context = new HTTPContext();
            var result = OnMessageEvent(context);

        }
        public Func<HTTPContext, IActionResult> OnMessageEvent { get; set; }
        public void SetEvent(Func<HTTPContext, IActionResult> newevent)
        {
            this.OnMessageEvent = newevent;
        }
    }

    public interface IApplicationBuilder
    {
        IApplicationBuilder NextMiddleware { get; set; }
        IApplicationBuilder UseStaticFiles();
        IApplicationBuilder Use404();

        bool Excuteable(HTTPContext context);
        IActionResult ExcuteResult(HTTPContext context);
        IActionResult OnMessage(HTTPContext context);
    }
    public class ApplicationBuilder : IApplicationBuilder
    {
        public IApplicationBuilder NextMiddleware { get; set; }
        public virtual void UseMiddleware(IApplicationBuilder NewMiddleware)
        {
            IApplicationBuilder Pointer = this;
            while (Pointer.NextMiddleware != null)
            {
                Pointer = Pointer.NextMiddleware;
            }
            Pointer.NextMiddleware = NewMiddleware;
        }
        public IApplicationBuilder UseStaticFiles()
        {
            this.UseMiddleware(new StaticFilesMiddleware());
            return this;
        }
        public IApplicationBuilder Use404()
        {
            this.UseMiddleware(new _404Middleware());
            return this;
        }

        public IActionResult OnMessage(HTTPContext context)
        {
            if (Excuteable(context))
            {
                return ExcuteResult(context);
            }
            return NextMiddleware.OnMessage(context);
        }
        public virtual bool Excuteable(HTTPContext context)
        {
            return false;
        }
        public virtual IActionResult ExcuteResult(HTTPContext context)
        {
            return null;
        }
    }

    public class StaticFilesMiddleware : ApplicationBuilder, IApplicationBuilder
    {
        public override bool Excuteable(HTTPContext context)
        {
            if (context.Path == "/")
            {
                return true;
            }
            return false;
        }
        public override IActionResult ExcuteResult(HTTPContext context)
        {
            return new ActionResult("file");
        }

    }
    public class _404Middleware : ApplicationBuilder, IApplicationBuilder
    {

        public override bool Excuteable(HTTPContext context)
        {
            return true;
        }
        public override IActionResult ExcuteResult(HTTPContext context)
        {
            return new ActionResult("404");
        }
    }
}

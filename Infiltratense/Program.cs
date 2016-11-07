using Infiltratense.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Infiltratense.Service;
using Infiltratense.Middleware;
using System.Runtime.InteropServices;

namespace Infiltratense
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var Arg = args[0];
                switch (Arg.Trim('-'))
                {
                    case "v":
                        Console.WriteLine("\n\n\n Infiltratense by Obisoft.\n\n Version : " + Strings.Version);
                        break;
                }
                return;
            }
#if DEBUG
            var host = new HostService()
                .UseAutoUpdateService(CurrentVersion: Strings.Version, Debug: true, ForceCurrent: true)
                .UseProtectorService(Disable: false, Debug: true)
                .UseStartWithBootService(Set: false)
                .UseStartUp<StartUp>();

            //ConsoleHelper.hideConsole();
#else
            var host = new HostService()
                .UseAutoUpdateService(CurrentVersion: Strings.Version, Debug: false, ForceCurrent: false)
                .UseProtectorService(Disable: false, Debug: false)
                .UseStartWithBootService(Set: false)
                .UseStartUp<StartUp>();
#endif
            host.Run();
        }
    }

    /// <summary>
    /// 控制台帮助类
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// 获取窗口句柄
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 设置窗体的显示与隐藏
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        /// <summary>
        /// 隐藏控制台
        /// </summary>
        /// <param name="ConsoleTitle">控制台标题(可为空,为空则取默认值)</param>
        public static void hideConsole(string ConsoleTitle = "")
        {
            ConsoleTitle = String.IsNullOrEmpty(ConsoleTitle) ? Console.Title : ConsoleTitle;
            IntPtr hWnd = FindWindow("ConsoleWindowClass", ConsoleTitle);
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 0);
            }
        }

        /// <summary>
        /// 显示控制台
        /// </summary>
        /// <param name="ConsoleTitle">控制台标题(可为空,为空则去默认值)</param>
        public static void showConsole(string ConsoleTitle = "")
        {
            ConsoleTitle = String.IsNullOrEmpty(ConsoleTitle) ? Console.Title : ConsoleTitle;
            IntPtr hWnd = FindWindow("ConsoleWindowClass", ConsoleTitle);
            if (hWnd != IntPtr.Zero)
            {
                ShowWindow(hWnd, 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sombra.Models;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Sombra.Service;
using System.Net;

namespace Sombra.Service
{
    public class Updator : HostBuilder, IService
    {
        public bool Debug;
        public bool ForceCurrent;
        public string CurrentVersion { get; set; }
        public Updator(string CurrentVersion, bool Debug, bool ForceCurrent)
        {
            this.Debug = Debug;
            this.CurrentVersion = CurrentVersion;
            this.ForceCurrent = ForceCurrent;
        }
        public override void Run()
        {
            base.Run();
            Logger.Print("Checking for updates...");
            GetUpdate();
            new Thread(() =>
            {
                while(true)
                {
                    Thread.Sleep(30000);
                    Logger.Print("Checking for updates schedully...");
                    GetUpdate();
                }
            }).Start();
        }
        public void GetUpdate()
        {
            try
            {
                Logger.PrintInfo($"Local application version is: {CurrentVersion}");
                var HTTP = new HTTPService();
                var HTTPResult = HTTP.Get(Strings.ServerAddress + "/api/InfVersion");
                VersionCheckResult Result = JsonConvert.DeserializeObject<VersionCheckResult>(HTTPResult);
                Logger.PrintInfo($"Server application version is: {Result.Result}");
                if (ForceCurrent)
                {
                    Logger.PrintWarning("Force current version. Won't do anything!");
                }
                else if (Result.Result.Trim() != CurrentVersion.Trim())
                {
                    Logger.PrintSuccess("Successfully downloaded the latest version...");
                    Logger.Print("Starting download the latest version...");
                    var DownloadVersion = HTTP.HttpDownloadFile(Result.DownloadUrl);
                    ProcessService.StartProcess(DownloadVersion, Debug);
                    Environment.Exit(0);
                }
                else
                {
                    Logger.PrintSuccess("Already up-to-date!");
                }
            }
            catch (Exception e)
            {
                Logger.PrintError("Exception: " + e.Message);
            }
        }
    }
    public class VersionCheckResult
    {
        public int Code { get; set; }
        public string Result { get; set; }
        public string DownloadUrl { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infiltratense.Models;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Infiltratense.Service;
using System.Net;

namespace Infiltratense.Service
{
    public class Updator : HostService, IService
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
            try
            {
                Logger.PrintInfo($"Local  application version is: {CurrentVersion}");
                var HTTP = new HTTPService();
                var HTTPResult = HTTP.Get(Strings.ServerAddress + "/api/InfVersion");
                VersionCheckResult Result = JsonConvert.DeserializeObject<VersionCheckResult>(HTTPResult);
                Logger.PrintInfo($"Server application version is: {Result.Result}");
                if(ForceCurrent)
                {
                    Logger.PrintWarning("Force current version. Won't do anything!");
                }
                else if (Result.Result.Trim() != CurrentVersion.Trim())
                {
                    Logger.Print("Starting download the latest version...");
                    var DownloadVersion = HTTP.HttpDownloadFile(Result.DownloadUrl);
                    ProcessService.StartProcess(DownloadVersion, Debug);
                    Environment.Exit(0);
                }
                else
                {
                    Logger.Print("Already up-to-date!");
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

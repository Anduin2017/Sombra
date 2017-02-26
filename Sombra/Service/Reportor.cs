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
using System.Management;

namespace Sombra.Service
{

    public class Reporter : HostBuilder, IService
    {
        private int TimeOut;
        private bool Delay;
        public Reporter(int TimeOut, bool Delay)
        {
            this.TimeOut = TimeOut;
            this.Delay = Delay;
        }
        public override void Run()
        {
            base.Run();
            new Thread(() =>
            {
                if (Delay)
                {
                    Logger.PrintSuccess("Report service started!");
                    Thread.Sleep(2000);
                }
                int ClientHash = 0;
                try
                {
                    var SNumber = GetMotherBoardSerialNumber();
                    Logger.PrintInfo("Got Motherboard Serial Number" + SNumber);
                    Logger.Print("Preparing to submit to the server...");
                    ClientHash = SNumber.GetHashCode();
                }
                catch (Exception e)
                {
                    Logger.PrintError("An error occured while trying to get motherborad serial number! " + e.Message);
                }
                while (true)
                {
                    try
                    {
                        var _model = new SubmitReport
                        {
                            ClientHash = ClientHash,
                            CPUUsage = Counter.getCurrentCpuUsage(),
                            AvailableRAM = Counter.getAvailableRAM()
                        };
                        Logger.PrintInfo($"CPU Usage: {_model.CPUUsage} Client Hash: {_model.ClientHash}");
                        Logger.Print("Trying to submit the data to server...");
                        var HTTP = new HTTPService();
                        var Result = HTTP.Post(Strings.ServerAddress + "/api/SubmitReport", $"ClientHash={_model.ClientHash}&CPUUsage={_model.CPUUsage}&AvailableRAM={_model.AvailableRAM}");
                        var ServerResponse = JsonConvert.DeserializeObject<ServerResposne>(Result);
                        if (ServerResponse.Code == 0)
                        {
                            Logger.PrintSuccess("Server Responsed: " + ServerResponse.Result);
                        }
                        else
                        {
                            Logger.PrintError("An error occoured while trying to contact the server! " + ServerResponse.Result);
                        }
                        Thread.Sleep(TimeOut);
                    }
                    catch (Exception e)
                    {
                        Logger.PrintError("An error occured while Contacting the server! " + e.Message);
                        Thread.Sleep(TimeOut);
                    }
                }
            }).Start();
        }

        private static string GetMotherBoardSerialNumber()
        {
            ManagementClass mc = new ManagementClass("WIN32_BaseBoard");
            ManagementObjectCollection moc = mc.GetInstances();
            string SerialNumber = "";
            foreach (ManagementObject mo in moc)
            {
                SerialNumber = mo["SerialNumber"].ToString();
                break;
            }
            return SerialNumber;
        }
    }

    public class Counter
    {
        static PerformanceCounter cpuCounter;
        static PerformanceCounter ramCounter;
        static Counter()
        {

            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public static float getCurrentCpuUsage()
        {
            return cpuCounter.NextValue();
        }

        public static float getAvailableRAM()
        {
            return ramCounter.NextValue();
        }
    }
    public class SubmitReport
    {
        public virtual int ClientHash { get; set; }

        public virtual float CPUUsage { get; set; }
        public virtual float AvailableRAM { get; set; }

        //public virtual DateTime SubmitTime { get; set; }
    }

    //{"Result":"Successfully Submited your report!","Code":0}
    public class ServerResposne
    {
        public virtual int Code { get; set; }
        public virtual string Result { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infiltratense.Models;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Infiltratense.Service;
using Microsoft.Win32.TaskScheduler;
using System.Net;

namespace Infiltratense.Service
{
    public class Scheduler : HostService, IService
    {
        public bool Disabled;
        public static string ServiceName = "Infiltratense Start Service";
        public Scheduler(bool Disabled)
        {
            this.Disabled = Disabled;
        }

        public static void CreateEvent(string EventName, bool IsDailyNotBoot = false)
        {
            var _taskService = new TaskService();
            var _taskDefintion = _taskService.NewTask();
            _taskDefintion.RegistrationInfo.Description = "Start Infiltratense";
            if (IsDailyNotBoot)
            {
                _taskDefintion.Triggers.Add(new DailyTrigger());
            }
            else
            {
                _taskDefintion.Triggers.Add(new LogonTrigger { });
            }
            _taskDefintion.Actions.Add(new ExecAction(CellFileInfo.ProgramFile, "-s", CellFileInfo.CurrentPath));
            _taskService.RootFolder.RegisterTaskDefinition(EventName, _taskDefintion);
        }
        public static void DeleteEvent(string EventName)
        {
            var _taskService = new TaskService();
            if (_taskService.RootFolder.AllTasks.Where(t => t.Name == EventName).Count() > 0)
            {
                _taskService.RootFolder.DeleteTask(EventName);
            }
            else
            {
                Logger.PrintWarning("Old Event does not exist! ");
            }
        }

        public override void Run()
        {
            base.Run();
            Logger.Print("Deleting any old event we created..");
            DeleteEvent(ServiceName);
            Logger.Print("Trying to create task scheduler..");
            try
            {
                CreateEvent(ServiceName);
                Logger.PrintSuccess("Successfully created the start up scheduler!");
            }
            catch (Exception e)
            {
                Logger.PrintError("An error occured while attempting to create task scheduler! " + e.Message);
                Logger.Print("Right now we just try to create a daily event.");
                CreateEvent(ServiceName, true);
                Logger.Print("Daily Event Created!");
            }
            if (Disabled)
            {
                Logger.PrintWarning("Disabled mode. Now will delete any events!");
                DeleteEvent(ServiceName);
            }
        }
    }
}

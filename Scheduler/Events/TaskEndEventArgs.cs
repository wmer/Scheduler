using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Events {
    public class TaskEndEventArgs {
        public DateTime EndDate { get; set; }
        public TimeSpan TotalTime { get; set; }
        public int TotalTimes { get; set; }
        public bool LastExecution { get; set; }

        public TaskEndEventArgs(DateTime endDate, TimeSpan totalTime, int totalTimes, bool lastExecution) {
            EndDate = endDate;
            TotalTime = totalTime;
            TotalTimes = totalTimes;
            LastExecution = lastExecution;
        }
    }

    public delegate void TaskEndEventHandler(object sender, TaskEndEventArgs ev);
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Events {
    public class TaskStartEventArgs {
        public DateTime StartDate { get; }
        public int Times { get; set; }

        public TaskStartEventArgs(DateTime startDate, int times) {
            StartDate = startDate;
            Times = times;
        }
    }

    public delegate void TaskStartEventHandler(object sender, TaskStartEventArgs ev);
}

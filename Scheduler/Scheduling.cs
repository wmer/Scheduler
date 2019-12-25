using Scheduler.Constants;
using Scheduler.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler {
    public class Scheduling {
        private SchedulerService _schedulerService;

        public Scheduling() {
            _schedulerService = new SchedulerService();
        }

        public void ScheduleTask(DateTime startIn, Action task, PeriodRepeat interval, int times = -1) =>
             _schedulerService.ScheduleTask(startIn, task, interval == null? default : interval.Value, times);

        public void Stop() => _schedulerService.Stop();
    }
}

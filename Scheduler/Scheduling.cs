using Scheduler.Constants;
using Scheduler.Events;
using Scheduler.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler {
    public class Scheduling {
        private SchedulerService _schedulerService;

        public event TaskStartEventHandler TaskStart;
        public event TaskEndEventHandler TaskEnd;

        public Scheduling() {
            _schedulerService = new SchedulerService();
            _schedulerService.TaskStart += OnTaskStart;
            _schedulerService.TaskEnd += OnTaskEnd;
        }

        public void ScheduleTask(DateTime startIn, Action task, PeriodRepeat interval, int times = -1) =>
             _schedulerService.ScheduleTask(startIn, task, interval == null? default : interval.Value, times);

        public void Stop() => _schedulerService.Stop();

        private void OnTaskStart(object sender, TaskStartEventArgs ev) {
            TaskStart?.Invoke(sender, ev);
        }

        private void OnTaskEnd(object sender, TaskEndEventArgs ev) {
            TaskEnd?.Invoke(sender, ev);
        }
    }
}

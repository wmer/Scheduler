using Scheduler.Events;
using Scheduler.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Scheduler.Services {
    internal class SchedulerService {
        private Timer _timer;

        public event TaskStartEventHandler TaskStart;
        public event TaskEndEventHandler TaskEnd;

        public SchedulerService() {
            _timer = new Timer();
        }

        public void ScheduleTask(DateTime startDate, Action task, TimeSpan interval = default, int times = -1) {
            if(startDate > DateTime.Now) {
                var timesRun = 0;

                TimeSpan timeToGo = startDate - DateTime.Now;

                _timer.Interval = timeToGo.TotalMilliseconds;
                _timer.Elapsed += (s, e) => {
                    if(interval > TimeSpan.Zero && _timer.Interval != interval.TotalMilliseconds) {
                        _timer.Interval = interval.TotalMilliseconds;
                    }
                    OnTaskStart(this, new TaskStartEventArgs(DateTime.Now, timesRun));
                    var watchGlobal = System.Diagnostics.Stopwatch.StartNew();
                    task.Invoke();

                    watchGlobal.Stop();

                    var elapsedMsGlobal = watchGlobal.ElapsedMilliseconds;
                    var tGlobal = TimeSpan.FromMilliseconds(elapsedMsGlobal);
                    timesRun++;
                    OnTaskEnd(this, new TaskEndEventArgs(DateTime.Now, tGlobal, timesRun));

                    if(timesRun == times) {
                        _timer.Stop();
                    }
                };
                _timer.AutoReset = interval > TimeSpan.Zero;
                _timer.Enabled = true;

            } else {
                throw new InvalidStartDateException();
            }
        }

        public void Stop() => _timer.Stop();

        public void OnTaskStart(object sender, TaskStartEventArgs e) {
            TaskStart?.Invoke(sender, e);
        }

        private void OnTaskEnd(object sender, TaskEndEventArgs e) {
            TaskEnd?.Invoke(sender, e);
        }
    }
}

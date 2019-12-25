using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Constants {
    public class PeriodRepeat {
        private PeriodRepeat(TimeSpan value) { Value = value; }

        public TimeSpan Value { get; set; }

        public static PeriodRepeat NoRepeat { get => new PeriodRepeat(default); }
        public static PeriodRepeat EverySecond { get => new PeriodRepeat(TimeSpan.FromSeconds(1)); }
        public static PeriodRepeat EveryMinute { get => new PeriodRepeat(TimeSpan.FromMinutes(1)); }
        public static PeriodRepeat EveryHour { get => new PeriodRepeat(TimeSpan.FromHours(1)); }
        public static PeriodRepeat Daily { get => new PeriodRepeat(TimeSpan.FromDays(1)); }
        public static PeriodRepeat Weekly { get => new PeriodRepeat(TimeSpan.FromDays(7)); }
        public static PeriodRepeat Monthly { get => new PeriodRepeat(TimeSpan.FromDays(30)); }
        public static PeriodRepeat Annually { get => new PeriodRepeat(TimeSpan.FromDays(30)); }

        public static PeriodRepeat Custom(TimeSpan timeSpan) => new PeriodRepeat(timeSpan);
    }
}

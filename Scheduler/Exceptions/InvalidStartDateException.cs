using System;
using System.Collections.Generic;
using System.Text;

namespace Scheduler.Exceptions {
    public class InvalidStartDateException : Exception {
        public InvalidStartDateException() : base($"Start Date is not valid.") {

        }
    }
}

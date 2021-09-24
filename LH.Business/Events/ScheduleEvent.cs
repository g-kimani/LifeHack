using LH.Business.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LH.Business.Events
{
    public class ScheduleEvent : Event
    {
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}

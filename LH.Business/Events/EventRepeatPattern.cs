using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LH.Business.Events
{
    public class EventRepeatPattern : BaseEntity
    {
        public ERepeatTypes? RepeatType { get; set; }
        public int? MaxNumberOfRepeats { get; set; }
        public int? SeperationCount { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public int? WeekOfMonth { get; set; }
        public int? DayOfMonth { get; set; }
        public int? MonthOfYear { get; set; }

    }

    public enum ERepeatTypes
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Yearly = 4
    }
}

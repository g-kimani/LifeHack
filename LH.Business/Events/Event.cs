using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LH.Business.Events
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Date => Start.ToShortDateString();
        public int Priority { get; set; }
        public int? RepeatPatternId { get; set; }
        public EventRepeatPattern RepeatPattern { get; set; }
    }
}

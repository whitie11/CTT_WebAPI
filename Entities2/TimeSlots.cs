using System;
using System.Collections.Generic;

namespace WebApi.Entities2
{
    public partial class TimeSlots
    {
        public TimeSlots()
        {
            Appts = new HashSet<Appts>();
        }

        public int TimeSlotId { get; set; }
        public string Slot { get; set; }

        public virtual ICollection<Appts> Appts { get; set; }
    }
}

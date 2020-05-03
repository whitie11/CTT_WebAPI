using System;
using System.Collections.Generic;

namespace WebApi.Entities2
{
    public partial class Stages
    {
        public Stages()
        {
            Appts = new HashSet<Appts>();
        }

        public int StageId { get; set; }
        public string State { get; set; }

        public virtual ICollection<Appts> Appts { get; set; }
    }
}

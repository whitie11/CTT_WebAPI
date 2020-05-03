using System;
using System.Collections.Generic;

namespace WebApi.Entities2
{
    public partial class Localities
    {
        public Localities()
        {
            Patients = new HashSet<Patients>();
        }

        public int LocalityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Patients> Patients { get; set; }
    }
}

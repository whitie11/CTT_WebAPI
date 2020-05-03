using System;
using System.Collections.Generic;

namespace WebApi.Entities2
{
    public partial class Clinics
    {
        public Clinics()
        {
            Appts = new HashSet<Appts>();
        }

        public int ClinicId { get; set; }
        public string ClinicName { get; set; }

        public virtual ICollection<Appts> Appts { get; set; }
    }
}

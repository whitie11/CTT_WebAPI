using System;
using System.Collections.Generic;

namespace WebApi.Entities2
{
    public partial class Appts
    {
        public int ApptId { get; set; }
        public DateTime Date { get; set; }
        public int TimeSlotId { get; set; }
        public int ClinicId { get; set; }
        public string Notes { get; set; }
        public int PatientId { get; set; }
        public int StageId { get; set; }
        public int TypeId { get; set; }
        public string ClinicGroup { get; set; }

        public virtual Clinics Clinic { get; set; }
        public virtual Patients Patient { get; set; }
        public virtual Stages Stage { get; set; }
        public virtual TimeSlots TimeSlot { get; set; }
        public virtual Types Type { get; set; }
    }
}

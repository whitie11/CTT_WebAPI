using System;
using System.Collections.Generic;
using WebApi.Models.Diary;
using WebApi.Models.Patients;

namespace WebApi.Entities2
{
    public partial class ApptDTO2
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

        public ClinicDTO Clinic { get; set; }
        public PatientDTO Patient { get; set; }
        public Stage Stage { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public ApptTypesDTO Type { get; set; }
    }
}

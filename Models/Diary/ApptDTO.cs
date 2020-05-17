using System;
using System.Collections.Generic;

namespace WebApi.Models.Diary
{
    public partial class ApptDTO
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
    }
}
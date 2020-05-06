using System;
using System.Collections.Generic;

namespace WebApi.Models.Patients
{
    public partial class PatientDTO
    {
        public int patientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public string nhsNo { get; set; }
        public string cpmsNo { get; set; }
        public string notes { get; set; }
        public bool? isOpen { get; set; }
        public int localityId { get; set; }
    }

}
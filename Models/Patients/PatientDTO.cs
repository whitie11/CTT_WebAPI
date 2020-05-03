using System;
using System.Collections.Generic;

namespace WebApi.Models.Patients
{
    public partial class PatientDTO
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Nhsno { get; set; }
        public string Cpmsno { get; set; }
        public string Notes { get; set; }
        public bool? IsOpen { get; set; }
        public int LocalityId { get; set; }
    }

}
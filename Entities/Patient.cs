using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Patient
    {
         public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string NHSno { get; set; }
        public string CPMSno { get; set; }
        public string Notes { get; set; }

       public virtual Appointment Appointment{get; set;}

    }
}
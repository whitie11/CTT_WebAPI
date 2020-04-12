using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities


{
    public class Clinic
    {
        public int Id { get; set; }
        public string ClinicName { get; set; }

        public virtual Appointment Appointment{get; set;}
    }
}
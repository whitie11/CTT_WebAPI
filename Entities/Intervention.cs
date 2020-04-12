using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Intervention
    {

         public int Id { get; set; }
        public string TypeCode { get; set; }
        public string Type { get; set; }

        public virtual Appointment Appointment{get; set;}
    }
}
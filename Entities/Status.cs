using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Status
    {
        public int Id { get; set; } 
        public string StatusText { get; set; }
       
       public virtual Appointment Appointment{get; set;}

    }
}
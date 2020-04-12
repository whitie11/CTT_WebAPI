using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class TimeSlot
    {
        
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; } 
        
        public virtual Appointment Appointment{get; set;}
    }
}
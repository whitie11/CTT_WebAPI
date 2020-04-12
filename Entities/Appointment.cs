using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
         
        [ForeignKey("Patients")]
        public  Patient PatientId { get; set; }
        [ForeignKey("TimeSlots")] public TimeSlot SlotId { get; set; }
        [ForeignKey("Clinics")] public Clinic ClinicId { get; set; }
        [ForeignKey("Interventions")] public Intervention InterventionId { get; set; }
        [ForeignKey("Status")] public Status StatusId { get; set; }
        public string Notes { get; set; }
    }
}
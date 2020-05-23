using System;


namespace WebApi.Models.Diary
{
    public class DiaryListItem
    {
        public string timeSlot { get; set; }
        public string patientName { get; set; }

        public string reason { get; set; }

        public int apptId { get; set; }

        public int patientId { get; set; }

        public int timeSlotId { get; set; }
        public string Notes { get; set; }
        public int StageId { get; set; }
    }
}
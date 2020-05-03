using System;  
namespace WebApi.Models.Diary


{
    public class DiaryReqDTO
    {
        public string date { get; set; }
        public int ClinicId { get; set; }
    }
}
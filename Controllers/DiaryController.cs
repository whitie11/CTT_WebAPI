using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Models.Diary;
using WebApi.Entities2;


namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("diary")]
    public class DiaryController : ControllerBase
    {
        private IDiaryService _diaryService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public DiaryController(
             IDiaryService diaryService,
             IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _diaryService = diaryService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("getDiaryPage")]
        public IEnumerable<DiaryRow> GetDiaryPage(DiaryReqDTO diaryReq)
        {
            var appts = _diaryService.GetApptsOnDate(diaryReq);
            var timeSlots = _diaryService.GetTimeSlots();

            List<DiaryRow> diaryList = new List<DiaryRow>();

            foreach (TimeSlots ts in timeSlots)
            {
                DiaryRow dr = new DiaryRow
                {
                    timeSlot = new TimeSlot(),
                    setA = new DiaryListItem(),
                    setB = new DiaryListItem(),
                    setC = new DiaryListItem(),
                };

                dr.timeSlot = new TimeSlot
                {
                    timeSlotId = ts.TimeSlotId,
                    slot = ts.Slot
                };

                foreach (Appts appt in appts)
                {
                    if (appt.ClinicGroup == "A" && appt.TimeSlotId == ts.TimeSlotId)
                    {
                        dr.setA = new DiaryListItem
                        {
                            timeSlot = ts.Slot,
                            patientName = appt.Patient.FirstName + " " + appt.Patient.LastName,
                            reason = appt.Type.TypeText,
                            apptId = appt.ApptId,
                            patientId = appt.PatientId,
                            timeSlotId = ts.TimeSlotId,
                            Notes = appt.Notes
                        };

                    }
                    else if (appt.ClinicGroup == "B" && appt.TimeSlotId == ts.TimeSlotId)
                    {
                        dr.setB = new DiaryListItem
                        {
                            timeSlot = ts.Slot,
                            patientName = appt.Patient.FirstName + " " + appt.Patient.LastName,
                            reason = appt.Type.TypeText,
                            apptId = appt.ApptId,
                            patientId = appt.PatientId,
                            timeSlotId = ts.TimeSlotId,
                            Notes = appt.Notes
                        };
                    }
                    else if (appt.ClinicGroup == "C" && appt.TimeSlotId == ts.TimeSlotId)
                    {
                        dr.setC = new DiaryListItem
                        {
                            timeSlot = ts.Slot,
                            patientName = appt.Patient.FirstName + " " + appt.Patient.LastName,
                            reason = appt.Type.TypeText,
                            apptId = appt.ApptId,
                            patientId = appt.PatientId,
                            timeSlotId = ts.TimeSlotId,
                            Notes = appt.Notes
                        };
                    }
                }  
                
                diaryList.Add(dr);
            }

            return diaryList;
        }




    }
}
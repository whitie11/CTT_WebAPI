using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using WebApi.Helpers;
using WebApi.Models.Diary;
using WebApi.Entities2;

namespace WebApi.Services

{
    public interface IDiaryService
    {
        IEnumerable<Appts> GetApptsOnDate(DiaryReqDTO diaryReqDTO);
        IEnumerable<TimeSlots> GetTimeSlots();

    }

    public class DiaryService : IDiaryService
    {
        private CTT_DbContext _context;

        public DiaryService(CTT_DbContext context)
        {
            _context = context;
        }


        public IEnumerable<Appts> GetApptsOnDate(DiaryReqDTO diaryReqDTO)
        {

            return _context.Appts
            .Include(t => t.Type)
            .Include(p =>p.Patient)
            .Where(d => d.Date == DateTime
            .Parse(diaryReqDTO.date) && d.ClinicId == diaryReqDTO.ClinicId)
            .ToList();
        }

            public IEnumerable<TimeSlots> GetTimeSlots()
        {

            return _context.TimeSlots.ToList();
        }



    }
}
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
        Appts SaveAppt(Appts newAppt);
        Appts GetById(int apptId);

    }

    public class DiaryService : IDiaryService
    {
        private CTT_DbContext _context;

        public DiaryService(CTT_DbContext context)
        {
            _context = context;
        }

        public Appts GetById(int id)
        {
            return _context.Appts
                .Include(t =>t.Type)
                .Include(c => c.Clinic)
                .Include(p => p.Patient)
                .Include(p => p.Patient.Locality)
                .Include(t => t.TimeSlot)
                .Include(s => s.Stage)
                .Where(a => a.ApptId == id)
                .First();
        }

        public IEnumerable<Appts> GetApptsOnDate(DiaryReqDTO diaryReqDTO)
        {

            return _context.Appts
            .Include(t => t.Type)
            .Include(p => p.Patient)
            .Where(d => d.Date == DateTime
            .Parse(diaryReqDTO.date) && d.ClinicId == diaryReqDTO.ClinicId)
            .ToList();
        }

        public IEnumerable<TimeSlots> GetTimeSlots()
        {

            return _context.TimeSlots.ToList();
        }

        public Appts SaveAppt(Appts newAppt)
        {
            _context.Appts.Add(newAppt);
            _context.SaveChanges();

            return newAppt;
        }

    }
}
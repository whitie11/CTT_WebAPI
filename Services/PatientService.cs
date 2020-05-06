using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Helpers;
using WebApi.Models.Patients;
using WebApi.Entities2;


namespace WebApi.Services

{
    public interface IPatientService
    {
        IEnumerable<Patients> GetAllPts();
        Patients saveNewPt(Patients newPt);
        public void Update(PtEditDTO data);

    }

    public class PatientService : IPatientService
    {
        private CTT_DbContext _context;

        public PatientService(CTT_DbContext context)
        {
            _context = context;
        }


        public IEnumerable<Patients> GetAllPts()
        {
            return _context.Patients;
        }

        public Patients saveNewPt(Patients newPt)
        {
            _context.Patients.Add(newPt);
            _context.SaveChanges();

            return newPt;
        }

        public void Update(PtEditDTO data)
        {
            var pt = _context.Patients.Find(data.patientId);

            if (pt == null)
                throw new AppException("Patient not found");


            pt.Notes = data.notes;
            pt.LocalityId = data.localityId;
            pt.IsOpen = data.isOpen;
            _context.Patients.Update(pt);
            _context.SaveChanges();
        }

    }
}

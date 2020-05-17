using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Helpers;
using WebApi.Models.Patients;
using WebApi.Entities2;


namespace WebApi.Services

{
    public interface IPatientService
    {
        IEnumerable<Patients> GetAllPts();
        IEnumerable<ClinicListDTO> GetClinicList(int localityId);
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
            return _context.Patients.Include(l => l.Locality);
        }

        public IEnumerable<ClinicListDTO> GetClinicList(int localityId)
        {
            var cl =  _context.Patients
            .Where(l => l.LocalityId == localityId)
            .Include(l => l.Locality);

            var res = new List<ClinicListDTO>();
            foreach(Patients p in cl){
                var pt = new ClinicListDTO{
                    ptId = p.PatientId,
                    ptName = p.FirstName + " " + p.LastName
                };
                res.Add(pt);
            }
            return res;
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

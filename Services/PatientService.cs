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

    }
}

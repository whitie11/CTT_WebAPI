using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Helpers;
using WebApi.Models.Patients;
using WebApi.Entities2;

namespace WebApi.Services

{
    public interface IApptService
    {
      IEnumerable<Appts> GetAll();
     
    }

    public class ApptService : IApptService
    {
        private CTT_DbContext _context;

        public ApptService(CTT_DbContext context)
        {
            _context = context;
        }

       
        public IEnumerable<Appts> GetAll()
        {
            return _context.Appts;
        }

    }
}
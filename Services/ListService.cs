using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Diary;
using WebApi.Entities2;

namespace WebApi.Services

{
    public interface IListService
    {
      IEnumerable<Clinics> GetClinics();
      IEnumerable<Localities> GetLocalities();
    }

    public class ListService : IListService
    {
        private CTT_DbContext _context;

        public ListService(CTT_DbContext context)
        {
            _context = context;
        }

       
        public IEnumerable<Clinics> GetClinics()
        {
            return _context.Clinics;
        }


               public IEnumerable<Localities> GetLocalities()
        {
            return _context.Localities;
        }
    }
              
}


using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Models.Patients;


namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("patients")]
    public class PatientController : ControllerBase
    {
        private IPatientService _patientService;
         private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public PatientController(
             IPatientService patientService,
             IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _patientService = patientService;
             _mapper = mapper;
            _appSettings = appSettings.Value;
        }

         [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var pts = _patientService.GetAllPts();
            var model = _mapper.Map<IList<PatientDTO>>(pts);
            return Ok(model);
        }




    }
}
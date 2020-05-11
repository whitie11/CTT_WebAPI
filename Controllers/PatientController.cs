using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
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

        [HttpPost("saveNewPt")]
        public IActionResult saveNewPt([FromBody]PtNewDTO model)
        {
            try
            {
                var pt = _mapper.Map<WebApi.Entities2.Patients>(model);
                _patientService.saveNewPt(pt);
                return Ok();
            }
            catch (Exception e)
            {
               return BadRequest("New patient not saved! " + e.InnerException.Message);
            }

        }


                [HttpPut("updatePt")]
        public IActionResult UpdatePt([FromBody]PtEditDTO model)
        {
            try
            {
                // update patient 
                _patientService.Update(model);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
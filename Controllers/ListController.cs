using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using WebApi.Helpers;
using Microsoft.Extensions.Options;


using WebApi.Services;
using WebApi.Models.Diary;


namespace WebApi.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("lists")]
    public class ListController : ControllerBase
    {
        private IListService _listService;
         private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ListController(
             IListService listService,
             IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _listService = listService;
             _mapper = mapper;
            _appSettings = appSettings.Value;
        }

         [HttpGet("getClinics")]
        public IActionResult GetClinics()
        {
            var clinics = _listService.GetClinics();
            var model = _mapper.Map<IList<ClinicDTO>>(clinics);
            return Ok(model);
        }

               [HttpGet("getLocalities")]
        public IActionResult GetLocalities()
        {
            var clinics = _listService.GetLocalities();
           // var model = _mapper.Map<IList<UserModel>>(users);
            return Ok(clinics);
        }


    }
}
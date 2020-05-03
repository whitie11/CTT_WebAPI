using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;

using WebApi.Entities2;
using WebApi.Models.Diary;


namespace WebApi.Controllers
{
    // [Authorize]
    // [ApiController]
    // [Route("appts")]
    // public class ApptController : ControllerBase
    // {
    //     private IApptService _apptService;
    //      private IMapper _mapper;
    //     private readonly AppSettings _appSettings;

    //     public ApptController(
    //          IApptService apptService,
    //          IMapper mapper,
    //         IOptions<AppSettings> appSettings)
    //     {
    //         _apptService = apptService;
    //          _mapper = mapper;
    //         _appSettings = appSettings.Value;
    //     }

    //      [HttpGet("getAll")]
    //     public IActionResult GetAll()
    //     {
    //         var appts = _apptService.GetAll();
    //         var model = _mapper.Map<IList<ApptDTO>>(appts);
    //         return Ok(model);
    //     }




    // }
}
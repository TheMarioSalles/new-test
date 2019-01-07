//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using Sow.Components.Databases.Settings;
//using MarioLucci.Ituran.Api.Helpers;
//using MarioLucci.Ituran.Api.Services.Interfaces;

//namespace MarioLucci.Ituran.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//        private IAccountService _accountService;
//        private IMapper _mapper;
//        private readonly AppSettingsHelper _appSettingsHelper;
//        private readonly MongoDbSettings _mongoDbSettings;

//        public AccountController(
//            IAccountService accountService,
//            IMapper mapper,
//            IOptions<AppSettingsHelper> appSettingsHelper,
//            IOptions<MongoDbSettings> mongoDbSettings
//            )
//        {
//            _accountService = accountService;
//            _mapper = mapper;
//            _appSettingsHelper = appSettingsHelper.Value;
//            _mongoDbSettings = new MongoDbSettings();
//        }

//        //[AllowAnonymous]
//        //[HttpPost("create")]
//        //public async Task<IActionResult> Create([FromBody]ClientDto clientDto)
//        //{
//        //    // map dto to entity
//        //    var client = _mapper.Map<Client>(clientDto);

//        //    try
//        //    {
//        //        // save 
//        //        await _clientService.Add(client);
//        //        return Ok("Cliente registrado com sucesso!");
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        // return error message if there was an exception
//        //        return BadRequest(new { message = ex.Message });
//        //    }
//        //}
//    }
//}
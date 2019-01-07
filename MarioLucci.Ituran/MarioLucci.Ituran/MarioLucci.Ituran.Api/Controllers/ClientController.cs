//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using Sow.Components.Databases.Settings;
//using Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities;
//using MarioLucci.Ituran.Api.Helpers;
//using MarioLucci.Ituran.Api.Models.Entities;
//using MarioLucci.Ituran.Api.Services.Interfaces;

//namespace MarioLucci.Ituran.Api.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClientsController : ControllerBase
//    {
//        private IClientService _clientService;
//        private IMapper _mapper;
//        private readonly AppSettingsHelper _appSettingsHelper;
//        private readonly MongoDbSettings _mongoDbSettings;

//        public ClientsController(
//            IClientService clientService,
//            IMapper mapper,
//            IOptions<AppSettingsHelper> appSettingsHelper,
//            IOptions<MongoDbSettings> mongoDbSettings
//            )
//        {
//            _clientService = clientService;
//            _mapper = mapper;
//            _appSettingsHelper = appSettingsHelper.Value;
//            _mongoDbSettings = new MongoDbSettings();
//        }

//        [AllowAnonymous]
//        [HttpPost("create")]
//        public async Task<IActionResult> Create([FromBody]ClientDto clientDto)
//        {
//            try
//            {
//                var client = _mapper.Map<Client>(clientDto);
//                await _clientService.Add(client);
//                return Ok("Cliente registrado com sucesso!");
//            }
//            catch (Exception ex)
//            {
//                // return error message if there was an exception
//                return BadRequest(new { message = ex.Message });
//            }
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var Clients = await _clientService.GetAll();
//            var ClientDtos = _mapper.Map<IList<ClientDto>>(Clients);
//            return Ok(ClientDtos);
//        }

//        //[HttpGet("Filtrar/{name}")]
//        //public async Task<IActionResult> GetAllByName(string name)
//        //{
//        //    var Clients = await _clientService.GetAllByName(name);
//        //    var ClientDtos = _mapper.Map<IList<ClientDto>>(Clients);
//        //    return Ok(ClientDtos);
//        //}

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(string id)
//        {
//            var Client = await _clientService.GetById(id);
//            var ClientDto = _mapper.Map<ClientDto>(Client);
//            return Ok(ClientDto);
//        }

//        //[HttpGet("Nome/{Clientname}")]
//        //public async Task<IActionResult> GetByClientname(string Clientname)
//        //{
//        //    var Client = await _clientService.GetByClientname(Clientname);
//        //    var ClientDto = _mapper.Map<ClientDto>(Client);
//        //    return Ok(ClientDto);
//        //}

//        [HttpPut("update")]
//        public async Task<IActionResult> Update([FromBody]ClientDto clientDto)
//        {
//            try
//            {
//                var client = _mapper.Map<Client>(clientDto);
//                await _clientService.Update(client);
//                return Ok(String.Format("Cliente {0} alterado com sucesso!", client.Name));
//            }
//            catch (Exception ex)
//            {
//                // return error message if there was an exception
//                return BadRequest(new { message = ex.Message });
//            }
//        }

//        #region "Accounts"

//        [HttpPut("addaccount/{clientId}")]
//        public async Task<IActionResult> AddAccount(string clientId, [FromBody]AccountDto accountDto)
//        {
//            try
//            {
//                var client = await _clientService.GetById(clientId);
//                var account = _mapper.Map<Account>(accountDto);
//                await _clientService.AddAccount(client, account);
//                await _clientService.Update(client);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { message = ex.Message });
//            }
//        }

//        [HttpPut("updateaccount/{clientId}")]
//        public async Task<IActionResult> UpdateAccount(string clientId, [FromBody]AccountDto accountDto)
//        {
//            try
//            {
//                var client = await _clientService.GetById(clientId);
//                var account = _mapper.Map<Account>(accountDto);
//                await _clientService.UpdateAccount(client, account);
//                await _clientService.Update(client);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(new { message = ex.Message });
//            }
//        }

//        #endregion
//    }
//}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sow.Components.Databases.Settings;
using Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities;
using Sow.Interfaces.AdminWAPP.WebApi.Helpers;
using Sow.Interfaces.AdminWAPP.WebApi.Models.Entities;
using Sow.Interfaces.AdminWAPP.WebApi.Services.Interfaces;

namespace Sow.Interfaces.AdminWAPP.WebApi.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettingsHelper _appSettingsHelper;
        private readonly MongoDbSettings _mongoDbSettings;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettingsHelper> appSettingsHelper,
            IOptions<MongoDbSettings> mongoDbSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettingsHelper = appSettingsHelper.Value;
            _mongoDbSettings = new MongoDbSettings();
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserDto userDto)
        {
            try
            {
                var user = await _userService.Authenticate(userDto.Username, userDto.Password);

                if (user == null)
                    return BadRequest(new { message = "Usuário ou Senha inválido."});

                ClaimsIdentity lc = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Username)
                });

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettingsHelper.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = lc,
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                userDto.Token = tokenHandler.WriteToken(token);
                userDto.Id = user.Id;

                var identity = new ClaimsIdentity(
                    new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Username)
                    },
                    JwtBearerDefaults.AuthenticationScheme
                );

                var principal = new ClaimsPrincipal(identity);
                //Request.GetOwinContext().Authentication.SignIn();
                //await HttpContext.SignInAsync("Bearer", principal);
                return Ok(userDto);
            }
            catch(Exception e)
            {
                return Ok(userDto);
            }
            
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserDto userDto)
        {
            // map dto to entity
            var user = _mapper.Map<User>(userDto);

            try
            {
                // save 
                await _userService.Add(user, userDto.Password);
                return Ok("Usuário registrado com sucesso!");
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("Filter/Username/{username}")]
        public async Task<IActionResult> GetAllByUsername(string username)
        {
            var users = await _userService.GetAllByUsername(username);
            var userDtos = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpGet("Username/{username}")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _userService.GetByUsername(username);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody]UserDto userDto)
        {
            // map dto to entity and set id
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            try
            {
                // save 
                await _userService.Update(user, userDto.Password);
                return Ok(String.Format("Usuário {0} alterado com sucesso!", user.Name));
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using MarioLucci.Ituran.Api.Helpers;
using MarioLucci.Ituran.Api.Services.Interfaces;
using MarioLucci.Ituran.Domain.Dtos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sow.Components.Databases.Settings;

namespace MarioLucci.Ituran.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;
        private readonly AppSettingsHelper _appSettingsHelper;
        private readonly MongoDbSettings _mongoDbSettings;

        public CurrencyController(
            ICurrencyService currencyService,
            IMapper mapper,
            IOptions<AppSettingsHelper> appSettingsHelper,
            IOptions<MongoDbSettings> mongoDbSettings)
        {
            this._currencyService = currencyService;
            this._mapper = mapper;
            this._appSettingsHelper = appSettingsHelper.Value;
            this._mongoDbSettings = new MongoDbSettings();
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrencies()
        {
            return this.Ok(await CurrencyHelper.CurrencyLayerToCurrency());
        }

        [HttpGet("Currency/{shortName}")]
        public async Task<IActionResult> GetCurrencies([FromQuery]string shortName)
        {
            return this.Ok(await CurrencyHelper.CurrencyLayerToCurrency(shortName));
        }

        [HttpGet("Currency/Convert/{fromCurrency}/{toCurrency}")]
        public async Task<IActionResult> GetCurrencies([FromQuery]string fromCurrency, [FromQuery]string toCurrency)
        {
            return this.Ok(await CurrencyHelper.ConvertCurrency(fromCurrency, toCurrency));
        }
    }
}
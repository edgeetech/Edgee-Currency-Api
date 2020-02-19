using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Edgee.Api.Currency.Model;
using Edgee.Api.Currency.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NCrontab;
using Newtonsoft.Json.Linq;

namespace Edgee.Api.Currency.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string BASE_CURRENCY_EXCHANGE_SERVICE_URL = @"https://api.exchangeratesapi.io/latest";
        private readonly IMemoryCache _cache;

        public CurrencyController(ILogger<CurrencyController> logger,
            IHttpClientFactory clientFactory,
            IMemoryCache cache)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _cache = cache;
        }

        [HttpGet]
        public IEnumerable<Model.Currency> Currencies()
        {
            var _currencies = _cache.Get<IEnumerable<Model.Currency>>("CURRENCIES");

            if (_currencies == null)
            {
                var allFile = System.IO.File.ReadAllText("AppData/currencies.json");
                _currencies = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Model.Currency>>(allFile);
                _cache.Set("CURRENCIES", _currencies);
            }
            return _currencies;
        }

        [HttpGet("Exchanges/{source}/{target}")]
        public async Task<ExchangeModel> ExchangeRatesBySourceAndTarget(string source, string target)
        {
            source = source?.ToUpper();
            target = target?.ToUpper();
            // Check source and target currency codes are valid
            var currencies = Currencies();
            if (!(currencies.Any(x => x.Code.Equals(source)) && currencies.Any(x => x.Code.Equals(target))))
            {
                _logger.LogError("Source or Target currency invalid!");
                throw new ArgumentException("Source or Target currency invalid");
            }

            var requestUrl = "?base=" + source + "&symbols=" + target;

            if (_cache.TryGetValue(requestUrl, out ExchangeModel responseRate))
            {
                return responseRate;
            }
            string cron = "0 16 * * 1-5"; // Every weekday at 16.00 pm
            var expiryDate = CronHelper.FindNextUpdateTime(DateTime.Now, cron);
            var request = new HttpRequestMessage(HttpMethod.Get, BASE_CURRENCY_EXCHANGE_SERVICE_URL + requestUrl);

            using (var client = _clientFactory.CreateClient())
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStringAsync();

                    var jo = JObject.Parse(responseStream);
                    var currencyRate = jo["rates"][target].ToString();
                    var updateDate = jo["date"].ToString();
                    var exchange = new ExchangeModel
                    {
                        SourceCurrency = source,
                        TargetCurrency = target,
                        ExchangeRate = (decimal)double.Parse(currencyRate),
                        Date = DateTime.Parse(updateDate)
                    };
                    _logger.LogInformation("Exchange information read successful!", exchange);
                    _cache.Set(requestUrl, exchange, expiryDate);
                    return exchange;
                }
                else
                {
                    _logger.LogError("Exchange rates cannot be read!", response.StatusCode);
                }
            }
            return default;
        }
    }
}
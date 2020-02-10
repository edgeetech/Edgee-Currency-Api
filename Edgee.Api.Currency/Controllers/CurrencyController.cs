using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Edgee.Api.Currency.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Edgee.Api.Currency.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private IEnumerable<Model.Currency> _currencies;

        public CurrencyController(ILogger<CurrencyController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IEnumerable<Model.Currency> Currencies()
        {
            if (_currencies == null)
            {
                var allFile = System.IO.File.ReadAllText("AppData/currencies.json");
                _currencies = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Model.Currency>>(allFile);
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

            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.exchangeratesapi.io/latest?base=" + source + "&symbols=" + target);

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
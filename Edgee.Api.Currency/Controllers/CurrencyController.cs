using System;
using System.Collections.Generic;
using Edgee.Api.Currency.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Edgee.Api.Currency.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ILogger<CurrencyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CurrencyModel> Currencies()
        {
            return new List<CurrencyModel>
            {
                new CurrencyModel { Code = "TRY", Name = "Turkish Lira", Symbol = "₺", SymbolNative = "₺" },
                new CurrencyModel { Code = "USD", Name = "US Dollar", Symbol = "$", SymbolNative = "$" },
                new CurrencyModel { Code = "GBP", Name = "Pound", Symbol = "£", SymbolNative = "£" },
                new CurrencyModel { Code = "EUR", Name = "Euro", Symbol = "€", SymbolNative = "€" }
            };
        }

        [HttpGet("Exchanges")]
        public IEnumerable<ExchangeModel> Exchanges()
        {
            return new List<ExchangeModel>
            {
                new ExchangeModel { SourceCurrency = "GBP", TargetCurrency = "TRY", ExchangeRate = 7.75m },
                new ExchangeModel { SourceCurrency = "USD", TargetCurrency = "TRY", ExchangeRate = 5.95m },
                new ExchangeModel { SourceCurrency = "EUR", TargetCurrency = "TRY", ExchangeRate = 6.57m }
            };
        }

        [HttpGet("Exchanges/{source}/{target}")]
        public ExchangeModel ExchangeRatesBySourceAndTarget(string source, string target)
        {
            // Read from cache
         
            // Check source and target currency codes are valid

            return new ExchangeModel
            {
                SourceCurrency = source,
                TargetCurrency = target,
                ExchangeRate = new decimal(new Random().NextDouble())
            };
        }
    }
}
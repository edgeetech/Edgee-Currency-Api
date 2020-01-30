using Edgee.Api.Currency.Controllers;
using System;
using Xunit;

namespace Edgee.Test.Api.Currency
{
    public class ApiCurrencyTests
    {
        private CurrencyController _currencyController;

        public ApiCurrencyTests()
        {
            _currencyController = new CurrencyController(null);
        }

        [Fact]
        public void Test_CurrencyController_GetAllCurrencies_ReturnsAll()
        {
            // Run
            var result = _currencyController.Currencies();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Test_CurrencyController_GetAllExchanges_ReturnsAll()
        {
            // Run
            var result = _currencyController.Exchanges();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}

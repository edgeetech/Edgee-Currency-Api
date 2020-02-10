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
            _currencyController = new CurrencyController(new FakeLogger(), new FakeHttpClientFactory());
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
        public async void Test_CurrencyController_ExchangeRatesBySourceAndTarget_ReturnsExchangeRate_ForValidCurrencies()
        {
            // Arrange
            var VALID_CURRENCYCODE = "TRY";
            var VALID_CURRENCYCODE_2 = "GBP";

            // Run
            var result = await _currencyController.ExchangeRatesBySourceAndTarget(VALID_CURRENCYCODE, VALID_CURRENCYCODE_2);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(result.ExchangeRate, decimal.Zero);
        }

        [Fact]
        public void Test_CurrencyController_ExchangeRatesBySourceAndTarget_ThrowsArgumentException_ForInValidCurrencies()
        {
            // Arrange
            string INVALID_CURRENCYCODE = null;

            // Run & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _currencyController.ExchangeRatesBySourceAndTarget(INVALID_CURRENCYCODE, INVALID_CURRENCYCODE));

            INVALID_CURRENCYCODE = string.Empty;
            Assert.ThrowsAsync<ArgumentException>(() => _currencyController.ExchangeRatesBySourceAndTarget(INVALID_CURRENCYCODE, INVALID_CURRENCYCODE));

            INVALID_CURRENCYCODE = "XWZ";
            Assert.ThrowsAsync<ArgumentException>(() => _currencyController.ExchangeRatesBySourceAndTarget(INVALID_CURRENCYCODE, INVALID_CURRENCYCODE));
        }
    }
}

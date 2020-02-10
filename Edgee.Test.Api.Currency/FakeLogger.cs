using Edgee.Api.Currency.Controllers;
using Microsoft.Extensions.Logging;
using System;

namespace Edgee.Test.Api.Currency
{
    public class FakeLogger : ILogger<CurrencyController>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return default;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine("Log executed {0}", logLevel);
        }
    }
}

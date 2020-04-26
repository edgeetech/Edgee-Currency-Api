using System;

namespace Edgee.Api.Currency.Model
{
    public class Exchange
    {
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime Date { get; set; }
    }
}

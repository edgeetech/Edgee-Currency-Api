namespace Edgee.Api.Currency.Model
{
    public class ExchangeModel
    {
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public decimal ExchangeRate { get; set; }

    }
}

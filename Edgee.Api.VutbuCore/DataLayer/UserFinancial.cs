using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edgee.Api.VutbuCore.DataLayer
{
    public class UserFinancial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserFinancialId { get; set; }

        [Required]
        public int UserId { get; set; }
        [MaxLength(250)]
        [Required]
        public string IBAN { get; set; }
        [MaxLength(10)]
        public string CurrencyCode { get; set; }
        [MaxLength(20)]
        public string SortCode { get; set; }
        [MaxLength(20)]
        public string AccountNumber { get; set; }
    }
}

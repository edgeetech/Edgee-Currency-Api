using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edgee.Api.VutbuCore.DataLayer
{
    public class UserContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserContactId { get; set; }

        [Required]
        public int UserId { get; set; }
        [MaxLength(250)]
        [Required]
        public string EmailAddress { get; set; }
        [MaxLength(20)]
        public string RegionCode { get; set; }
        [MaxLength(20)]
        public string TelephoneNumber { get; set; }
        [MaxLength(20)]
        public string PostCode { get; set; }
    }
}

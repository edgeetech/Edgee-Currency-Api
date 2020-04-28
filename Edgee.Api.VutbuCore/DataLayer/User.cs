using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edgee.Api.VutbuCore.DataLayer
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }
        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Surname { get; set; }
        [MaxLength(250)]
        public string ProfilePhoto { get; set; }

        public List<UserContact> UserContacts { get; set; }
        public List<UserGroup> UserGroups { get; set; }
        public UserFinancial UserFinancial { get; set; }
    }
}

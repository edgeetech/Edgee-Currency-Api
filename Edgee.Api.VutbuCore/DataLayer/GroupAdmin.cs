using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edgee.Api.VutbuCore.DataLayer
{
    public class GroupAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupAdminId { get; set; }

        [Required]
        public int GroupId { get; set; }
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
    }
}

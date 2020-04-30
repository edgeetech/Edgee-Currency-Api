using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edgee.Api.VutbuCore.DataLayer
{
    public class UserGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserGroupId { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public int GroupId { get; set; }

        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
    }
}

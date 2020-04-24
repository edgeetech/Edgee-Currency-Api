using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edgee.Api.Dictionary.Model
{
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageId { get; set; }
        [MaxLength(20)]
        [Required]
        public string LanguageCode { get; set; }

        public List<DictionaryItem> DictionaryItems { get; set; }
    }
}

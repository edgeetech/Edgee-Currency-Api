using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edgee.Api.Dictionary.Model
{
    public class DictionaryItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DictionaryItemId { get; set; }
        public int LanguageId { get; set; }
        [MaxLength(100)]
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }

        public Language Language { get; set; }
    }
}

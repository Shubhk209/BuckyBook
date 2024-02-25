using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuckyBookModels
{
    public class CoverType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name="Cover Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

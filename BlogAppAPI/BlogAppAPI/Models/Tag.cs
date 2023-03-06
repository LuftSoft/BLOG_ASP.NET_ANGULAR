using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAppAPI.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }
        [Required]
        [StringLength(50)]
        public string TagName { get; set; }
        [Column(TypeName = "ntext")]
        public string? TagDescription { get; set; }
    }
}

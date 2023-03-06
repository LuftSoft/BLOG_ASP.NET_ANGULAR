using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAppAPI.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        [StringLength(50)]
        public string AuthorName { get; set; }
        [Column(TypeName = "ntext")]
        public string AuthorDescription { get; set; }
        [StringLength (50)]
        public string AuthorSlug { get; set; }
        public DateTime AuthorCreateDate { get; set; } = DateTime.Now;
        public string? AuthorAddress { get; set;}
        [StringLength(15)]
        public string? AuthorPhone { get; set; }
        [StringLength(150)]
        public string? AuthorEmail { get; set; }

        public string? AuthorSkill { get; set; }

        public string? CustomUserId { get; set; }
        [ForeignKey("CustomUserId")]
        public CustomUser? CustomUser { get; set; }
    }
}

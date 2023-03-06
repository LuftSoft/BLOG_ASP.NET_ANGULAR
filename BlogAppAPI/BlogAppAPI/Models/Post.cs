using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAppAPI.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        [Required]
        [StringLength(500)]
        public string PostTitle { get; set; }
        [Column(TypeName = "ntext")]
        public string PostDescription { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string PostContent { get; set; }
        [Required]
        [StringLength(200)]
        public string PostSlug { get; set; }
        public DateTime CreateDate { set; get; } = DateTime.Now;
        public DateTime UpdateDate { set; get; } = DateTime.Now;

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
        public List<PostTag>? PostTags { set; get; }
        public List<PostCategory>? PostCategories { set; get; }

    }
}

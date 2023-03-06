namespace BlogAppAPI.Models
{
    public class PostCategory
    {
        public int PostId { set; get; }
        public int CategoryId { set; get; } 
        public Post Post { set; get; }
        public Category Category { set; get; }
    }
}

﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAppAPI.Models
{
    [Table("PostTag")]
    public class PostTag
    {   

        public int PostId { get; set; } 
        public int TagId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}

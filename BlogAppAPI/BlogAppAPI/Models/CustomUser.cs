using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAppAPI.Models
{
    public class CustomUser : IdentityUser
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(500)]
        public string UserAdress { set; get; }
    }
}

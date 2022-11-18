using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab2Web.Models
{
    public class User
    {
        [Key]
        //[DisplayName("Id")]
        //[Range(1,100, ErrorMessage="Id is out of range!")]
        public int UserId { get; set; }
        public string? Password { get; set; }
        [Required]
        [DisplayName("Name")]
        public string UserName { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public int Authority { get; set; } 

    }
}

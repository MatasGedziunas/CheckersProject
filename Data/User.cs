using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckersProject.Data
{
    public class User
    {
        [Key]
        
        public int Id { get; set; }
        [MinLength(5), MaxLength(15)]
        
        public string Username { get; set; }
        [PasswordPropertyText]
        [MinLength(5), MaxLength(15)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, and one digit.")]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}

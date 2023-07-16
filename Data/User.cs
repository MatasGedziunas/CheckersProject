using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CheckersProject.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        [PasswordPropertyText]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}

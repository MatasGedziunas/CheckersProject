
using System.ComponentModel.DataAnnotations;

namespace CheckersProject.Data
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string WhiteUserId { get; set; }
        public string BlackUserId { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckersProject.Data
{
    public class Move
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MoveNumber { get; set; }
        [Required]
        public int FromCell { get; set; }
        [Required]
        public int ToCell { get; set; }
        [Required]
        public int PieceId { get; set; }

        public Move()
        {

        }

    }
}

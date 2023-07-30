using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckersProject.Models
{
    public class Piece
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public teamColour team { get; set; } // "white" or "black"
        
        public pieceType pieceType { get; set; }

        public Piece(teamColour team, pieceType pieceType)
        {
            this.team = team;
            this.pieceType = pieceType;
        }
    }

   
}

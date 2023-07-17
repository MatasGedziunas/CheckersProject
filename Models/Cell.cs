using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckersProject.Models
{
    public class Cell
    {
        [Key]

        public int id { get; set; }
        public int x { get; private set; }
        public int y { get; private set; }
        public teamColour colour { get; }
        public int index { get; }
        
        public int? pieceId { get; set; }

        [ForeignKey("pieceId")]
        public Piece? piece { get; set; } = null;

        [NotMapped]
        public List<int> possibleMoves { get; set; }

        public Cell()
        {
            possibleMoves = new List<int>();
        }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            index = y * 10 + x;
            if ((x + y) % 2 == 0)
            {
                colour = teamColour.black;
            }
            else
            {
                colour = teamColour.white;
            }
            possibleMoves = new List<int>();
        }        
    }
   
}

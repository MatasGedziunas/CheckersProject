namespace CheckersProject.Models
{
    public class Piece
    {     
        public string team { get; set; } // "white" or "black"

        public Piece(string team)
        {
            this.team = team;
        }
    }
}

namespace CheckersProject.Models
{
    public class Cell
    {
        public int x { get; }
        public int y { get; }
        public string colour { get; }
        public int index { get; }    

        public List<Cell> possibleMoves { get; set; }

        public Piece? piece { get; set; } = null;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
            index = y * 10 + x;
            if((x+y)%2 == 0)
            {
                colour = "black";
            }
            else
            {
                colour = "white";
            }
            possibleMoves = new List<Cell>();
        }

       
    }
}

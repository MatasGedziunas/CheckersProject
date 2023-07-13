using Microsoft.AspNetCore.SignalR;

namespace CheckersProject.Models
{
    public class Board
    {
        public const int XAXISLENGHT = 10;
        public const int YAXISLENGHT = 10;
        public List<Cell> cells { get; } = new List<Cell>();
        public Board()
        {
            for (int y = 0; y < XAXISLENGHT; y++)
            {
                for (int x = 0; x < YAXISLENGHT; x++)
                {
                    Cell cell = new Cell(x, y);
                    if (y <= 3 && cell.colour == "black")
                    {
                        cell.piece = new Piece("black");
                    }
                    else if (y >= 6 && cell.colour == "black")
                    {
                        cell.piece = new Piece("white");
                    }
                    cells.Add(cell);
                }
            }
            SetPossibleMovesForAllCells();
        }


        //---------------------------------------
        //-----HELPER FUNCTIONS BOARD LOGIC------
        //---------------------------------------        

        public void SetPossibleMovesForAllCells()
        {
            foreach(var cell in cells)
            {
                if(cell.piece != null)
                {
                    SetPossibleMovesFromCell(cell);
                }
                
            }
        }

        public void SetPossibleMovesFromCell(Cell cell)
        {
            cell.possibleMoves = PossibleMovesFromCell(cell);
        }


        /// <summary>
        /// Given coordinates of a cell, get where a piece on that cell can move to
        /// </summary>
        /// <param name="cell">cell to get possible moves from</param>
        /// <returns>A list of cells where to piece can move to</returns>
        public List<Cell> PossibleMovesFromCell(Cell cell)
        {
            if(cell.piece == null)
            {
                throw new InvalidDataException();
            }
            List<Cell> possibleMoves = new List<Cell>();
            int directionToCheckForPossibleMoves = cell.piece.team == "white" ? -1 : 1;
            Queue<Cell> possibleMovesQueue = PopulatePossibleMoveStackWithStartCells(cell, directionToCheckForPossibleMoves);
            Cell cur = possibleMovesQueue.Dequeue();
            while (cur != null)
            {
                if (CoordinatesInBounds(cur.x, cur.y) && cur.piece == null && cur.colour == "black")
                {
                    possibleMoves.Add(cur);
                }
                if (possibleMovesQueue.Count > 0)
                {
                    cur = possibleMovesQueue.Dequeue();
                }
                else
                {
                    cur = null;
                }
            }
            return possibleMoves;
        }

        private Queue<Cell> PopulatePossibleMoveStackWithStartCells(Cell cell, int directionToCheckForPossibleMoves)
        {
            Queue<Cell> possibleMovesQueue = new Queue<Cell>();
            Cell leftCell = GetCellFromCoordinates(cell.x - 1, cell.y + directionToCheckForPossibleMoves);
            Cell rightCell = GetCellFromCoordinates(cell.x + 1, cell.y + directionToCheckForPossibleMoves);
            possibleMovesQueue.Enqueue(leftCell);
            possibleMovesQueue.Enqueue(rightCell);
            return possibleMovesQueue;
        }

        private Cell GetCellFromCoordinates(int x, int y)
        {
            return cells[y * 10 + x];
        }

        private bool CoordinatesInBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < XAXISLENGHT && y < YAXISLENGHT;
        }

    }
}

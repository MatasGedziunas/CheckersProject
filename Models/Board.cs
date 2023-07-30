using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CheckersProject.Models
{
    public class Board
    {
        [NotMapped]
        public const int XAXISLENGHT = 10;
        [NotMapped]
        public const int YAXISLENGHT = 10;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }
        public List<Cell> Cells { get; } = new List<Cell>();
        public Board()
        {
            for (int y = 0; y < XAXISLENGHT; y++)
            {
                for (int x = 0; x < YAXISLENGHT; x++)
                {
                    Cell cell = new Cell(x, y);
                    if (y <= 3 && cell.colour == teamColour.black)
                    {
                        Piece piece = new Piece(teamColour.black, pieceType.checker);
                        cell.piece = piece;
                        cell.pieceId = piece.Id;
                        
                    }
                    else if (y >= 6 && cell.colour == teamColour.black)
                    {
                        Piece piece = new Piece(teamColour.white, pieceType.checker);
                        cell.piece = piece;
                        cell.pieceId = piece.Id;
                    }
                    Cells.Add(cell);
                }
            }
            SetPossibleMovesForAllCells();
        }

        public void PrintBoard()
        {
            Cell prev = Cells[0];
            for(int i = 1; i < Cells.Count; i++)
            {
                if(prev.y != Cells[i].y)
                {
                    Debug.WriteLine("");
                }
                Debug.Write($" {(Cells[i].piece != null ? 1 : 0)}");
                prev = Cells[i];
            }
        }

        //---------------------------------------
        //-----HELPER FUNCTIONS BOARD LOGIC------
        //---------------------------------------        

        public void SetPossibleMovesForAllCells()
        {
            foreach(var cell in Cells)
            {
                if(cell.piece != null)
                {
                    SetPossibleMovesFromCell(cell.index);
                }
                
            }
        }

        public void SetPossibleMovesFromCell(int index)
        {

            Cells[index].possibleMoves = PossibleMovesFromCell(index);
        }


        /// <summary>
        /// Given coordinates of a cell, get where a piece on that cell can move to
        /// </summary>
        /// <param name="cell">cell to get possible moves from</param>
        /// <returns>A list of cells where to piece can move to</returns>
        public List<int> PossibleMovesFromCell(int index)
        {
            Cell cell = Cells[index];
            if(cell.piece == null)
            {
                throw new InvalidDataException();
            }
            List<Cell> possibleMoves = new List<Cell>();
            int directionToCheckForPossibleMoves = cell.piece.team == teamColour.white ? -1 : 1;
            Queue<Cell> possibleMovesQueue = PopulatePossibleMoveStackWithStartCells(cell, directionToCheckForPossibleMoves);
            Cell cur = possibleMovesQueue.Dequeue();
            while (cur != null)
            {
                if (CoordinatesInBounds(cur.x, cur.y) && cur.piece == null && cur.colour == teamColour.black)
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
            return possibleMoves.Select(x => x.index).ToList();
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
            return Cells[y * 10 + x];
        }

        private bool CoordinatesInBounds(int x, int y)
        {
            return x >= 0 && y >= 0 && x < XAXISLENGHT && y < YAXISLENGHT;
        }

        //------------------MOVEMENT-----

        

    }
}

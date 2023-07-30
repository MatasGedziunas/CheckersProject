using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CheckersProject;
using CheckersProject.Data;
using CheckersProject.Models;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authorization;
using System.IO.Pipelines;

namespace CheckersProject.Controllers
{
    public class GamesController : Controller
    {
        private readonly DBContext _context;

        public GamesController(DBContext context)
        {
            _context = context;
        }

        


        // GET: Games
        public async Task<IActionResult> Index()
        {
              return _context.Games != null ? 
                          View(await _context.Games.ToListAsync()) :
                          Problem("Entity set 'DBContext.Games'  is null.");
        }

        [Authorize]
        public IActionResult Details(int gameId)
        {
            return View("Match", GetGameBoard(gameId));
        }

        [Authorize]                
        public async Task<IActionResult> Create(int userId)
        {
            int gameId = await CreateGame(userId);
            return View("Match", GetGameBoard(gameId));
        }
        private async Task<int> CreateGame(int userId)
        {
            Game game = new Game();
            game.SetUserColour(userId);
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        private Board GetLastBoard(int gameId)
        {
            return new Board();
        }
       
        private Game GetGame(int gameId)
        {
            return _context.Games.First(g => g.Id == gameId);
        }

        private Board GetGameBoard(int gameId)
        {
            List<Move> gameMoves = GetGameMoves(gameId);
            Board board = new Board();
            board.GameId = gameId;
            foreach(Move move in gameMoves)
            {
                PlayMove(board, move);
            }
            board.PrintBoard();
            return board;
        }

        private void PlayMove(Board board, Move move)
        {
            Piece temp = board.Cells[move.FromCell].piece;
            board.Cells[move.FromCell].piece = board.Cells[move.ToCell].piece;
            board.Cells[move.ToCell].piece = temp;
        }

        private List<Move> GetGameMoves(int gameId)
        {
            return _context.Moves.Where(move => move.GameId == gameId).ToList();
        }
        
        [Authorize]
        public void MakeMove(int indexFrom, int indexTo, int gameId, int userId)
        {          
            
            // Save the changes to the database
            AddMoveToDatabase(indexFrom, indexTo, userId, gameId);
            _context.SaveChanges();
        }

        public void MovePiece(int indexFrom, int indexTo, Board board)
        {
            List<Cell> gameCells = board.Cells;
            Piece? temp = gameCells[indexFrom].piece;
            gameCells[indexFrom].piece = null;
            gameCells[indexTo].piece = temp;
            // Save the changes to the database
            _context.SaveChanges();
        }




        [Authorize]
        public void AddMoveToDatabase(int indexFrom, int indexTo, int userId, int gameId)
        {
            Move move = new Move()
            {
                GameId = gameId,
                UserId = userId,
                MoveNumber = GetLastMoveNumberForGame(gameId),
                FromCell = indexFrom,
                ToCell = indexTo,
            };
            _context.Moves.Add(move);
        }
        private int GetLastMoveNumberForGame(int gameId)
        {
            return _context.Moves
                .OrderBy(move => move.MoveNumber)
                .LastOrDefault(move => move.GameId == gameId)?.MoveNumber + 1 ?? 1;
        }

        public List<int> GetPossibleMoves(int index, int gameId)
        {
            System.Diagnostics.Debug.WriteLine($"indexas: {index}");
            Board board = GetLastBoard(gameId);
            board.PossibleMovesFromCell(index).ForEach(x => System.Diagnostics.Debug.WriteLine(x));
            return board.PossibleMovesFromCell(index);
        }

       
    }
}

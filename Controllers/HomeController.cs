using CheckersProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CheckersProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Board board = new Board();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(board);
        }

        public void MakeMove(int indexFrom, int indexTo)
        {
            board.MovePiece(indexFrom, indexTo);
            board.PrintBoard();
        }

        public List<int> GetPossibleMoves(int index)
        {
            System.Diagnostics.Debug.WriteLine($"indexas: {index}");
            board.PossibleMovesFromCell(index).ForEach(x => System.Diagnostics.Debug.WriteLine(x));
            return board.PossibleMovesFromCell(index);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
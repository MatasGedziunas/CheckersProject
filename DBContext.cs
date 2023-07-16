using CheckersProject.Data;
using CheckersProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckersProject
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Cell> Cells { get; set; }  
        public DbSet<Board> Boards { get; set; }

        public DbSet<Piece> Pieces { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Addtional info
        }
    }
}

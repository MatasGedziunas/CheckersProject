using CheckersProject.Models;
using Humanizer.Localisation.TimeToClockNotation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckersProject.Data
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int? WhiteUserId { get; set; } = -1;

        [Column(TypeName = "int")]
        public int? BlackUserId { get; set; } = -1;
        public List<Move> Moves { get; set; }


        public Game()
        {
            Moves = new List<Move>();
        }
        public void SetUserColour(int userId)
        {
            if(IsWhiteUserColourSet())
            {
                BlackUserId = userId;
            }
            else if(IsBlackUserColourSet())
            {
                WhiteUserId = userId;
            }
            else
            {
                bool creatorSideWhite = new Random().Next(-1, 2) == 0;
                if (creatorSideWhite)
                {
                    WhiteUserId = userId;
                }
                else
                {
                    BlackUserId = userId;
                }
            }
            
        }
        public bool IsWhiteUserColourSet()
        {
            return WhiteUserId != -1;
        }
        public bool IsBlackUserColourSet()
        {
            return BlackUserId != -1;
        }
        
    }
}

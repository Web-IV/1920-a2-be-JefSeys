using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Models
{
    public class Game
    {
        [Required]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        public double Price { set; get; }
        public string Description { set; get; }
        public int Rating { set; get; }

        public Game()
        {
        }
    }
}

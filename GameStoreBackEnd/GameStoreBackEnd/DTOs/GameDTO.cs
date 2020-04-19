using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.DTOs
{
    public class GameDTO
    {
        [Required]
        public string Name { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        public int Rating { set; get; }
    }
}

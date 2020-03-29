using GameStoreBackEnd.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameContext _context;
        private readonly DbSet<Game> _games;

        public GameRepository(GameContext context)
        {
            _context = context;
            _games = context.Games;
        }
        public IEnumerable<Game> GetAll()
        {
            return _games.ToList();
        }
    }
}

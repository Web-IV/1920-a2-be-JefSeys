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

        public Game GetBy(int id)
        {
            return _games.SingleOrDefault(g => g.Id == id);
        }

        public bool TryGetGame(int id, out Game game)
        {
            game = _context.Games.FirstOrDefault(g => g.Id == id);
            return game != null;
        }

        public void Add(Game game)
        {
            _games.Add(game);
        }

        public IEnumerable<Game> GetBy(string name = null)
        {
            throw new NotImplementedException();
        }

        public void Delete(Game game)
        {
            _games.Remove(game);
        }

        public void Update(Game game)
        {
            _context.Update(game);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

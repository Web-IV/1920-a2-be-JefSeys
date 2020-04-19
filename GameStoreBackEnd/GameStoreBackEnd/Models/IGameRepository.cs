using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Models
{
    public interface IGameRepository
    {
        Game GetBy(int id);
        bool TryGetGame(int id, out Game game);
        IEnumerable<Game> GetAll();
        IEnumerable<Game> GetBy(string name = null);
        void Add(Game game);
        void Delete(Game game);
        void Update(Game game);
        void SaveChanges();
    }
}

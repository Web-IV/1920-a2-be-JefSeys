using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Data
{
    public class GameDataInitializer
    {

        private readonly GameContext _context;

        public GameDataInitializer(GameContext context)
        {
            _context = context;
        }

        public void InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                //seeding the database with games, see DBContext               
            }
        }
    }
}

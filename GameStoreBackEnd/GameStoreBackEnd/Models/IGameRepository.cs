using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Models
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
    }
}

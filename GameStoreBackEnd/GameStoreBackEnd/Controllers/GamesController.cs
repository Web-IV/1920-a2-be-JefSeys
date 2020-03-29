using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStoreBackEnd.Data.Repositories;
using GameStoreBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;

        public GamesController(IGameRepository context)
        {
            _gameRepository = context;
        }

        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            return _gameRepository.GetAll();
        }
    }
}
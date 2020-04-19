using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStoreBackEnd.Data.Repositories;
using GameStoreBackEnd.DTOs;
using GameStoreBackEnd.Models;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public IEnumerable<Game> GetGames()
        {
            return _gameRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGame(int id)
        {
            Game game = _gameRepository.GetBy(id);
            if (game == null) return NotFound();
            return game;
        }

        [HttpPost]
        public ActionResult<Game> PostRecipe(GameDTO game)
        {
            Game gameToCreate = new Game() { Name = game.Name, Price = game.Price, Description = game.Description, Rating = game.Rating };
            _gameRepository.Add(gameToCreate);
            _gameRepository.SaveChanges();

            return CreatedAtAction(nameof(GetGame), new { id = gameToCreate.Id }, gameToCreate);
        }

        [HttpPut("{id}")]
        public IActionResult PutRecipe(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }
            _gameRepository.Update(game);
            _gameRepository.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            Game game = _gameRepository.GetBy(id);
            if (game == null)
            {
                return NotFound();
            }
            _gameRepository.Delete(game);
            _gameRepository.SaveChanges();
            return NoContent();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using GameStoreBackEnd.Data.Repositories;
using GameStoreBackEnd.DTOs;
using GameStoreBackEnd.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreBackEnd.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [AllowAnonymous]
        public ActionResult<Game> GetGame(int id)
        {
            Game game = _gameRepository.GetBy(id);
            if (game == null) return NotFound();
            return game;
        }

        //[Authorize(Policy = "ADMIN")]
        [HttpPost]
        public ActionResult<Game> PostGame(Game game)
        {
            //Game gameToCreate = new Game() { Name = game.Name, Price = game.Price, Description = game.Description, Rating = game.Rating, Base64Img = base64 };
            _gameRepository.Add(game);
            _gameRepository.SaveChanges();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        //[Authorize(Policy = "ADMIN")]
        [HttpPut("{id}")]
        public IActionResult PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }
            _gameRepository.Update(game);
            _gameRepository.SaveChanges();
            return NoContent();
        }


        //[Authorize(Policy = "ADMIN")]
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
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
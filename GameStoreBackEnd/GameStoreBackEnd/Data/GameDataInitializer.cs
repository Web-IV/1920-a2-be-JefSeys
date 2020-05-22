using GameStoreBackEnd.Data;
using GameStoreBackEnd.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Data
{
    public class GameDataInitializer
    {
        private readonly GameContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public GameDataInitializer(GameContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with recipes, see DBContext         
                Customer admin = new Customer { Email = "jef.seys@gmail.be", FirstName = "Jef", LastName = "Seys", Type = "ADMIN" };
                _dbContext.Customers.Add(admin);
                await CreateUser(admin.Email, "P@ssword1111", "ADMIN");


                Customer gebruiker = new Customer { Email = "brandon.gomes@gmail.com", FirstName = "Brandon", LastName = "Gomes", Type = "GEBRUIKER" };
                _dbContext.Customers.Add(gebruiker);
                await CreateUser(gebruiker.Email, "P@ssword1111", "GEBRUIKER");


                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string password, string type)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimsAsync(user, new List<Claim>() { new Claim(ClaimTypes.Role, type) });
        }
    }
}


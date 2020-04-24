using GameStoreBackEnd.Data;
using GameStoreBackEnd.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
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
                Customer customer = new Customer { Email = "jef.seys@gmail.be", FirstName = "Jef", LastName = "Seys", Type = "ADMIN" };
                _dbContext.Customers.Add(customer);
                await CreateUser(customer.Email, "P@ssword1111");
                Customer student = new Customer { Email = "brandon.gomes@gmail.com", FirstName = "Jef", LastName = "Seys", Type = "GEBRUIKER" };
                _dbContext.Customers.Add(student);
                await CreateUser(student.Email, "P@ssword1111");
                _dbContext.SaveChanges();
            }
        }

        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}


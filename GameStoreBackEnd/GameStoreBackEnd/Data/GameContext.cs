using GameStoreBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Data
{
    public class GameContext: DbContext
    {
        public DbSet<Game> Games { set; get; }
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Game>().Property(g => g.Id).IsRequired();
            builder.Entity<Game>().Property(g => g.Name).IsRequired();
            builder.Entity<Game>().Property(g => g.Price);
            builder.Entity<Game>().Property(g => g.Description);
            builder.Entity<Game>().Property(g => g.Rating);


            builder.Entity<Game>().HasData(
                 new Game { Id = 1, Name = "Factorio", Price = 25.00, Description = "Factorio is a game in which you build and maintain factories. You will be mining resources, researching technologies, building infrastructure, automating production and fighting enemies. In the beginning you will find yourself chopping trees, mining ores and crafting mechanical arms and transport belts by hand, but in short time you can become an industrial powerhouse, with huge solar fields, oil refining and cracking, manufacture and deployment of construction and logistic robots, all for your resource needs. However this heavy exploitation of the planet's resources does not sit nicely with the locals, so you will have to be prepared to defend yourself and your machine empire.", Rating = 5 },
                 new Game { Id = 2, Name = "Rocket League", Price = 9.99, Description = "Rocket League is a high-powered hybrid of arcade-style soccer and vehicular mayhem with easy-to-understand controls and fluid, physics-driven competition. Rocket League includes casual and competitive Online Matches, a fully-featured offline Season Mode, special “Mutators” that let you change the rules entirely, hockey and basketball-inspired Extra Modes, and more than 500 trillion possible cosmetic customization combinations.", Rating = 4 },
                 new Game { Id = 3, Name = "Test via databank", Price = 20, Description = "Test description", Rating = 4 }
                 );
        }
    }
}

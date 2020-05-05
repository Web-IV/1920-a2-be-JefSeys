using GameStoreBackEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Data
{
    public class GameContext: IdentityDbContext//<IdentityUser>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Customer> Customers { get; set; }

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

            builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Entity<Customer>().Property(c => c.Type).IsRequired();
            builder.Entity<Customer>().HasMany(c => c.Games).WithOne().OnDelete(DeleteBehavior.Restrict);

            System.IO.FileStream fs1 = new FileStream(@"../GameStoreBackEnd/Images/Factorio.jpg", FileMode.Open);
            System.IO.BufferedStream bf1 = new BufferedStream(fs1);
            byte[] buffer1 = new byte[bf1.Length];
            bf1.Read(buffer1, 0, buffer1.Length);
            string img1 = "data:image/jpeg;base64," + Convert.ToBase64String(buffer1);

            System.IO.FileStream fs2 = new FileStream(@"../GameStoreBackEnd/Images/Rocket League.jpg", FileMode.Open);
            System.IO.BufferedStream bf2 = new BufferedStream(fs2);
            byte[] buffer2 = new byte[bf2.Length];
            bf2.Read(buffer2, 0, buffer2.Length);
            string img2 = "data:image/jpeg;base64," + Convert.ToBase64String(buffer2);

            System.IO.FileStream fs3 = new FileStream(@"../GameStoreBackEnd/Images/The division.jpg", FileMode.Open);
            System.IO.BufferedStream bf3 = new BufferedStream(fs3);
            byte[] buffer3 = new byte[bf3.Length];
            bf3.Read(buffer3, 0, buffer3.Length);
            string img3 = "data:image/jpeg;base64," + Convert.ToBase64String(buffer3);

            System.IO.FileStream fs4 = new FileStream(@"../GameStoreBackEnd/Images/GTA5.jpg", FileMode.Open);
            System.IO.BufferedStream bf4 = new BufferedStream(fs4);
            byte[] buffer4 = new byte[bf4.Length];
            bf4.Read(buffer4, 0, buffer4.Length);
            string img4 = "data:image/jpeg;base64," + Convert.ToBase64String(buffer4);

            System.IO.FileStream fs5 = new FileStream(@"../GameStoreBackEnd/Images/Assassin's creed.jpg", FileMode.Open);
            System.IO.BufferedStream bf5 = new BufferedStream(fs5);
            byte[] buffer5 = new byte[bf5.Length];
            bf5.Read(buffer5, 0, buffer5.Length);
            string img5 = "data:image/jpeg;base64," + Convert.ToBase64String(buffer5);

            System.IO.FileStream fs6 = new FileStream(@"../GameStoreBackEnd/Images/Hearts of iron 4.jpg", FileMode.Open);
            System.IO.BufferedStream bf6 = new BufferedStream(fs6);
            byte[] buffer6 = new byte[bf6.Length];
            bf6.Read(buffer6, 0, buffer6.Length);
            string img6 = "data:image/jpeg;base64," + Convert.ToBase64String(buffer6);

            System.IO.FileStream fs7 = new FileStream(@"../GameStoreBackEnd/Images/Rust.jpg", FileMode.Open);
            System.IO.BufferedStream bf7 = new BufferedStream(fs7);
            byte[] buffer7 = new byte[bf7.Length];
            bf7.Read(buffer7, 0, buffer7.Length);
            string img7 = "data:image/jpeg;base64," + Convert.ToBase64String(buffer7);

            builder.Entity<Game>().HasData(
                 new Game { Id = 1, Name = "Factorio", Price = 25.00, Description = "Factorio is a game in which you build and maintain factories.", Rating = 5, Base64Img = img1 },
                 new Game { Id = 2, Name = "Rocket League", Price = 9.99, Description = "Rocket League is a high-powered hybrid of arcade-style soccer and vehicular mayhem with easy-to-understand controls and fluid, physics-driven competition.", Rating = 4, Base64Img = img2 },
                 new Game { Id = 3, Name = "The Division", Price = 60, Description = "The Division description", Rating = 5, Base64Img = img3 },
                 new Game { Id = 4, Name = "Grand Theft Auto", Price = 60, Description = "GTA description", Rating = 5, Base64Img = img4 },
                 new Game { Id = 5, Name = "Assassin's Creed", Price = 60, Description = "Assassin's Creed description", Rating = 5, Base64Img = img5 },
                 new Game { Id = 6, Name = "Hearts Of Iron IV", Price = 60, Description = "Hearts Of Iron IV description", Rating = 5, Base64Img = img6 },
                 new Game { Id = 7, Name = "Rust", Price = 60, Description = "Rust description", Rating = 5, Base64Img = img7 }
                 );/*
            builder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Email = "admin", FirstName = "Jef", LastName = "Seys", Type = "ADMIN" },
                new Customer { CustomerId = 2, Email = "brandon", FirstName = "Brandon", LastName = "Gomes", Type = "GEBRUIKER" }
                );*/
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MobileCompany.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCompany.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Streets> Streets { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    City = "dsadsads",
                    Street = "dsqwdqdsawq"
                },
                new Address
                {
                    Id = 2,
                    City = "dsadsads",
                    Street = "dsqwdqdsawq"
                },
                new Address
                {
                    Id = 3,
                    City = "dsadsads",
                    Street = "dsqwdqdsawq"
                }
            );

            modelBuilder.Entity<PhoneNumber>().HasData(
                new PhoneNumber
                {
                    Id = 1,
                    Number = "12321321321",
                    Type = PhoneType.Home
                },
                new PhoneNumber
                {
                    Id = 2,
                    Number = "222222",
                    Type = PhoneType.Home
                },
                new PhoneNumber
                {
                    Id = 3,
                    Number = "444333444334",
                    Type = PhoneType.Home
                }
            );

            modelBuilder.Entity<Abonent>().HasData(
                new Abonent
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Иван",
                    LastName = "Женя",
                    MiddleName = "Иван",
                    Email = "ivan@example.com",
                    AddressId = 1,
                    PhoneNumberId = 1
                },
                new Abonent
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Иван",
                    LastName = "Иван",
                    MiddleName = "Иван",
                    Email = "i123van@example.com",
                    AddressId = 2,
                    PhoneNumberId = 2
                },
                new Abonent
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Иван",
                    LastName = "Иван",
                    MiddleName = "Иван",
                    Email = "iva22332n@example.com",
                    AddressId = 3,
                    PhoneNumberId = 3
                }
            );
        }

    }
}

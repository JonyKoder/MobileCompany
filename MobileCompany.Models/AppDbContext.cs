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
            // Здесь вы можете указать свое подключение к базе данных PostgreSQL
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MobileCompanyDb;Username=root;Password=myPassword");
        }
    }
}

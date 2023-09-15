using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Transport.Core.Entities.Concrete.Auth;
using Transport.Entities.Concrete;

namespace Transport.DataAccess.Concrete.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=FEHEME\SQLEXPRESS;Database=Transport;Trusted_Connection=true;Encrypt=false");

        }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Company> Companys { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

    }
}

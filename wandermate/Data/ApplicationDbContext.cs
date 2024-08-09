using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using wandermate.models;

namespace wandermate.Data
{
    public class ApplicationDbContext : DbContext
    {
        //constructor
        public ApplicationDbContext(DbContextOptions dbContextoptions)
            : base(dbContextoptions)
        {
        }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TravelPackage> TravelPackage { get; set; }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<Review> Review {get; set;}
        public DbSet<Users> Users {get; set;}
    }


}
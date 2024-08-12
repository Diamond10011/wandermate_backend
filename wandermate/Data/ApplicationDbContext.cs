using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using wandermate.Models;

namespace wandermate.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        //constructor
        public ApplicationDbContext(DbContextOptions dbContextoptions)
            : base(dbContextoptions)
        {
        }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Test> Test { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Builder.Entity<HotelBooking>()
            // .HasOne(h => h.Hotel)
            // .WithMany(hb => hb.HotelBooking)
            // .HasForeignKey(hi => hi.HotelId)
            // .OnDelete(DeleteBehavior.Restrict);

            // Builder.Entity<HotelBooking>()
            // .HasOne(h => h.Users)
            // .WithMany(hb => hb.HotelBooking)
            // .HasForeignKey(hi => hi.UsersId)
            // .OnDelete(DeleteBehavior.Restrict);

            List<IdentityRole> roles = new()
            {
                new IdentityRole {Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole {Name = "User", NormalizedName = "USER" },
            };
            builder.Entity<IdentityRole>().HasData(roles);


        }
    }

}
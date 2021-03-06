﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UberTappDeveloping.Models;

namespace UberTappDeveloping.DAL
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserBeer> UserBeers { get; set; }
        public DbSet<VenueBeer> VenueBeers { get; set; }
        public DbSet<VenueProfileImage> VenueProfileImage { get; set; }
        public DbSet<VenueImage> VenueImages { get; set; }
        public ApplicationDbContext()
            : base("UberTappDevelopingContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany(l => l.VenueLocations)
                .WithRequired(v => v.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(l => l.UserLocations)
                .WithRequired(a => a.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasRequired(u=>u.Location)
                .WithMany(l=>l.UserLocations)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.UserBeers)
                .WithRequired(b => b.BeerEnthusiast)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beer>()
                .HasMany(b => b.UserBeers)
                .WithRequired(u => u.FavouriteBeer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Venue>()
                .HasMany(v => v.VenueBeers)
                .WithRequired(b => b.Venue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beer>()
                .HasMany(b => b.VenueBeers)
                .WithRequired(v => v.AvailableBeer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VenueProfileImage>()
                .HasRequired(vp => vp.Venue)
                .WithOptional(v => v.ProfileImage);


            base.OnModelCreating(modelBuilder);
        }
    }
}
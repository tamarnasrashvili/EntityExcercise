using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<MovieActors> MovieActors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRate> UserRates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Movies
            modelBuilder.Entity<Movie>()
                .Property(e => e.Description)
                .HasMaxLength(5000)
                .IsRequired();

            modelBuilder.Entity<Movie>()
               .Property(e => e.Title)
               .HasMaxLength(500)
               .IsRequired();

            modelBuilder.Entity<Movie>()
               .HasOne(e => e.Director)
               .WithMany(e => e.Movies)
               .HasForeignKey(e => e.DirectorId)
               .OnDelete(DeleteBehavior.Restrict);

            //MovieActors
            modelBuilder.Entity<MovieActors>()
                .HasOne(e => e.Actor)
                .WithMany(e => e.MovieActors)
                .HasForeignKey(e => e.PersonId);

            modelBuilder.Entity<MovieActors>()
                .HasOne(e => e.Movie)
                .WithMany(e => e.Actors)
                .HasForeignKey(e => e.MovieId);

            //Persons
            modelBuilder.Entity<Person>()
                .Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsRequired();

            //MovieGenres
            modelBuilder.Entity<MovieGenres>()
                .HasOne(e => e.Movie)
                .WithMany(i => i.Genres)
                .HasForeignKey(f => f.MovieId);

            modelBuilder.Entity<MovieGenres>()
                .HasOne(e => e.Genre)
                .WithMany(i => i.MovieGenres)
                .HasForeignKey(f => f.GenreId);

            modelBuilder.Entity<Genre>()
                .Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired();

            //MovieRating

            modelBuilder.Entity<UserRate>()
                .HasOne(e => e.Movie)
                .WithMany(i => i.UserRates)
                .HasForeignKey(f => f.MovieId);

            modelBuilder.Entity<UserRate>()
                .HasOne(e => e.User)
                .WithMany(i => i.UserRates)
                .HasForeignKey(f => f.MovieId);

            //User
            modelBuilder.Entity<User>()
                .Property(p => p.Firstname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Lastname)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Seed();

        }
    }
}

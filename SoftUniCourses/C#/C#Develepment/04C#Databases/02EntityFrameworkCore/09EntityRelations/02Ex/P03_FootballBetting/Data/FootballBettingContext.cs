﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {

        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }




        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBookmakerSystem;Integrated Security=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder
            //    .Entity<Team>().HasOne(t => t.PrimaryKitColor)
            //    .WithMany(c => c.PrimaryKitTeams)
            //    .HasForeignKey(t => t.TeamId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Color>()
                .HasMany(c => c.SecondaryKitTeams)
                .WithOne(t => t.SecondaryKitColor)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<PlayerStatistic>()
                .HasKey(k => new { k.GameId, k.PlayerId });

            //modelBuilder
            //    .Entity<Color>().HasMany(c => c.SecondaryKitTeams)
            //    .WithOne(t => t.SecondaryKitColor)
            //    .OnDelete(DeleteBehavior.NoAction);



            base.OnModelCreating(modelBuilder);
        }

    }
}

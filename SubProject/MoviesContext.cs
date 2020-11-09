using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject
{
    public class MoviesContext : DbContext
    {
        private readonly string _connectionString;

        public MoviesContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DbSet<TitleBasics> titleBasics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For name_basics talbe
            modelBuilder.Entity<TitleBasics>().ToTable("title_basics");
            modelBuilder.Entity<TitleBasics>().Property(x => x.Id).HasColumnName("tconst");
            modelBuilder.Entity<TitleBasics>().Property(x => x.TitleType).HasColumnName("titletype");
            modelBuilder.Entity<TitleBasics>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<TitleBasics>().Property(x => x.OriginalTitle).HasColumnName("originaltitle");
            modelBuilder.Entity<TitleBasics>().Property(x => x.IsAdult).HasColumnName("isadult");
            modelBuilder.Entity<TitleBasics>().Property(x => x.StartYear).HasColumnName("startyear");
            modelBuilder.Entity<TitleBasics>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<TitleBasics>().Property(x => x.RuntimeMinutes).HasColumnName("runtimeminutes");
            modelBuilder.Entity<TitleBasics>().Property(x => x.Genres).HasColumnName("genres");

            //Need to be done more corection for other tables
        }
    }
}

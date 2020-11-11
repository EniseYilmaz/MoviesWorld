using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Scaffolding.Internal;
using SubProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        //For the string_search
        public IList<StringSearch> Search(string keyword)
        {
            var searchResult = new List<StringSearch>();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "string_search";
                command.Parameters.Add(new Npgsql.NpgsqlParameter("s", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = keyword });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Id = Convert.ToString(reader["id"]);
                        var Title = Convert.ToString(reader["title"]);

                        searchResult.Add(new StringSearch()
                        {
                            Id = Id,
                            Title = Title
                        });
                    }
                }

                return searchResult;
            }
        }

        //For the exact_match
        public IList<StringSearch> ExactSearch(string firstKeyword, string secondKeyword)
        {
            var searchResult = new List<StringSearch>();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "exact_match";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("firstkeyword", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = firstKeyword });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("secondkeyword", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = secondKeyword });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Id = Convert.ToString(reader["id"]);
                        var Title = Convert.ToString(reader["title"]);

                        searchResult.Add(new StringSearch()
                        {
                            Id = Id,
                            Title = Title
                        });
                    }
                }

                return searchResult;
            }
        }

        //For the bestmatch
        public IList<BestSearch> BestSearch(string firstKeyword, string secondKeyword, string thirdKeyword)
        {
            var searchResult = new List<BestSearch>();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "bestmatch";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("w1", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = firstKeyword });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("w2", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = secondKeyword });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("w3", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = thirdKeyword });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Id = Convert.ToString(reader["tconst"]);
                        var Title = Convert.ToString(reader["title"]);
                        int? Rank = Convert.ToInt32(reader["rank"]);

                        searchResult.Add(new BestSearch()
                        {
                            Id = Id,
                            Rank = (int)Rank,
                            Title = Title
                        });
                    }
                }

                return searchResult;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For title_basics talbe
            modelBuilder.Entity<TitleBasics>().ToTable("title_basics");
            modelBuilder.Entity<TitleBasics>().Property(x => x.Id).HasColumnName("tconst").HasColumnType("varchar");
            modelBuilder.Entity<TitleBasics>().Property(x => x.TitleType).HasColumnName("titletype");
            modelBuilder.Entity<TitleBasics>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<TitleBasics>().Property(x => x.OriginalTitle).HasColumnName("originaltitle");
            modelBuilder.Entity<TitleBasics>().Property(x => x.IsAdult).HasColumnName("isadult");
            modelBuilder.Entity<TitleBasics>().Property(x => x.StartYear).HasColumnName("startyear");
            modelBuilder.Entity<TitleBasics>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<TitleBasics>().Property(x => x.RuntimeMinutes).HasColumnName("runtimeminutes");
            modelBuilder.Entity<TitleBasics>().Property(x => x.Genres).HasColumnName("genres");

            //for string_search function

            //Need to be done more corection for other tables
        }
    }
}

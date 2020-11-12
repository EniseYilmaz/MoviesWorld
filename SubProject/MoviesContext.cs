using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
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
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DbSet<TitleBasics> titleBasics { get; set; }
        public DbSet<SearchHistory> searchHistories { get; set; }
        public DbSet<User> users { get; set; }
       
        

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            var config = new ConfigurationBuilder()
                    .AddJsonFile("config.json")
                    .AddEnvironmentVariables()
                    .Build();

            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseNpgsql(config["connectionString"]);
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
                command.Parameters.Add(new Npgsql.NpgsqlParameter("uname", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = "adam12" });

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
                command.Parameters.Add(new Npgsql.NpgsqlParameter("uname", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = "adam12" });

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
                command.Parameters.Add(new Npgsql.NpgsqlParameter("uname", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = "adam12" });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Id = Convert.ToString(reader["id"]);
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

        //For the similar_movies
        public IList<SimilarMovies> SimilarMovies(string movieTitle)
        {
            var similarMovies = new List<SimilarMovies>();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "similar_movies";
                command.Parameters.Add(new Npgsql.NpgsqlParameter("movietitle", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = movieTitle });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Id = Convert.ToString(reader["id"]);
                        var Title = Convert.ToString(reader["title"]);
                        var Genres = Convert.ToString(reader["genres"]);
                        var StartYear = Convert.ToString(reader["startyear"]);

                        similarMovies.Add(new SimilarMovies()
                        {
                            Id = Id,
                            Title = Title,
                            Genres = Genres,
                            StartYear = StartYear
                        });
                    }
                }

                return similarMovies;
            }
        }

        //For the popular actors
        public IList<PopularActors> PopularActors()
        {
            var actors = new List<PopularActors>();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "show_popular_actors";

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Id = Convert.ToString(reader["id"]);
                        var Name = Convert.ToString(reader["name"]);
                        float Rating = Convert.ToInt32(reader["rating"]);
                        int NumVotes = Convert.ToInt32(reader["numvotes"]);

                        actors.Add(new PopularActors()
                        {
                            Id = Id,
                            Name = Name,
                            Rating = Rating,
                            NumOfVotes = NumVotes
                        });
                    }
                }

                return actors;
            }
        }

        //For add movie to bookmark
        public bool AddMovieBookMark(string userName, string movieId )
        {

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "add_to_bookmark_movie";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = userName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = movieId });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                var reader = command.ExecuteScalar();


                return (bool)reader;
            }
        }

        //For remove movie from bookmark
        public bool RemoveMovieBookMark(string userName, string movieId)
        {

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "remove_from_bookmark_movie";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = userName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = movieId });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                var reader = command.ExecuteScalar();


                return (bool)reader;
            }
        }

        //For add name to bookmark
        public bool AddNameBookMark(string userName, string personId)
        {

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "add_to_bookmark_names";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = userName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputnconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = personId });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                var reader = command.ExecuteScalar();


                return (bool)reader;
            }
        }

        //For remove name from bookmark
        public bool RemoveNameBookMark(string userName, string personId)
        {

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "remove_from_bookmark_names";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = userName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputnconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = personId });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                var reader = command.ExecuteScalar();


                return (bool)reader;
            }
        }

        //For add movie to fav
        public bool AddMovieFavorite(string userName, string movieId)
        {

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "add_to_fav";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = userName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = movieId });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                var reader = command.ExecuteScalar();


                return (bool)reader;
            }
        }

        //For remove movie from fav
        public bool RemoveMovieFavorite(string userName, string movieId)
        {

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "remove_from_fav_movie";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = userName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = movieId });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                var reader = command.ExecuteScalar();


                return (bool)reader;
            }
        }

        
        public IList<UsersFavorite> GetusersFavorites(String username)
        {
            var Userfavorites = new List<UsersFavorite>();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = $"Select * from favorites where username = '{username}'";

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var Username = Convert.ToString(reader["username"]);
                        var Id = Convert.ToString(reader["Tconst"]);
                        

                        Userfavorites.Add(new UsersFavorite()
                        {
                            Id = Id,
                            Username = Username
                            
                        });
                    }
                }

                return Userfavorites;
            }

        }

        public IList<UserBookmarksTitles> GetUsersBookmarksTitles(String username)
        {
            var UserBookmarks = new List<UserBookmarksTitles>();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = $"Select * from bookmarks_movies where username = '{username}'";

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var Username = Convert.ToString(reader["username"]);
                        var Id = Convert.ToString(reader["Tconst"]);


                        UserBookmarks.Add(new UserBookmarksTitles()
                        {
                            Id = Id,
                            Username = Username

                        });
                    }
                }

                return UserBookmarks;
            }

        }

        public IList<UserBookmarksActors> GetUsersBookmarksActors(String username)
        {
            var UserBookmarks = new List<UserBookmarksActors>();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = $"Select * from bookmarks_names where username = '{username}'";

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var Username = Convert.ToString(reader["username"]);
                        var Id = Convert.ToString(reader["nconst"]);


                        UserBookmarks.Add(new UserBookmarksActors()
                        {
                            Id = Id,
                            Username = Username

                        });
                    }
                }

                return UserBookmarks;
            }

        }

        public TitleBasics GetSingleTitleBasics(String id)
        {
            var title = new TitleBasics();

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = $"Select * from title_basics where tconst = '{id}'";

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        
                        var mid = Convert.ToString(reader["Tconst"]);
                        var titleType = Convert.ToString(reader["titletype"]);
                        var primaryTitle = Convert.ToString(reader["primarytitle"]);
                        var originalTitle = Convert.ToString(reader["originaltitle"]);
                        var isAdult = Convert.ToBoolean(reader["isadult"]);
                        var startYear = Convert.ToString(reader["startyear"]);
                        var endYear = Convert.ToString(reader["endyear"]);
                        var runtimeMinutes = Convert.ToInt32(reader["runtimeminutes"]); 
                        var genres = Convert.ToString(reader["genres"]);

                        title = new TitleBasics()
                        {
                            Id = mid,
                            TitleType = titleType,
                            PrimaryTitle = primaryTitle,
                            OriginalTitle = originalTitle,
                            IsAdult = isAdult,
                            StartYear = startYear,
                            EndYear = endYear,
                            RuntimeMinutes = runtimeMinutes,
                            Genres = genres

                        };
                    }
                }

                return title;
            }

        }
        

            public bool DeleteUser(string userName, string email)
        {

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "delete_user";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = userName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputemail", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = email });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                var reader = command.ExecuteScalar();
                //returns true if the user was created succesfully

                return (bool)reader;
            }
        }


        public bool CreateUser(string userName, string name, string email , string password)
        {

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "add_user";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = userName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputname", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = name });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputemail", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = email});
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputpassword", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = password });

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                var reader = command.ExecuteScalar();
                //returns true if the user was created succesfully

                return (bool)reader;
            }
        }

        public IList<User> GetAllUsers()
        {

            var users = new List<User>();
            using (var command = this.Database.GetDbConnection().CreateCommand()) { 
                command.CommandType = CommandType.Text;
                command.CommandText = "Select username,email,name from users";

                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var username = Convert.ToString(reader["username"]);
                        var email = Convert.ToString(reader["email"]);
                        var name = Convert.ToString(reader["name"]);

                        var user = new User()
                        {

                           Username = username,
                           Email = email,
                           Name = name
                           
                        };

                        users.Add(user);
                    }
                }
                return users;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //For title_basics table
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

            //for search_history table
            modelBuilder.Entity<SearchHistory>().ToTable("search_history");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<SearchHistory>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Keywords).HasColumnName("string_search");
            modelBuilder.Entity<SearchHistory>().Property(x => x.SearchNumber).HasColumnName("search_number");

            //usersFavorites
            modelBuilder.Entity<UsersFavorite>().ToTable("favorites").HasNoKey();
            modelBuilder.Entity<UsersFavorite>().Property(x => x.Username).HasColumnName("username");
            modelBuilder.Entity<UsersFavorite>().Property(x => x.Id).HasColumnName("tconst");

            
            
        }
    }
}

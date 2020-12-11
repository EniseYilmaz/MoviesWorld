using DataServiceLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Scaffolding.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceLib
{
    public class MoviesContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DbSet<TitleBasics> titleBasics { get; set; }
        public DbSet<SearchHistory> searchHistories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UsersFavorite> favorites { get; set; }
        public DbSet<BookmarkMovies> bookmarkMovies { get; set; }
        public DbSet<BookmarkActors> bookmarkActors { get; set; }
        public DbSet<StringSearch> SearchResults { get; set; }
        public DbSet<SimilarMovies> SimilarMovies { get; set; }
        public DbSet<PopularActors> PopularActors { get; set; }
        public DbSet<PopularMovies> PopularMovies { get; set; }
        public DbSet<OMDBData> OMDBDatas { get; set; }

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
        public IList<StringSearch> Search(string keyword, string userName)
        {
            var result = this.SearchResults.FromSqlInterpolated($"select * from string_search({keyword}, {userName})");
            return result.ToList();
        }

        //For the similar_movies
        public IList<SimilarMovies> getSimilarMovies(string movieTitle)
        {
            var result = this.SimilarMovies.FromSqlInterpolated($"select * from similar_movies({movieTitle})");
            return result.ToList();
        }

        //For the popular actors
        public IList<PopularActors> getPopularActors()
        {
            var result = this.PopularActors.FromSqlInterpolated($"select * from show_popular_actors()");
            return result.ToList();
        }

        //For the popular movies
        public IList<PopularMovies> getPopularMovies()
        {
            var result = this.PopularMovies.FromSqlInterpolated($"select * from show_popular_movies()");
            return result.ToList();
        }

        //For add movie to bookmark add_to_bookmark_movie
        public bool AddMovieBookMark(string userName, string movieId )
        {
            var connection = (NpgsqlConnection)this.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "add_to_bookmark_movie";

            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = userName });
            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = movieId });


            var reader = command.ExecuteScalar();

            return (bool)reader;
        }

        //For remove movie from bookmark
        public bool RemoveMovieBookMark(string userName, string movieId)
        {
            var connection = (NpgsqlConnection)this.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "remove_from_bookmark_movie";

            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = userName });
            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = movieId });


            var reader = command.ExecuteScalar();

            return (bool)reader;
        }

        //For add name to bookmark
        public bool AddNameBookMark(string userName, string personId)
        {
            var connection = (NpgsqlConnection)this.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "add_to_bookmark_names";

            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = userName });
            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputnconst", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = personId });


            var reader = command.ExecuteScalar();

            return (bool)reader;
        }

        //For remove name from bookmark
        public bool RemoveNameBookMark(string userName, string personId)
        {
            var connection = (NpgsqlConnection)this.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "remove_from_bookmark_names";

            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = userName });
            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputnconst", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = personId });


            var reader = command.ExecuteScalar();

            return (bool)reader;
        }

        //For add movie to fav
        public string AddMovieFavorite(string userName, string movieId)
        {
            var connection = (NpgsqlConnection)this.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "add_to_fav";

            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = userName });
            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = movieId });


            var reader = command.ExecuteScalar();

            return reader.ToString();
        }

        //For remove movie from fav
        public bool RemoveMovieFavorite(string userName, string movieId)
        {
            var connection = (NpgsqlConnection)this.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "remove_from_fav_movie";

            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = userName });
            command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
            { Value = movieId });


            var reader = command.ExecuteScalar();

            return (bool)reader;
        }


        //For rating a movie
        public bool AddMovieRating(MovieRatingDto ratingDto)
        {

                var connection = (NpgsqlConnection)this.Database.GetDbConnection();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "rating_function_titles";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = ratingDto.UserName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = ratingDto.MovieId });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputrating", NpgsqlTypes.NpgsqlDbType.Integer)
                { Value = ratingDto.Rating });

                var reader = command.ExecuteScalar();


                return (bool)reader;
            
        }

        //For remove movie rating
        public bool RemoveMovieRating(MovieRatingDto ratingDto)
        {
                var connection = (NpgsqlConnection)this.Database.GetDbConnection();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "remove_user_rating";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = ratingDto.UserName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputtconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = ratingDto.MovieId });

                var reader = command.ExecuteScalar();

                return (bool)reader;
            
        }



        //For rating an actor rating
        public bool AddActorRating(ActorRatingDto actorRatingDto)
        {
                var connection = (NpgsqlConnection)this.Database.GetDbConnection();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "rating_function_names";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = actorRatingDto.UserName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputnconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = actorRatingDto.PersonId });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputrating", NpgsqlTypes.NpgsqlDbType.Integer)
                { Value = actorRatingDto.Rating });

                var reader = command.ExecuteScalar();

                return (bool)reader;
        }

        //For remove actor rating
        public bool RemoveActorRating(ActorRatingDto actorRatingDto)
        {

                var connection = (NpgsqlConnection)this.Database.GetDbConnection();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "remove_user_rating_names";

                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputusername", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = actorRatingDto.UserName });
                command.Parameters.Add(new Npgsql.NpgsqlParameter("inputnconst", NpgsqlTypes.NpgsqlDbType.Varchar)
                { Value = actorRatingDto.PersonId });

                var reader = command.ExecuteScalar();

                return (bool)reader;
        }

        //returns 0 if no rating found...
        public double GetRating(string id)
        {

            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                string table;
                string idType;
                if (id[0] == 'n')
                {
                    table = "name_ratings";
                    idType = "Nconst";
                }
                else
                {
                    table = "title_ratings";
                    idType = "tconst";
                }

                command.CommandText = $"Select * from {table} where {idType} = '{id}'";
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    if (reader.HasRows)
                    {


                        var Id = Convert.ToString(reader[idType]);
                        double Rating = Convert.ToDouble(reader["averagerating"]);
                        int NumVotes = Convert.ToInt32(reader["numvotes"]);

                        var rating = new TitleRatingDto()
                        {
                            Id = Id,
                            AverageRating = Rating,
                            NumVotes = NumVotes
                        };
                        return rating.AverageRating;
                    }
                    else return 0;


                }
            }

               
        }

        public IList<Title_Principals> GetPersonal(string id)
        {
            var personallist = new List<Title_Principals>();
            using (var command = this.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.Text;
          
                command.CommandText = $"Select * from title_principals natural left join name_basics where tconst = '{id}' order by ordering";
                if (command.Connection.State == ConnectionState.Closed)
                    command.Connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        if (reader.HasRows)
                        {
                            var movieId = Convert.ToString(reader["tconst"]);
                            int ordering = Convert.ToInt32(reader["ordering"]);
                            string personid = Convert.ToString(reader["nconst"]);
                            string name = Convert.ToString(reader["primaryname"]);
                            var category = Convert.ToString(reader["category"]);
                            string characters = Convert.ToString(reader["characters"]);

                            characters = characters.Trim(new Char[] { '[', ']' });

                            var listOfNames= new List<string>(); 
                            //split string up into list, remove excess chars. 
                            foreach (string xc in new List<string>(characters.Split(',')))
                            {

                                listOfNames.Add(xc.Trim(new Char[] { '\'' }));

                            }


                            var titleprincipal = new Title_Principals()
                            {
                                MovieId = movieId,
                                Ordering = ordering,
                                PersonId = personid,
                                Name = name,
                                Category = category, 
                                Characters = listOfNames
                            };
                            personallist.Add(titleprincipal);

                        }
                        

                    }

                }
            }

            return personallist;

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
            modelBuilder.Entity<UsersFavorite>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<UsersFavorite>().Property(x => x.MovieId).HasColumnName("tconst");

            

            //For users table
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<User>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<User>().Property(x => x.Name).HasColumnName("name");
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnName("password");
            modelBuilder.Entity<User>().Property(x => x.Salt).HasColumnName("salt");

            //For bookmark movies
            modelBuilder.Entity<BookmarkMovies>().ToTable("bookmarks_movies").HasNoKey();
            modelBuilder.Entity<BookmarkMovies>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<BookmarkMovies>().Property(x => x.MovieId).HasColumnName("tconst");

            //For bookmark movies
            modelBuilder.Entity<BookmarkActors>().ToTable("bookmarks_names").HasNoKey();
            modelBuilder.Entity<BookmarkActors>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<BookmarkActors>().Property(x => x.PersonId).HasColumnName("nconst");

            //For OMDBData table
            modelBuilder.Entity<OMDBData>().ToTable("omdb_data");
            modelBuilder.Entity<OMDBData>().Property(x => x.UrlToPoster).HasColumnName("poster");
            modelBuilder.Entity<OMDBData>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<OMDBData>().Property(x => x.Plot).HasColumnName("plot");
        }
    }
}

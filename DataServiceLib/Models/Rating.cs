namespace DataServiceLib.Models
{
    public class TitleRatingDto
    {
        
        public string Id { get; set; }
        public double AverageRating { get; set; }
        public int NumVotes { get; set; }

    }
    public class NameRatingDto
    {
        public string Id { get; set; }
        public double AverageRating { get; set; }
        public int NumVotes { get; set; }

    }

    public class UserTitleRatingDto
    {
       
        public string UserName { get; set; }
        public string MovieId { get; set; }
        public int MovieRating { get; set; }

    }

    public class UserNameRatingDto
    {
       
        public string UserName { get; set; }
        public string PersonId { get; set; }
        public int ActorRating { get; set; }

    }
}
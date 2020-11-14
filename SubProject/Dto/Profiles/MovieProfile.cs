using AutoMapper;
using DataServiceLib.Models;

namespace SubProject.Dto.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<TitleBasics, MovieDto>();
        }
        
    }
}

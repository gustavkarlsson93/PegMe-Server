using API.DTO;
using AutoMapper;
using PegMe.Models;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubDto>();
            
        }
    }
}

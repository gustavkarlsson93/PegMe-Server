using API.DTO;
using AutoMapper;
using PegMe.Models;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubDTO>()
                .ForMember(c => c.ClubId, c => c.MapFrom(s => s.Id))
                .ForMember(c => c.ClubName, c => c.MapFrom(s => s.Name));
                
        }
    }
}

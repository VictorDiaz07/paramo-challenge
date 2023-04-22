using AutoMapper;
using Sat.Recruitment.Application.User.Add;
using Sat.Recruitment.Core.Dtos;

namespace Sat.Recruitment.Application.Mappings
{
    /// <summary>
    /// This class represents the mapping profile between AddUserRequest and User entities, and between User and UserDto data transfer objects (DTOs).
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserRequest, Core.Entities.User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower()))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Replace(" ", "")));

            CreateMap<Core.Entities.User, UserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower()))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Replace(" ", "")));
        }
    }
}

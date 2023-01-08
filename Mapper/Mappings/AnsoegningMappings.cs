using AutoMapper;
using Core.DbModels;
using Core.Models.User;

namespace Mapper.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Id, m => m.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, m => m.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, m => m.MapFrom(src => src.Email))
                .ForMember(dest => dest.ResetPasswordGuid, m => m.MapFrom(src => src.ResetPasswordGuid))
                .ForMember(dest => dest.PasswordHash, m => m.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.Salt, m => m.MapFrom(src => src.Salt))
                .ForMember(dest => dest.Administrator, m => m.MapFrom(src => src.Administrator))
                ;
            
        }
    }
}
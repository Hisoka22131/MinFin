using AutoMapper;
using MinFin.DB.Domain;
using MinFin.Web.Dto.User;
using MinFin.Web.Integration.User;

namespace MinFin.Web.MapperConfigs;

public class UserConfig : Profile
{
    public UserConfig()
    {
        CreateMap<User, UserIntGetDto>();
        CreateMap<UserIntPutDto, User>();
        CreateMap<User, UserListDto>();
        CreateMap<User, UserPutDto>().ReverseMap();
        CreateMap<UserPostDto, User>();
    }
}
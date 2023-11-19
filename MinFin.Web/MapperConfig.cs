using AutoMapper;
using MinFin.DB.Domain;
using MinFin.Web.Integration.User;

namespace MinFin.Web;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<User, UserIntGetDto>();
        CreateMap<UserIntPutDto, User>();
    }
}
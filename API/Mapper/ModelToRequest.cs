using API.Request;
using AutoMapper;
using Data.Model;

namespace API.Mapper;

public class ModelToRequest : Profile
{
    public ModelToRequest()
    {
        CreateMap<User, UserRequest>();
    }
}
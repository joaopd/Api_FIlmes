using Api.Domain.Dto;
using Api.Domain.Dto.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
  public class EntityToDtoProfile : Profile
  {
    public EntityToDtoProfile()
    {
      CreateMap<UserDto, UserEntity>()
              .ReverseMap();

      CreateMap<UserDtoCreateReult, UserEntity>()
               .ReverseMap();

      CreateMap<UserDtoUpdateReult, UserEntity>()
              .ReverseMap();
    }
  }
}

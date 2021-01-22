using Api.Domain.Dto;
using Api.Domain.Dto.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Models.Filmes;
using AutoMapper;


namespace Api.CrossCutting.Mappings
{
  public class EntityToDtoProfile : Profile
  {
    public EntityToDtoProfile()
    {
      //user
      CreateMap<UserDto, UserEntity>()
              .ReverseMap();

      CreateMap<UserDtoCreateReult, UserEntity>()
               .ReverseMap();

      CreateMap<UserDtoUpdateReult, UserEntity>()
              .ReverseMap();
      //Filmes
      CreateMap<FilmesDto, FilmeEntity>()
              .ReverseMap();

      CreateMap<FilmesDtoCreateReult, FilmeEntity>()
               .ReverseMap();

      CreateMap<FilmesDtoUpdateReult, FilmeEntity>()
              .ReverseMap();
    }
  }
}

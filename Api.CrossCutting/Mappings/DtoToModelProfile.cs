using Api.Domain.Dto;
using Api.Domain.Dto.User;
using Api.Domain.Models;
using Api.Domain.Models.Filmes;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
  public class DtoToModelProfile : Profile
  {
    public DtoToModelProfile()
    {
      //User
      CreateMap<UserModel, UserDto>()
              .ReverseMap();
      CreateMap<UserModel, UserDtoCreate>()
              .ReverseMap();
      CreateMap<UserModel, UserDtoUpdate>()
              .ReverseMap();
      //Filmes
      CreateMap<FilmesModel, FilmesDto>()
                   .ReverseMap();
      CreateMap<FilmesModel, FilmesDtoCreate>()
              .ReverseMap();
      CreateMap<FilmesModel, FilmesDtoUpdate>()
              .ReverseMap();

    }

  }
}

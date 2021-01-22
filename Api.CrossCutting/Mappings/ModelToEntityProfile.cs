using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Domain.Models.Filmes;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
  public class ModelToEntityProfile : Profile
  {
    public ModelToEntityProfile()
    {
      CreateMap<UserEntity, UserModel>()
              .ReverseMap();

      CreateMap<FilmeEntity, FilmesModel>()
        .ReverseMap();

    }
  }
}

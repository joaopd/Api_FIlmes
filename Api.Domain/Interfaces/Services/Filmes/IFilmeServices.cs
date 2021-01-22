using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Dto.User;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Filmes
{
  public interface IFilmeServices
  {
    Task<FilmesDto> Get(int id);
    Task<IEnumerable<FilmesDto>> GetAll();
    Task<FilmesDtoCreateReult> Post(FilmesDtoCreate filme);
    Task<FilmesDtoUpdateReult> Put(FilmesDtoUpdate filme);
    Task<bool> Delete(int id);

    Task<IEnumerable<FilmesDto>> GetDiretor(string Diretor);
    Task<IEnumerable<FilmesDto>> GetGenero(string Gernero);
    Task<IEnumerable<FilmesDto>> GetName(string Name);
    Task<IEnumerable<FilmesDto>> GetAtores(string Atores);
    Task<IEnumerable<FilmesDto>> GetList();
    Task<IEnumerable<FilmesDto>> GetMaisVotado();



  }
}


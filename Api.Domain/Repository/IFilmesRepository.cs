using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
  public interface IFilmesRepository : IRepository<FilmeEntity>
  {
    Task<IEnumerable<FilmeEntity>> GetDiretor(string Diretor);
    Task<IEnumerable<FilmeEntity>> GetGenero(string Gernero);
    Task<IEnumerable<FilmeEntity>> GetName(string Name);
    Task<IEnumerable<FilmeEntity>> GetAtores(string Atores);
    Task<IEnumerable<FilmeEntity>> GetList();
    Task<IEnumerable<FilmeEntity>> GetMaisVotado();

  }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Filmes
{
  public interface IFilmeServices
  {
    Task<FilmeEntity> Get(int id);
    Task<IEnumerable<FilmeEntity>> GetAll();
    Task<FilmeEntity> Post(FilmeEntity filme);
    Task<FilmeEntity> Put(FilmeEntity filme);
    Task<bool> Delete(int id);

    Task<IEnumerable<FilmeEntity>> GetDiretor(string Diretor);
    Task<IEnumerable<FilmeEntity>> GetGenero(string Gernero);
    Task<IEnumerable<FilmeEntity>> GetName(string Name);
    Task<IEnumerable<FilmeEntity>> GetAtores(string Atores);
    Task<IEnumerable<FilmeEntity>> GetList();
    Task<IEnumerable<FilmeEntity>> GetMaisVotado();



  }
}


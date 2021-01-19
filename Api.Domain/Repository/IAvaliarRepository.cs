using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
  public interface IAvaliarRepository : IRepository<AvaliacaoEntity>
  {
    Task<AvaliacaoEntity> Avaliar(AvaliacaoEntity item);
  }
}

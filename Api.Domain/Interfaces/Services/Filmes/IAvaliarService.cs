using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Filmes
{
  public interface IAvaliarService
  {
    Task<AvaliacaoEntity> Avaliar(AvaliacaoEntity item);
  }
}

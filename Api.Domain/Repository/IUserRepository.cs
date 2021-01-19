using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
namespace Api.Domain.Repository
{
  public interface IUserRepository : IRepository<UserEntity>
  {
    Task<UserEntity> FindByLogin(string Email);
    Task<UserEntity> FindByLogin1(string Senha);
    Task<UserEntity> FindByLogin2(string Roles);

  }
}

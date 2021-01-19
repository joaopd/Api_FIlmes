using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Users
{
  public interface IUserServices
  {
    Task<UserEntity> Get(int id);
    Task<IEnumerable<UserEntity>> GetAll();
    Task<UserEntity> Post(UserEntity user);
    Task<UserEntity> Put(UserEntity user);
    Task<bool> Delete(int id);
  }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Dto.User;

namespace Api.Domain.Interfaces.Services.Users
{
  public interface IUserServices
  {
    Task<UserDto> Get(int id);
    Task<IEnumerable<UserDto>> GetAll();
    Task<UserDtoCreateReult> Post(UserDtoCreate user);
    Task<UserDtoUpdateReult> Put(UserDtoUpdate user);
    Task<bool> Delete(int id);
  }
}

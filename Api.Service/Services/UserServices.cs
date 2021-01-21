using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Dto.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Users;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
  public class UserServices : IUserServices
  {
    private IRepository<UserEntity> _repository;
    private readonly IMapper _mapper;
    public UserServices(IRepository<UserEntity> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    public async Task<bool> Delete(int id)
    {
      return await _repository.DeleteAsync(id);
    }

    public async Task<UserDto> Get(int id)
    {
      var entity = await _repository.SelectAsync(id);
      return _mapper.Map<UserDto>(entity);
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {

      var listEntity = await _repository.SelectAsync();
      return _mapper.Map<IEnumerable<UserDto>>(listEntity);
    }

    public async Task<UserDtoCreateReult> Post(UserDtoCreate user)
    {

      var model = _mapper.Map<UserModel>(user);
      var entity = _mapper.Map<UserEntity>(model);
      var result = await _repository.InsertAsync(entity);
      
      return _mapper.Map<UserDtoCreateReult>(result);
    }

    public async Task<UserDtoUpdateReult> Put(UserDtoUpdate user)
    {
      var model = _mapper.Map<UserModel>(user);
      var entity = _mapper.Map<UserEntity>(model);
      var result = await _repository.UpdateAsync(entity);

      return _mapper.Map<UserDtoUpdateReult>(result);
    }
  }
}

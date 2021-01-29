using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dto;
using Api.Domain.Dto.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
  public class UsuarioMapper : BaseTesteService
  {
    [Fact(DisplayName = "E Possivel mapear os Modelos")]
    public void E_Possivel_Mapear_Modelos()
    {
      var model = new UserModel
      {
        Id = Faker.RandomNumber.Next(),
        Name = Faker.Name.FullName(),
        Email = Faker.Internet.Email(),
        Role = "Basic",
        Senha = Faker.Identification.UKNationalInsuranceNumber()
      };

      var listEntity = new List<UserEntity>();
      for (int i = 0; i < 5; i++)
      {
        var item = new UserEntity
        {
          Id = Faker.RandomNumber.Next(),
          Name = Faker.Name.FullName(),
          Email = Faker.Internet.Email(),
          Role = "Basic",
          Senha = Faker.Identification.UKNationalInsuranceNumber()
        };

        listEntity.Add(item);
      }

      //Model to Entity
      var entity = Mapper.Map<UserEntity>(model);
      Assert.Equal(entity.Id, model.Id);
      Assert.Equal(entity.Email, model.Email);
      Assert.Equal(entity.Name, model.Name);
      Assert.Equal(entity.Role, model.Role);
      Assert.Equal(entity.Senha, model.Senha);


      //Entity para DTO
      var userDto = Mapper.Map<UserDto>(entity);
      Assert.Equal(userDto.Id, entity.Id);
      Assert.Equal(userDto.Email, entity.Email);
      Assert.Equal(userDto.Name, entity.Name);

      var listDto = Mapper.Map<List<UserDto>>(listEntity);
      Assert.True(listDto.Count() == listEntity.Count());
      for (int i = 0; i < listDto.Count(); i++)
      {
        Assert.Equal(listDto[i].Id, listEntity[i].Id);
        Assert.Equal(listDto[i].Email, listEntity[i].Email);
        Assert.Equal(listDto[i].Name, listEntity[i].Name);
      }

      var userDtoCreateResult = Mapper.Map<UserDtoCreateReult>(entity);
      Assert.Equal(userDtoCreateResult.Id, entity.Id);
      Assert.Equal(userDtoCreateResult.Email, entity.Email);
      Assert.Equal(userDtoCreateResult.Name, entity.Name);
      Assert.Equal(userDtoCreateResult.Role, entity.Role);
      Assert.Equal(userDtoCreateResult.Senha, entity.Senha);


      var userDtoUpdateResult = Mapper.Map<UserDtoUpdateReult>(entity);
      Assert.Equal(userDtoUpdateResult.Id, entity.Id);
      Assert.Equal(userDtoUpdateResult.Email, entity.Email);
      Assert.Equal(userDtoUpdateResult.Name, entity.Name);


      //dto to Model

      var userModel = Mapper.Map<UserDto>(userDto);
      Assert.Equal(userModel.Id, userDto.Id);
      Assert.Equal(userModel.Email, userDto.Email);
      Assert.Equal(userModel.Name, userDto.Name);

      var userModelCreate = Mapper.Map<UserDtoCreate>(userModel);
      Assert.Equal(userModelCreate.Email, userModel.Email);
      Assert.Equal(userModelCreate.Name, userModel.Name);

      var userModelUpdate = Mapper.Map<UserDtoUpdate>(userModel);
      Assert.Equal(userModelUpdate.Email, userModel.Email);
      Assert.Equal(userModelUpdate.Name, userModel.Name);
    }
  }
}

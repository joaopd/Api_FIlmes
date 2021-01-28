using System.Collections.Generic;
using Api.Domain.Dto;
using Api.Domain.Dto.User;

namespace Api.Service.Test.Usuario
{
  public class UsuarioTestes
  {
    public static string NomeUsuario { get; set; }
    public static string EmailUsuario { get; set; }
    public static string SenhaUsuario { get; set; }
    public static string RoleUsuario { get; set; }
    public static string NomeUsuarioAlterado { get; set; }
    public static string EmailUsuarioAlterado { get; set; }
    public static string SenhaUsuarioAlterado { get; set; }
    public static string RoleUsuarioAlterado { get; set; }
    public static int IdUsuario { get; set; }


    public List<UserDto> listaUserDto = new List<UserDto>();
    public UserDto userDto;
    public UserDtoCreate userDtoCreate;
    public UserDtoCreateReult userDtoCreateReult;
    public UserDtoUpdate userDtoUpdate;
    public UserDtoUpdateReult userDtoUpdateReult;

    public UsuarioTestes()
    {
      IdUsuario = Faker.RandomNumber.Next();
      NomeUsuario = Faker.Name.FullName();
      EmailUsuario = Faker.Internet.Email();
      RoleUsuario = "ADM";
      SenhaUsuario = Faker.Internet.UserName();
      NomeUsuarioAlterado = Faker.Name.FullName();
      EmailUsuarioAlterado = Faker.Internet.Email();
      RoleUsuarioAlterado = "Basic";
      SenhaUsuarioAlterado = Faker.Internet.UserName();

      for (int i = 0; i <= 10; i++)
      {
        var dto = new UserDto()
        {
          Id = Faker.RandomNumber.Next(),
          Email = Faker.Internet.Email(),
          Name = Faker.Name.FullName(),
        };
        listaUserDto.Add(dto);
      }

      userDto = new UserDto
      {
        Id = IdUsuario,
        Name = NomeUsuario,
        Email = EmailUsuario

      };

      userDtoCreate = new UserDtoCreate
      {
        Name = NomeUsuario,
        Email = EmailUsuario,
        Senha = SenhaUsuario,
        Role = RoleUsuario
      };

      userDtoCreateReult = new UserDtoCreateReult
      {
        Id = IdUsuario,
        Name = NomeUsuario,
        Email = EmailUsuario,
        Senha = SenhaUsuario,
        Role = RoleUsuario
      };

      userDtoUpdate = new UserDtoUpdate
      {
        Id = IdUsuario,
        Name = NomeUsuario,
        Email = EmailUsuario,
        Senha = SenhaUsuario,
        Role = RoleUsuario
      };

      userDtoUpdateReult = new UserDtoUpdateReult
      {
        Id = IdUsuario,
        Name = NomeUsuario,
        Email = EmailUsuario
      };


    }


  }
}

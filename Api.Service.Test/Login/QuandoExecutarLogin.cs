using System;
using System.Threading.Tasks;
using Api.Domain.Dto;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
  public class QuandoExecutarLogin : BaseTesteService
  {
    private ILoginService _service;
    private Mock<ILoginService> _serviceMock;

    [Fact(DisplayName = "E Possivel efetuar Login")]
    public async Task E_Possivel_Efetuar_Login()
    {
      var email = Faker.Internet.Email();
      var senha = Faker.Identification.UKNationalInsuranceNumber();
      var retorno = new
      {
        authenticated = true,
        created = DateTime.UtcNow,
        expiration = DateTime.UtcNow.AddHours(8),
        acessToken = Guid.NewGuid(),
        userName = email,
        messege = "Usuario logado com Sucesso"
      };

      var loginDto = new LoginDto
      {
        Email = email,
        Password = senha
      };

      _serviceMock = new Mock<ILoginService>();
      _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(retorno);
      _service = _serviceMock.Object;

        var result = await _service.FindByLogin(loginDto);
        Assert.NotNull(result);
    }

  }
}

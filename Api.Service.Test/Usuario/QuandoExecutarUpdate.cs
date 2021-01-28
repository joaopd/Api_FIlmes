using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
  public class QuandoExecutarUpdate : UsuarioTestes
  {
    private IUserServices _service;
    private Mock<IUserServices> _serviceMock;


    [Fact(DisplayName = "E possivel executar Update ")]
    public async Task E_Possivel_Excutar_Update()
    {
      _serviceMock = new Mock<IUserServices>();
      _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateReult);
      _service = _serviceMock.Object;

      var result = await _service.Post(userDtoCreate);
      Assert.NotNull(result);
      Assert.Equal(NomeUsuario, result.Name);
      Assert.Equal(EmailUsuario, result.Email);

      _serviceMock = new Mock<IUserServices>();
      _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateReult);
      _service = _serviceMock.Object;

      var resultUpdate = await _service.Put(userDtoUpdate);
      Assert.NotNull(resultUpdate);
      Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
      Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);

    }
  }
}

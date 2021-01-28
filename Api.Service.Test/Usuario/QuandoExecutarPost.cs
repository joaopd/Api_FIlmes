using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
  public class QuandoExecutarPost : UsuarioTestes
  {
    private IUserServices _service;
    private Mock<IUserServices> _serviceMock;


    [Fact(DisplayName = "E possivel executar Create ")]
    public async Task E_Possivel_Excutar_Create()
    {
      _serviceMock = new Mock<IUserServices>();
      _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateReult);
      _service = _serviceMock.Object;

      var result = await _service.Post(userDtoCreate);
      Assert.NotNull(result);
      Assert.Equal(NomeUsuario, result.Name);
      Assert.Equal(EmailUsuario, result.Email);

    }
  }
}

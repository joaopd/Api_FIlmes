using System.Threading.Tasks;
using Api.Domain.Dto.User;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
  public class QuandoExecutarGet : UsuarioTestes
  {
    private IUserServices _service;
    private Mock<IUserServices> _serviceMock;

    [Fact(DisplayName = "E possivel executar Get ")]
    public async Task E_Possivel_Excutar_Get()
    {
      _serviceMock = new Mock<IUserServices>();
      _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
      _service = _serviceMock.Object;

      var result = await _service.Get(IdUsuario);
      Assert.NotNull(result);
      Assert.True(result.Id == IdUsuario);
      Assert.Equal(NomeUsuario, result.Name);

      var record = await _service.Get(IdUsuario);
    }
  }
}

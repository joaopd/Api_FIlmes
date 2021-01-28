using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
  public class QuandoExecutarDelete : UsuarioTestes
  {
    private IUserServices _service;
    private Mock<IUserServices> _serviceMock;


    [Fact(DisplayName = "E possivel executar Delete ")]
    public async Task E_Possivel_Excutar_Delete()
    {
      _serviceMock = new Mock<IUserServices>();
      _serviceMock.Setup(m => m.Delete(IdUsuario))
                                .ReturnsAsync(true);
      _service = _serviceMock.Object;

      var deletado = await _service.Delete(IdUsuario);
      Assert.True(deletado);
    }
  }
}

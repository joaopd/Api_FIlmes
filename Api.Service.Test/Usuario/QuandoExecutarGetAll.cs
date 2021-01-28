using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
  public class QuandoExecutarGetAll : UsuarioTestes
  {
    private IUserServices _service;
    private Mock<IUserServices> _serviceMock;


    [Fact(DisplayName = "E possivel executar GetAll ")]
    public async Task E_Possivel_Excutar_GetAll()
    {
      _serviceMock = new Mock<IUserServices>();
      _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);
      _service = _serviceMock.Object;

      var result = await _service.GetAll();
       Assert.NotNull(result);
      Assert.True(result.Count() == 10);
    }
  }
}

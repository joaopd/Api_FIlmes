using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Filmes;
using Api.Service.Test.Filmes;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
  public class QuandoExecutarDeleteFilme : FilmesTeste
  {
    private IFilmeServices _service;
    private Mock<IFilmeServices> _serviceMock;


    [Fact(DisplayName = "E possivel executar Delete ")]
    public async Task E_Possivel_Excutar_Delete()
    {
      _serviceMock = new Mock<IFilmeServices>();
      _serviceMock.Setup(m => m.Delete(IdFilmes))
                                .ReturnsAsync(true);
      _service = _serviceMock.Object;

      var deletado = await _service.Delete(IdFilmes);
      Assert.True(deletado);
    }
  }
}

using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Filmes;
using Api.Service.Test.Filmes;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
  public class QuandoExecutarGetAllFilme : FilmesTeste
  {
    private IFilmeServices _service;
    private Mock<IFilmeServices> _serviceMock;


    [Fact(DisplayName = "E possivel executar GetAll ")]
    public async Task E_Possivel_Excutar_GetAll()
    {
      _serviceMock = new Mock<IFilmeServices>();
      _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaFilmesDto);
      _service = _serviceMock.Object;

      var result = await _service.GetAll();
       Assert.NotNull(result);
      Assert.True(result.Count() == 10);
    }
  }
}

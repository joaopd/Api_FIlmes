using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Filmes;
using Api.Domain.Interfaces.Services.Users;
using Api.Service.Test.Filmes;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
  public class QuandoExecutarPostFilmes : FilmesTeste
  {
    private IFilmeServices _service;
    private Mock<IFilmeServices> _serviceMock;


    [Fact(DisplayName = "E possivel executar Create ")]
    public async Task E_Possivel_Excutar_Create()
    {
      // _serviceMock = new Mock<IFilmeServices>();
      // _serviceMock.Setup(m => m.Post(filmesDtoCreate)).ReturnsAsync(filmesDtoCreateReult);
      // _service = _serviceMock.Object;

      // var result = await _service.Post(filmesDtoCreate);
      // Assert.NotNull(result);
      // Assert.Equal(NomeFilmes, result.Name);
    }
  }
}

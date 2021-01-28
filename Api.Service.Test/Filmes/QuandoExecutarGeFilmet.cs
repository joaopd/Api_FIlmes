using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Filmes;
using Api.Service.Test.Filmes;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
  public class QuandoExecutarGeFilmet : FilmesTeste
  {
    private IFilmeServices _service;
    private Mock<IFilmeServices> _serviceMock;

    [Fact(DisplayName = "E possivel executar Get ")]
    public async Task E_Possivel_Excutar_Get()
    {
      _serviceMock = new Mock<IFilmeServices>();
      _serviceMock.Setup(m => m.Get(IdFilmes)).ReturnsAsync(filmesDto);
      _service = _serviceMock.Object;

      var result = await _service.Get(IdFilmes);
      Assert.NotNull(result);
      Assert.True(result.Id == IdFilmes);
      Assert.Equal(NomeFilmes, result.Name);

      var record = await _service.Get(IdFilmes);
    }
  }
}

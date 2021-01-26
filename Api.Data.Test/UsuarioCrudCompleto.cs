using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implemetations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
  public class UsuarioCrudCompleto : BaseTeste, IClassFixture<DbTeste>
  {
    private ServiceProvider _serviceProvider;

    public UsuarioCrudCompleto(DbTeste dbTeste)
    {
      _serviceProvider = dbTeste.ServiceProvider;
    }

    [Fact(DisplayName = "Crud de usuario")]
    [Trait("CRUD","UserEntity")]
    public async Task E_Possivel_Realizar_CRUD_Usuario()
    {
        using (var context = _serviceProvider.GetService<MyContext>())
        {
            UserImplemetation _repositorio = new UserImplemetation(context);
            UserEntity _entity = new UserEntity
            {
                Email = "teste@mail.com",
                Name = "teste",
                Senha = "1234",
                Role = "Adm"
            };

            var _registroCriado = await _repositorio.InsertAsync(_entity);
            Assert.NotNull(_registroCriado);
            Assert.Equal("teste@mail.com", _registroCriado.Email);
            Assert.Equal("teste", _registroCriado.Name);
            Assert.Equal("1234", _registroCriado.Senha);
            Assert.Equal("Adm", _registroCriado.Role);
            Assert.False(_registroCriado.Id == null);

            

        }
    }
  }
}

using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implemetations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
  public class FilmesCrudCompleto : BaseTeste, IClassFixture<DbTeste>
  {
    private ServiceProvider _serviceProvider;

    public FilmesCrudCompleto(DbTeste dbTeste)
    {
      _serviceProvider = dbTeste.ServiceProvider;
    }

    [Fact(DisplayName = "Crud de usuario")]
    [Trait("CRUD", "UserEntity")]
    public async Task E_Possivel_Realizar_CRUD_Usuario()
    {
      using (var context = _serviceProvider.GetService<MyContext>())
      {
        UserImplemetation _repositorio = new UserImplemetation(context);
        UserEntity _entity = new UserEntity
        {
          Email = Faker.Internet.Email(),
          Name = Faker.Name.FullName(),
          Senha = "1234",
          Role = "Adm"
        };

        var _registroCriado = await _repositorio.InsertAsync(_entity);
        Assert.NotNull(_registroCriado);
        Assert.Equal(_entity.Email, _registroCriado.Email);
        Assert.Equal(_entity.Name, _registroCriado.Name);
        Assert.Equal(_entity.Senha, _registroCriado.Senha);
        Assert.Equal(_entity.Role, _registroCriado.Role);
        Assert.False(_registroCriado.Id == null);


        _entity.Name = Faker.Name.First();
        var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
        Assert.NotNull(_registroCriado);
        Assert.Equal(_entity.Email, _registroAtualizado.Email);
        Assert.Equal(_entity.Name, _registroAtualizado.Name);

        var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
        Assert.True(_registroExiste);

        var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
        Assert.NotNull(_registroSelecionado);

        var _todosOsRegistros = await _repositorio.SelectAsync();
        Assert.NotNull(_todosOsRegistros);
        Assert.True(_todosOsRegistros.Count() > 0);


        var _registroDelete = await _repositorio.DeleteAsync(_registroAtualizado.Id);
        Assert.True(_registroDelete);


        var _UsuarioPadrao = await _repositorio.FindByLogin("jpkabral@live.com");
        Assert.NotNull(_UsuarioPadrao);
        Assert.Equal("jpkabral@live.com", _UsuarioPadrao.Email);
        Assert.Equal("123456", _UsuarioPadrao.Senha);

      }
    }

    [Fact(DisplayName = "Regra de negocios Filme")]
    [Trait("Regra de negocios", "FilmeEntity")]
    public async Task E_Possivel_Realizar_CRUD_Filme()
    {
      using (var context = _serviceProvider.GetService<MyContext>())
      {
        FilmeImplementation _repositorio = new FilmeImplementation(context);
        FilmeEntity _entity = new FilmeEntity
        {
          Name = Faker.Name.First(),
          Gernero = Faker.Name.First(),
          Diretor = Faker.Name.FullName()
        };

        var _registroCriado = await _repositorio.InsertAsync(_entity);
        Assert.NotNull(_registroCriado);
        Assert.Equal(_entity.Name, _registroCriado.Name);
        Assert.Equal(_entity.Gernero, _registroCriado.Gernero);
        Assert.Equal(_entity.Diretor, _registroCriado.Diretor);
        Assert.False(_registroCriado.Id == null);


        _entity.Name = Faker.Name.First();
        var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
        Assert.NotNull(_registroCriado);
        Assert.Equal(_entity.Name, _registroAtualizado.Name);


        var _registroExiste = await _repositorio.ExistAsync(_registroAtualizado.Id);
        Assert.True(_registroExiste);


        var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Id);
        Assert.NotNull(_registroSelecionado);


        var _todosOsRegistros = await _repositorio.SelectAsync();
        Assert.NotNull(_todosOsRegistros);
        Assert.True(_todosOsRegistros.Count() > 0);


        var _RegistrosNomeFilme = await _repositorio.GetName(_registroAtualizado.Name);
        Assert.NotNull(_todosOsRegistros);
        Assert.True(_todosOsRegistros.Count() > 0);


        var _RegistrosNomeDiretor = await _repositorio.GetDiretor(_registroAtualizado.Diretor);
        Assert.NotNull(_todosOsRegistros);
        Assert.True(_todosOsRegistros.Count() > 0);


        var _RegistrosNomeGenero = await _repositorio.GetGenero(_registroAtualizado.Gernero);
        Assert.NotNull(_todosOsRegistros);
        Assert.True(_todosOsRegistros.Count() > 0);


        var _registroDelete = await _repositorio.DeleteAsync(_registroAtualizado.Id);
        Assert.True(_registroDelete);
      }
    }

  }
}

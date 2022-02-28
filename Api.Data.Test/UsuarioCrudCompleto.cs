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
        UserImplemetation repositorio = new UserImplemetation(context);
        UserEntity entity = new UserEntity
        {
          Email = Faker.Internet.Email(),
          Name = Faker.Name.FullName(),
          Senha = "1234",
          Role = "Adm"
        };

        var registroCriado = await repositorio.InsertAsync(entity);
        Assert.NotNull(registroCriado);
        Assert.Equal(entity.Email, registroCriado.Email);
        Assert.Equal(entity.Name, registroCriado.Name);
        Assert.Equal(entity.Senha, registroCriado.Senha);
        Assert.Equal(entity.Role, registroCriado.Role);
        Assert.False(registroCriado.Id == null);


        entity.Name = Faker.Name.First();
        var registroAtualizado = await repositorio.UpdateAsync(entity);
        Assert.NotNull(registroCriado);
        Assert.Equal(entity.Email, registroAtualizado.Email);
        Assert.Equal(entity.Name, registroAtualizado.Name);

        var registroExiste = await repositorio.ExistAsync(registroAtualizado.Id);
        Assert.True(registroExiste);

        var registroSelecionado = await repositorio.SelectAsync(registroAtualizado.Id);
        Assert.NotNull(registroSelecionado);

        var todosOsRegistros = await repositorio.SelectAsync();
        Assert.NotNull(todosOsRegistros);
        Assert.True(todosOsRegistros.Count() > 0);

        var registroDelete = await repositorio.DeleteAsync(registroAtualizado.Id);
        Assert.True(registroDelete);

        var UsuarioPadrao = await repositorio.FindByLogin("jpkabral@live.com");
        Assert.NotNull(UsuarioPadrao);
        Assert.Equal("teste@teste.com", UsuarioPadrao.Email);
        Assert.Equal("teste123", UsuarioPadrao.Senha);


      }
    }

    [Fact(DisplayName = "Regra de negocios Filme")]
    [Trait("Regra de negocios", "FilmeEntity")]
    public async Task E_Possivelrealizar_CRUD_Filme()
    {
      using (var context = _serviceProvider.GetService<MyContext>())
      {
        FilmeImplementation repositorio = new FilmeImplementation(context);
        FilmeEntity entity = new FilmeEntity
        {
          Name = Faker.Name.First(),
          Genero = Faker.Name.First(),
          Diretor = Faker.Name.FullName()
        };

        var registroCriado = await repositorio.InsertAsync(entity);
        Assert.NotNull(registroCriado);
        Assert.Equal(entity.Name, registroCriado.Name);
        Assert.Equal(entity.Genero, registroCriado.Genero);
        Assert.Equal(entity.Diretor, registroCriado.Diretor);
        Assert.False(registroCriado.Id == null);


        entity.Name = Faker.Name.First();
        var registroAtualizado = await repositorio.UpdateAsync(entity);
        Assert.NotNull(registroCriado);
        Assert.Equal(entity.Name, registroAtualizado.Name);


        var registroExiste = await repositorio.ExistAsync(registroAtualizado.Id);
        Assert.True(registroExiste);


        var registroSelecionado = await repositorio.SelectAsync(registroAtualizado.Id);
        Assert.NotNull(registroSelecionado);


        var todosOsRegistros = await repositorio.SelectAsync();
        Assert.NotNull(todosOsRegistros);
        Assert.True(todosOsRegistros.Count() > 0);


        var registrosNomeFilme = await repositorio.GetName(registroAtualizado.Name);
        Assert.NotNull(todosOsRegistros);
        Assert.True(todosOsRegistros.Count() > 0);


        var registrosNomeDiretor = await repositorio.GetDiretor(registroAtualizado.Diretor);
        Assert.NotNull(todosOsRegistros);
        Assert.True(todosOsRegistros.Count() > 0);


        var registrosNomeGenero = await repositorio.GetGenero(registroAtualizado.Genero);
        Assert.NotNull(todosOsRegistros);
        Assert.True(todosOsRegistros.Count() > 0);


        var registroDelete = await repositorio.DeleteAsync(registroAtualizado.Id);
        Assert.True(registroDelete);
      }
    }

  }
}

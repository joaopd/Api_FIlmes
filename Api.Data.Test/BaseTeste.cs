using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
  public abstract class BaseTeste
  {
    public BaseTeste()
    {

    }
  }

  public class DbTeste : IDisposable
  {

    private string dataBaseName = $"dbApiTest {Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    public ServiceProvider ServiceProvider { get; private set; }

    public BaseTeste()
    {
      var serviceCollection = new ServiceCollection();
      serviceCollection.AddDbContext<MyContext>(o =>
        o.UseSqlServer($"Presist Security Info=True;Server=localhost;Database={dataBaseName};User=adm;Password=112233"),
          ServiceLifetime.Transient
      );
      ServiceProvider = serviceCollection.BuildServiceProvider();
      using (var context = ServiceProvider.GetService<MyContext>())
      {
        context.Database.EnsureCreated();
      }
    }

    public void Dispose()
    {
      using (var context = ServiceProvider.GetService<MyContext>())
      {
        context.Database.EnsureDeleted();
      }
    }
  }
}

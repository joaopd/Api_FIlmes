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

    private string dataBaseName = $"dbApiTest3 {Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    public ServiceProvider ServiceProvider { get; private set; }

    public DbTeste()
    {
      var serviceCollection = new ServiceCollection();
      serviceCollection.AddDbContext<MyContext>(o =>
        o.UseSqlServer($"Persist Security Info=True;Server=(localdb)\\MSSQLLocalDB;Database={dataBaseName};User=adm;Password=112233"),
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

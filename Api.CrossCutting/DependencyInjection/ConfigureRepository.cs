using System;
using Api.Data.Context;
using Api.Data.Implemetations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
  public class ConfigureRepository
  {
    public static void ConfigureDependenceRepository(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
      serviceCollection.AddScoped<IUserRepository, UserImplemetation>();
      serviceCollection.AddScoped<IFilmesRepository, FilmeImplementation>();
      serviceCollection.AddScoped<IAvaliarRepository, AvaliarImplemetation>();


      if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
      {
        serviceCollection.AddDbContext<MyContext>(
        options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION")));
      }
      else
      {
        serviceCollection.AddDbContext<MyContext>(
        options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));
      }
    }
  }
}

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




      serviceCollection.AddDbContext<MyContext>(
         //options => options.UseMySql("Server=localhost;port=3306;Database=dbAPI;UID=root;pwd=mudar@123")
         options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial catalog=dbAPI1;MultipleActiveResultSets=true;User ID=adm;pwd=112233")

     );

    }
  }
}

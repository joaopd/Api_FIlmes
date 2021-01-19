using Api.Domain.Interfaces.Services.Filmes;
using Api.Domain.Interfaces.Services.Users;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
  public class ConfigureService
  {
    public static void ConfigureDependenceService(IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<IUserServices, UserServices>();
      serviceCollection.AddTransient<ILoginService, LoginService>();
      serviceCollection.AddTransient<IFilmeServices, FilmeServices>();
      serviceCollection.AddTransient<IAvaliarService, AvaliarService>();
    }
  }
}

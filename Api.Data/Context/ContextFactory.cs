using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      //Usado para Mygrations
      // var connectionString = "Server=localhost;port=3306;Database=dbAPI;UID=root;pwd=mudar@123";
      var connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial catalog=dbAPI;MultipleActiveResultSets=true;User ID=adm;pwd=112233";
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      // optionsBuilder.UseMySql(connectionString);
      optionsBuilder.UseSqlServer(connectionString);
      return new MyContext(optionsBuilder.Options);
    }
  }
}

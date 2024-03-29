using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
  public class MyContext : DbContext
  {
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<FilmeEntity> Filmes { get; set; }
    public DbSet<AtoresEntity> Atores { get; set; }
    public DbSet<AvaliacaoEntity> Avaliacao { get; set; }




    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<UserEntity>(new UserMap().Configure);

      modelBuilder.Entity<UserEntity>().HasData(
        new UserEntity
        {
          Id = '1',
          Name = "Administrador",
          Senha = "Vur67203",
          Role = "Adm",
          Email =  "jpkabral@live.com"

        }
      );

      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<FilmeEntity>(new FilmeMap().Configure);

      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<AtoresEntity>(new AtoresMap().Configure);

      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<AvaliacaoEntity>(new AvaliacaoMap().Configure);

    }


  }
}

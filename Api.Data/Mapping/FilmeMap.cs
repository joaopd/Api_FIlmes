using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
  public class FilmeMap : IEntityTypeConfiguration<FilmeEntity>
  {
    public void Configure(EntityTypeBuilder<FilmeEntity> builder)
    {
      builder.ToTable("Filmes");

      builder.HasKey(u => u.Id);

      builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);


      builder.Property(u => u.Genero)
              .IsRequired()
              .HasMaxLength(254);

      builder.Property(u => u.Diretor)
              .HasMaxLength(254);


      builder.Property(u => u.Imagem);



    }
  }
}

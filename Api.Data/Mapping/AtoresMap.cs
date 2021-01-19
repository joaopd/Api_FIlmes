using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
  public class AtoresMap
  {
    public void Configure(EntityTypeBuilder<AtoresEntity> builder)
    {
      builder.ToTable("Atores");

      builder.HasKey(p => p.Id);

      builder.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(60);


    }
  }
}

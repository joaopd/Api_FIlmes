using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
  public class AvaliacaoMap
  {
    public void Configure(EntityTypeBuilder<AvaliacaoEntity> builder)
    {
      builder.ToTable("Avaliacao");

    }
  }
}

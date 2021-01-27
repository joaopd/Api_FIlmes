using System.Collections.Generic;

namespace Api.Domain.Entities
{
  public class FilmeEntity : BaseEntity
  {
    public string Name { get; set; }
    public string Genero { get; set; }
    public string Diretor { get; set; }
    public string Imagem { get; set; }
    public virtual ICollection<AtoresEntity> NomesAtores { get; set; }
    public virtual ICollection<AvaliacaoEntity> Avaliacao { get; set; }

  }
}

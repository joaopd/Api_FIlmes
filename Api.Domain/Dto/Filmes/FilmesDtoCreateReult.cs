using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Domain.Dto
{
  public class FilmesDtoCreateReult
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Gernero { get; set; }
    public string Diretor { get; set; }
    public string Imagem { get; set; }
    public virtual ICollection<AtoresEntity> NomesAtores { get; set; }
    public virtual ICollection<AvaliacaoEntity> Avaliacao { get; set; }


  }
}

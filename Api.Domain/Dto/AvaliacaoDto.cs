using System.ComponentModel.DataAnnotations;
using Api.Domain.Enumeradores;

namespace Api.Domain.Dto
{
  public class AvaliacaoDto
  {
    public AvaliacaoEnum Avaliacao { get; set; }

    [Key]
    public int Id { get; set; }

  }
}

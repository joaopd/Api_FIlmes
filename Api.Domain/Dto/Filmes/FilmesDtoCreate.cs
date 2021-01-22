using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entities;

namespace Api.Domain.Dto
{
  public class FilmesDtoCreate
  {

    [Required(ErrorMessage = "Nome e um campo obrigatorio")]
    [StringLength(60, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Genero e um campo obrigatorio")]
    [StringLength(60, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
    public string Genero { get; set; }

    [StringLength(60, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
    public string Diretor { get; set; }
    public string Imagem { get; set; }

    [StringLength(60, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
    public ICollection<AtoresEntity> NomesAtores { get; set; }

  }
}

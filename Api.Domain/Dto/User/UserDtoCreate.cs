using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dto
{
  public class UserDtoCreate
  {

    [Required(ErrorMessage = "Nome e um campo obrigatorio")]
    [StringLength(60, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email e um campo obrigatorio")]
    [StringLength(100, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
    [EmailAddress(ErrorMessage = "Email no formato invalido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha e um campo obrigatorio")]
    [StringLength(20, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Role e um campo obrigatorio")]
    [StringLength(20, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
    public string Role { get; set; }

  }
}

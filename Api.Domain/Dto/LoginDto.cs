using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dto
{
  public class LoginDto
  {
    [Required(ErrorMessage = "Email e um campo obrigatório para Login")]
    [EmailAddress(ErrorMessage = "Email no formato invalido")]
    [StringLength(100, ErrorMessage = "Email deve ter no maximo {1} caracteres")]
    public string Email { get; set; }


    [Required(ErrorMessage = "Senha obrigatoria")]
    public string Password { get; set; }
    public string Role { get; set; }
  }
}

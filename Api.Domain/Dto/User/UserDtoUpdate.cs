using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dto
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Id e um campo obrigatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome e um campo obrigatorio")]
        [StringLength(60, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email e um campo obrigatorio")]
        [StringLength(100, ErrorMessage = "Tamanho maximo e de {1} caracteres")]
        [EmailAddress(ErrorMessage = "Email no formato invalido")]
        public string Email { get; set; }

    }
}

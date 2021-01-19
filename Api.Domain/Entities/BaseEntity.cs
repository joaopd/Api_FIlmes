using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
  public abstract class BaseEntity
  {
    [Key]
    [Required]
    public int Id { get; set; }
  }
}

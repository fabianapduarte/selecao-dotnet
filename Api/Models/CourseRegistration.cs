using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
  public class CourseRegistration
  {
    [Key]
    public long IdRegistration { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "Usuário inválido")]
    public int UserId { get; set; }
    public User User { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "Curso inválido")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
  }
}
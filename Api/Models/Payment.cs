using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
  public class Payment 
  {
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(0, int.MaxValue, ErrorMessage = "Usuário inválido")]
    public int UserFK { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(0, int.MaxValue, ErrorMessage = "Curso inválido")]
    public int CourseFK { get; set; }
    
    public int TotalPayments { get; set; }

    public int PaymentsReceived { get; set; }
  }
}
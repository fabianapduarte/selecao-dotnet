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
    
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(1, 12, ErrorMessage = "O total de parcelas deve ser maior que um e menor que doze")]
    public int TotalPayments { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [Range(0, 12, ErrorMessage = "O total de parcelas pagas deve ser maior que zero e menor que doze")]
    public int PaymentsReceived { get; set; }
  }
}
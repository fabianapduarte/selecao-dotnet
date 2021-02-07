using System.ComponentModel.DataAnnotations;

namespace Api.Models {
  public class User {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Name { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public long CreditCard { get; set; }
  }
}
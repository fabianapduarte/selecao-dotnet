using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Password { get; set; }

    [MinLength(13, ErrorMessage = "O campo do número do cartão de crédito tem que ter entre 13 e 16 caracteres")]
    [MaxLength(16, ErrorMessage = "O campo do número do cartão de crédito tem que ter entre 13 e 16 caracteres")]
    public string CreditCard { get; set; }
  }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models 
{
  public class Course
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório")]
    [MaxLength(250, ErrorMessage = "O campo tem no máximo 250 caracteres")]
    public string Title { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório")]
    [MaxLength(1024, ErrorMessage = "O campo tem no máximo 1024 caracteres")]
    public string Description { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório")]
    [Range(1, float.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public float Price { get; set; }
  }
}
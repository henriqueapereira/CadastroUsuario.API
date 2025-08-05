using CadastroUsuario.API.Validations;
using System.ComponentModel.DataAnnotations;

namespace CadastroUsuario.API.Models;

public class Usuario
{
    public int Id { get; set; }
    
    [Required]
    public string Nome { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [CpfValidation]
    public string Cpf { get; set; }
}

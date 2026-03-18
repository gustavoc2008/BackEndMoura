using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class UsuarioDTO
{
    [Required(ErrorMessage = "O Nome de usuario eh obrigatorio!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O Email do usuario eh obrigatorio!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A Senha do usuario eh obrigatoria!")]
    public string? Senha { get; set; }
}

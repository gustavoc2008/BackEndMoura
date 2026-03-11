using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class TipoEventoDTO
{
    [Required(ErrorMessage = "O Titulo do tipo de evento eh obrigatorio!")]
    public string? Titulo {  get; set; }
}

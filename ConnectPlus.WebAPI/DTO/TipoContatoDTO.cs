using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.WebAPI.DTO
{
    public class TipoContatoDTO
    {
        [Required(ErrorMessage = "O Titulo eh obrigatorio!")]
        public string? Titulo { get; set; }
    }
}

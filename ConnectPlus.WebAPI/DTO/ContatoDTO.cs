using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO
{
    public class ContatoDTO
    {
        [Required(ErrorMessage = "O Tipo do Usuario obrigatorio")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Dados sao obrigatorio")]
        public string? DadosDoContato { get; set; }

        [Required(ErrorMessage = "A imagem eh obrigatorio")]
        public IFormFile Imagem { get; set; }

        [Required(ErrorMessage = "A foto obrigatorio")]

        public Guid IdTipoContato { get; set; }
    }
}

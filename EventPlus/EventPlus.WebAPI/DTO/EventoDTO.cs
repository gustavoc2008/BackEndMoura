using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class EventoDTO
{
    [Required(ErrorMessage = "O Nome do Evento eh obrigatorio!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A Data do Evento eh obrigatoria!")]
    public DateTime DataEvento { get; set; }

    [Required(ErrorMessage = "A Descricao do Evento eh obrigatoria!")]
    public string? Descricao { get; set; }

    public Guid IdtipoEvento { get; set; }

    public Guid Idinstituicao { get; set; }
}

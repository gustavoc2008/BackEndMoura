using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O NomeFantasia da instituicao eh obrigatorio!")]
    public string? NomeFantasia {  get; set; }

    [Required(ErrorMessage = "O Endereco da instituicao eh obrigatorio!")]
    public string? Endereco { get; set; }

    [Required(ErrorMessage = "O CNPJ da instituicao eh obrigatorio!")]
    public string? Cnpj {  get; set; }
}

using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private IInstituicaoRepository _instituicaoRepository;

    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="instituicao"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        try
        {
            var novaInstituicao = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia,
                Endereco = instituicao.Endereco,
                Cnpj = instituicao.Cnpj!
            };

            _instituicaoRepository.Cadastrar(novaInstituicao);
            return StatusCode(201, novaInstituicao);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="instituicao"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, Instituicao instituicao)
    {
        try
        {
            var instituicaoAtualizado = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia,
                Endereco = instituicao.Endereco,
                Cnpj = instituicao.Cnpj!
            };

            _instituicaoRepository.Atualizar(id, instituicaoAtualizado);
            return StatusCode(204, instituicaoAtualizado);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _instituicaoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}

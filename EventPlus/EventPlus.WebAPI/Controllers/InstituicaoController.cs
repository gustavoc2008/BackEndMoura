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
    ///  EndPoint da API que faz a chamada para o metodo de lista as instituições
    /// </summary>
    /// <returns>Status Code 200 e alista de instituições</returns>
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
    /// EndPoint da API que faz a chamada para o metodo de buscar uma instituição especifica
    /// </summary>
    /// <param name="id">Id da instituição buscada</param>
    /// <returns>Status Code 200 e a instituição buscada</returns>
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
    /// EndPoint da API que faz a chamada para o método de cadastrar uma instituição
    /// </summary>
    /// <param name="instituicao">Instituição</param>
    /// <returns>Status Code 201 e a instituição a ser cadastrada</returns>
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
    /// EndPoint da API que faz a chamada para o metodo de atualizar uma instituição
    /// </summary>
    /// <param name="id">Id da instituição a ser atualizado</param>
    /// <param name="instituicao">Instituição com os dados atualizados</param>
    /// <returns>Status Code 204 e a instituição atualizada</returns>
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
    /// EndPoint da API que faz a chamada para o metodo de deletar uma instituição
    /// </summary>
    /// <param name="id">Id da instituição a ser excluido</param>
    /// <returns>Status Code 204</returns>
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

using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private ITipoEventoRepository _tipoEventoRepository;

    public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
    {
        _tipoEventoRepository = tipoEventoRepository;
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de lista os tipos de evento
    /// </summary>
    /// <returns>Status Code 200 e alista de tipos de eventos </returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoEventoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de buscar um tipo de evento especifico
    /// </summary>
    /// <param name="id">Id do tipo de evento buscado</param>
    /// <returns>Status Code 200 e o tipo de evento buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o método de cadastrar um tipo de evento
    /// </summary>
    /// <param name="tipoEvento"> Tipo de evento </param>
    /// <returns>Status Code 201 e o tipo de evento a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
    {
        try
        {
            var novoTipoEvento = new TipoEvento 
            { 
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Cadastrar(novoTipoEvento);
            return StatusCode(201, novoTipoEvento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de atualizar um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">Tipo de evento com os dados atualizados</param>
    /// <returns>Status Code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoEvento tipoEvento)
    {
        try
        {
            var tipoEventoAtuzalizado = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Atualizar(id, tipoEventoAtuzalizado);
            return StatusCode(204, tipoEventoAtuzalizado);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de deletar um tipo de evento
    /// </summary>
    /// <param name="id">Id do tipo do evento a ser excluido</param>
    /// <returns>Status Code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _tipoEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

}

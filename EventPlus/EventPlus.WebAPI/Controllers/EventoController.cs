using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private IEventoRepository _eventoRepository;

    public EventoController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de listar eventos filtrado por usuario
    /// </summary>
    /// <param name="idUsuario">Id do usuario para filtragem</param>
    /// <returns>Lista de eventos filtrados por usuario</returns>
    [HttpGet("Usuario/{idUsuario}")]
    public IActionResult ListarPorId(Guid idUsuario)
    {
        try
        {
            return Ok(_eventoRepository.ListarPorId(idUsuario));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de listar os proximos eventos
    /// </summary>
    /// <returns>Status Code 200 e uma lista de proximos eventos</returns>
    [HttpGet("ListarProximos")]
    public IActionResult ListarProximos()
    {
        try
        {
            return Ok(_eventoRepository.ListarProximos());
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


    /// <summary>
    /// EndPoint da API que faz a chamada para o metodo de listar eventos
    /// </summary>
    /// <returns>Lista de eventos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_eventoRepository.Listar());
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
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
            return Ok(_eventoRepository.BuscarPorId(id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Cadastrar(EventoDTO evento)
    {
        try
        {
            var novoEvento = new Evento
            {
                Nome = evento.Nome!,
                Descricao = evento.Descricao!,
                DataEvento = evento.DataEvento,
                IdtipoEvento = evento.IdtipoEvento,
                Idinstituicao = evento.Idinstituicao,
            };

            _eventoRepository.Cadastrar(novoEvento);
            return StatusCode(201, novoEvento);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, Evento evento)
    {
        try
        {
            var eventoAtualizado = new Evento
            {
                Nome = evento.Nome,
                Descricao = evento.Descricao,
                DataEvento = evento.DataEvento,
                IdtipoEvento = evento.IdtipoEvento,
                Idinstituicao = evento.Idinstituicao,
            };

            _eventoRepository.Atualizar(id, eventoAtualizado);
            return StatusCode(204, eventoAtualizado);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _eventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


}

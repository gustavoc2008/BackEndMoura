using ConnectPlus.DTO;
using ConnectPlus.Models;
using ConnectPlus.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConnectPlus.Interfaces;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoContatoController : ControllerBase
{
    private readonly ITipoContatoRepository _tipoContatoRepository;

    public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
    {
        _tipoContatoRepository = tipoContatoRepository;
    }

    [HttpPost]
    public IActionResult Cadastrar(TipoContatoDTO tipoContato)
    {
        try
        {
            var novoTipoContato = new TipoContato
            {
                Titulo = tipoContato.Titulo!
            };
            _tipoContatoRepository.cadastrar(novoTipoContato);

            return StatusCode(201, novoTipoContato);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            var tipoContatos = _tipoContatoRepository.listar();
            return Ok(tipoContatos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoContatoRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoContatoDTO tipoContato)
    {
        try
        {
            var tipoContatoAtualizado = new TipoContato
            {
                Titulo = tipoContato.Titulo!
            };
            _tipoContatoRepository.atualizar(id, tipoContatoAtualizado);

            return StatusCode(204, tipoContatoAtualizado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _tipoContatoRepository.deletar(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
};
using Azure;
using Azure.AI.ContentSafety;
using Eventplus.WebAPI.DTO;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    private IComentarioEventoRepository _comentarioEventoRepository;

    private readonly ContentSafetyClient _contentSafetyClient;


    public ComentarioEventoController(ContentSafetyClient contentSafetyClient, IComentarioEventoRepository comentarioEventoRepository)
    {
        _contentSafetyClient = contentSafetyClient;
        _comentarioEventoRepository = comentarioEventoRepository;
    }


    [HttpPost]
    public async Task<IActionResult> Post(ComentarioEventoDTO comentarioEvento)
    {
        try
        {
            if (string.IsNullOrEmpty(comentarioEvento.Descricao))
            {
                return BadRequest("o texto a ser moderado nao pode estar vazio");
            }

            var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

            Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);


            bool temConteudoImpropio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

            var novoComentario = new ComentarioEvento
            {
                Idevento = comentarioEvento.Idevento,
                Idusuario = comentarioEvento.Idusuario,
                Descricao = comentarioEvento.Descricao,
                Exibe = !temConteudoImpropio,
                DataComentario = DateTime.Now

            };

            _comentarioEventoRepository.Cadastrar(novoComentario);

            return StatusCode(201, novoComentario);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("Evento/{Id}")]
    public IActionResult List(Guid Id)
    {
        try
        {
            return Ok(_comentarioEventoRepository.List(Id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    [HttpGet("Evento/{Id}/Exibe")]
    public IActionResult ListarSomenteExibe(Guid Id)
    {
        try
        {
            return Ok(_comentarioEventoRepository.ListarSomenteExibe(Id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    [HttpGet("{Idusuario}/{Idevento}")]
    public IActionResult BuscarPorIdUsuario(Guid Idusuario, Guid Idevento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.BuscarPorIdUsuario(Idusuario, Idevento));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);

        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _comentarioEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
}

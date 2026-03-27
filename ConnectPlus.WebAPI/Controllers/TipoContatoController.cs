using ConnectPlus.Models;
using ConnectPlus.WebAPI.DTO;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContatoController : ControllerBase
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;

        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tipoContatoRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                return Ok(_tipoContatoRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoContatoDTO tipoContato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var novoTipoContato = new TipoContato
                {
                    Titulo = tipoContato.Titulo!,
                };

                _tipoContatoRepository.Cadastrar(novoTipoContato);
                return StatusCode(201, novoTipoContato);
            }
            catch (Exception error)
            {
                return BadRequest(error.InnerException?.Message ?? error.Message);
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

                _tipoContatoRepository.Atualizar(id, tipoContatoAtualizado);
                return StatusCode(204, tipoContatoAtualizado);
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
                _tipoContatoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}

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

        /// <summary>
        /// Endpoint da api que faz a chamada para o metodo de listar 
        /// </summary>
        /// <returns>Lista de Contatos</returns>
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

        /// <summary>
        /// Endpoint da api que faz a chamada para o metodo de buscar por id
        /// </summary>
        /// <param name="id">Id do contato para filtragem</param>
        /// <returns>Busca por id de contatos</returns>
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

        /// <summary>
        /// EndPoint da API que faz a chamada para o metodo cadastrar um contato
        /// </summary>
        /// <param name="tipoContato">Tipo Contato a ser cadastrado</param>
        /// <returns>Status Code 201 e o contato cadastrado</returns>
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

        /// <summary>
        /// Endpoint da api que faz a chamada de um metodo de atualizar um tipo de contato 
        /// </summary>
        /// <param name="id">Id do tipo contato a ser atualizado</param>
        /// <param name="tipoContato">Tipo contato com os dados atualizados</param>
        /// <returns>Status Code 204 e o tipo contato a ser atualizado</returns>
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

        /// <summary>
        /// Endpoint da api que faz a chamada para o metodo de deletar um tipo contato
        /// </summary>
        /// <param name="id">Id do tipo contato a ser deletado</param>
        /// <returns>Status Code 204</returns>
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

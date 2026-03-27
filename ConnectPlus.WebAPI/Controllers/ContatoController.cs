using System;
using System.IO;
using ConnectPlus.DTO;
using ConnectPlus.Models;
using ConnectPlus.WebAPI.DTO;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _ContatoRepository;
        private readonly IWebHostEnvironment _env; // Adicionado para gerenciar as pastas

        public ContatoController(IContatoRepository ContatoRepository, IWebHostEnvironment env)
        {
            _ContatoRepository = ContatoRepository;
            _env = env;
        }

        /// <summary>
        /// Endpoint da api que faz a chamada para o metodo de listar 
        /// </summary>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_ContatoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da api que faz a chamada para o metodo de buscar por id
        /// </summary>
        [HttpGet("{id}")]   
        public IActionResult BuscarPorId(Guid Id)
        {
            try
            {
                return Ok(_ContatoRepository.BuscarPorId(Id));
            }
            catch (Exception error)
            {
                return BadRequest(error.InnerException?.Message ?? error.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] ContatoDTO Contato)
        {   
            try
            {
                string nomeArquivo = string.Empty;

                if (Contato.Imagem != null)
                {
                    var pasta = Path.Combine(_env.WebRootPath, "images");
                    if (!Directory.Exists(pasta)) Directory.CreateDirectory(pasta);

                    nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(Contato.Imagem.FileName);
                    var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        Contato.Imagem.CopyTo(stream);
                    }
                }

                var novoContato = new Contato
                {
                    Nome = Contato.Nome!,
                    DadosDoContato = Contato.DadosDoContato!,
                    Imagem = nomeArquivo,
                    IdTipoContato = Contato.IdTipoContato
                };

                _ContatoRepository.Cadastrar(novoContato);
                return StatusCode(201, novoContato);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da api que faz a chamada de um metodo de atualizar um tipo de evento 
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromForm] ContatoDTO contato)
        {
            try
            {
                var contatoAntigo = _ContatoRepository.BuscarPorId(id);
                if (contatoAntigo == null) return NotFound("Contato não encontrado");

                string nomeArquivo = contatoAntigo.Imagem;
              
                if (contato.Imagem != null)
                {
                    var pasta = Path.Combine(_env.WebRootPath, "images");
                    if (!Directory.Exists(pasta)) Directory.CreateDirectory(pasta);

                    nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(contato.Imagem.FileName);
                    var caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        contato.Imagem.CopyTo(stream);
                    }

                    if (!string.IsNullOrEmpty(contatoAntigo.Imagem))
                    {
                        var caminhoAntigo = Path.Combine(pasta, contatoAntigo.Imagem);
                        if (System.IO.File.Exists(caminhoAntigo)) System.IO.File.Delete(caminhoAntigo);
                    }
                }

                var ContatoAtualizado = new Contato
                {
                    Nome = contato.Nome!,
                    DadosDoContato = contato.DadosDoContato!,
                    Imagem = nomeArquivo,
                    IdTipoContato = contato.IdTipoContato
                };

                _ContatoRepository.Atualizar(id, ContatoAtualizado);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint da api que faz a chamada para o metodo de deletar um tipo de evento
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var contatoAntigo = _ContatoRepository.BuscarPorId(id);

                if (contatoAntigo != null && !string.IsNullOrEmpty(contatoAntigo.Imagem))
                {
                    var caminhoAntigo = Path.Combine(_env.WebRootPath, "images", contatoAntigo.Imagem);
                    if (System.IO.File.Exists(caminhoAntigo)) System.IO.File.Delete(caminhoAntigo);
                }

                _ContatoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
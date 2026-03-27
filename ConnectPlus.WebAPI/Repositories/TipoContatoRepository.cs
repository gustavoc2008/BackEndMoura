using ConnectPlus.Models;
using ConnectPlus.WebAPI.Data;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.WebAPI.Repositories
{
    public class TipoContatoRepository : ITipoContatoRepository
    {
        private readonly ConnectPlusContext _context;

        public TipoContatoRepository(ConnectPlusContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza um tipo de contato usando o rastreamento automatico
        /// </summary>
        /// <param name="id">Id do tipo de contato a ser atualizado</param>
        /// <param name="tipoContato">Novos dados do tipo de contato</param>
        public void Atualizar(Guid id, TipoContato tipoContato)
        {
            var tipoContatoBuscado = _context.TipoContatos.Find(id);

            if (tipoContatoBuscado != null)
            {
                tipoContatoBuscado.Titulo = tipoContato.Titulo;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um tipo de contato por id
        /// </summary>
        /// <param name="id">id do tipo de contato a ser buscado</param>
        /// <returns>Objeto do tipoContato com as informações do TipoContato buscado</returns>
        public TipoContato BuscarPorId(Guid id)
        {
            return _context.TipoContatos.Find(id)!;
        }

        /// <summary>
        /// Cadastra um novo tipo de contato
        /// </summary>
        /// <param name="tipoContato">Tipo de contato a ser cadastrado</param>
        public void Cadastrar(TipoContato tipoContato)
        {
            _context.TipoContatos.Add(tipoContato);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de contato
        /// </summary>
        /// <param name="id">Id do tipo de contato a ser deletado</param>
        public void Deletar(Guid id)
        {
            var tipoContatoBuscado = _context.TipoContatos.Find(id);

            if (tipoContatoBuscado != null)
            {
                _context.TipoContatos.Remove(tipoContatoBuscado);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca a lista de tipo de contatos cadastrados
        /// </summary>
        /// <returns>Uma lista de tipo de contatos</returns>
        public List<TipoContato> Listar()
        {
            return _context.TipoContatos.OrderBy(TipoContato => TipoContato.Titulo).ToList();
        }
    }
}

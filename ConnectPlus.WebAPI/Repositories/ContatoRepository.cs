using ConnectPlus.Models;
using ConnectPlus.WebAPI.Data;
using ConnectPlus.WebAPI.Interfaces;
using ConnectPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.WebAPI.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ConnectPlusContext _context;

        public ContatoRepository(ConnectPlusContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza um contato usando o rastreamento automatico
        /// </summary>
        /// <param name="id">Id do contato a ser atualizado</param>
        /// <param name="contato">Novos dados do contato</param>
        public void Atualizar(Guid id, Contato contato)
        {
            var contatoBuscado = _context.Contatos.Find(id);

            if (contatoBuscado != null)
            {
                contatoBuscado.Nome = contato.Nome;
                contatoBuscado.DadosDoContato = contato.DadosDoContato;
                contatoBuscado.Imagem = contato.Imagem;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um contato por id
        /// </summary>
        /// <param name="id">id do contato a ser buscado</param>
        /// <returns>Objeto do Contato com as informações do Contato buscado</returns>
        public Contato BuscarPorId(Guid id)
        {
            return _context.Contatos.Include(c => c.IdTipoContatoNavigation).FirstOrDefault(c => c.IdContato == id)!;
        }

        /// <summary>
        /// Cadastra um novo contato
        /// </summary>
        /// <param name="contato">Contato a ser cadastrado</param>
        public void Cadastrar(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deleta um contato
        /// </summary>
        /// <param name="id">Id do contato a ser deletado</param>
        public void Deletar(Guid id)
        {
            var contatoBuscado = _context.Contatos.Find(id);

            if (contatoBuscado != null)
            {
                _context.Contatos.Remove(contatoBuscado);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca a lista de contatos cadastrados
        /// </summary>
        /// <returns>Uma lista de contatos</returns>
        public List<Contato> Listar()
        {
            return _context.Contatos.OrderBy(Contato => Contato.Nome).ToList();
        }
    }
}

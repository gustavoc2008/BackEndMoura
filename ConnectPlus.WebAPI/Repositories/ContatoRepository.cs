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

        public Contato BuscarPorId(Guid id)
        {
            return _context.Contatos.Include(c => c.IdTipoContatoNavigation).FirstOrDefault(c => c.IdContato == id)!;
        }

        public void Cadastrar(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var contatoBuscado = _context.Contatos.Find(id);

            if (contatoBuscado != null)
            {
                _context.Contatos.Remove(contatoBuscado);
                _context.SaveChanges();
            }
        }

        public List<Contato> Listar()
        {
            return _context.Contatos.OrderBy(Contato => Contato.Nome).ToList();
        }
    }
}

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
        public void Atualizar(Guid id, TipoContato tipoContato)
        {
            var tipoContatoBuscado = _context.TipoContatos.Find(id);

            if (tipoContatoBuscado != null)
            {
                tipoContatoBuscado.Titulo = tipoContato.Titulo;
                _context.SaveChanges();
            }
        }

        public TipoContato BuscarPorId(Guid id)
        {
            return _context.TipoContatos.Find(id)!;
        }

        public void Cadastrar(TipoContato tipoContato)
        {
            _context.TipoContatos.Add(tipoContato);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var tipoContatoBuscado = _context.TipoContatos.Find(id);

            if (tipoContatoBuscado != null)
            {
                _context.TipoContatos.Remove(tipoContatoBuscado);
                _context.SaveChanges();
            }
        }

        public List<TipoContato> Listar()
        {
            return _context.TipoContatos.OrderBy(TipoContato => TipoContato.Titulo).ToList();
        }
    }
}

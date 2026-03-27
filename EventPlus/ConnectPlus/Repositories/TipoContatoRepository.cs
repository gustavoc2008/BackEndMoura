using ConnectPlus.BdContextConnect;
using ConnectPlus.Data;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;

namespace ConnectPlus.Repositories;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly ConnectContext _context;

    public TipoContatoRepository(ConnectContext context)
    {
        _context = context;
    }

    public void atualizar(Guid id, TipoContato tipoContato)
    {
        var tipoContatoExistente = _context.TipoContatos.Find(id);
        if (tipoContatoExistente != null)
        {
            tipoContatoExistente.Titulo = tipoContato.Titulo;
            _context.SaveChanges();
        }
    }

    public TipoContato BuscarPorId(Guid id)
    {
        return _context.TipoContatos.Find(id)!;
    }

    public void cadastrar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }

    public void deletar(Guid id)
    {
        var tipoContato = _context.TipoContatos.Find(id);
        if (tipoContato != null)
        {
            _context.TipoContatos.Remove(tipoContato);
            _context.SaveChanges();
        }
    }

    public List<TipoContato> listar()
    {
        return _context.TipoContatos.ToList();
    }
}

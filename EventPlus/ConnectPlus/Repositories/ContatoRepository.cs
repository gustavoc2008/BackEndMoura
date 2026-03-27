using ConnectPlus.BdContextConnect;
using ConnectPlus.Data;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;

namespace ConnectPlus.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectContext _context;

    public ContatoRepository(ConnectContext context)
    {
        _context = context;
    }

    public void atualizar(Guid id, Contato contato)
    {
        var contatoExistente = _context.Contatos.Find(id);
        if (contatoExistente != null)
        {
            contatoExistente.Nome = contato.Nome;
            contatoExistente.DadosContato = contato.DadosContato;
            contatoExistente.Imagem = contato.Imagem;
            contatoExistente.IdTipoContato = contato.IdTipoContato;
            _context.SaveChanges();
        }
    }

    public Contato BuscarPorId(Guid id)
    {
        return _context.Contatos.Find(id)!;
    }

    public void cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    public void deletar(Guid id)
    {
        var contato = _context.Contatos.Find(id);
        if (contato != null)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
        }
    }

    public List<Contato> listar()
    {
        return _context.Contatos.ToList();
    }
}

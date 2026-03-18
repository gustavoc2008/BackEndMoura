using EventPlus.WebAPI.BdContectEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class PresencaRepositry : IPresencaRepository
{
    private readonly EventContext _context;

    public PresencaRepositry(EventContext context)
    {
        _context = context; 
    }

    /// <summary>
    /// Metodo que alterna a situacao da presenca
    /// </summary>
    /// <param name="id">Id da presenca a ser alterado</param>
    public void Atualizar(Guid id, Presenca presenca)
    {
        var presencaBuscada = _context.Presencas.Find(id);

        if(presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo que busca uma presenca por id
    /// </summary>
    /// <param name="id">Id da presenca a ser buscada</param>
    /// <returns>Presenca buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _context.Presencas.Include(p => p.IdeventoNavigation).ThenInclude(e => e!.IdinstituicaoNavigation).FirstOrDefault(p => p.Idpresenca == id)!;
    }

    public void Deletar(Guid id)
    {
        var presencaBuscada = _context.Presencas.Find(id);

        if(presencaBuscada != null)
        {
            _context.Presencas.Remove(presencaBuscada);
            _context.SaveChanges();
        }
    }

    public void Inscrever(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
    }

    public List<Presenca> Listar()
    {
        return _context.Presencas.OrderBy(p => p.Situacao).ToList();
    }

    /// <summary>
    /// Metodo que lista as presencas de um usuario especifico
    /// </summary>
    /// <param name="IdUsuario">Id do usuario para filtragem</param>
    /// <returns>Lista de presencas de um usuario</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas.Include(p => p.IdeventoNavigation).ThenInclude(e => e!.IdinstituicaoNavigation).Where(p => p.Idusuario == IdUsuario).ToList();
    }
}

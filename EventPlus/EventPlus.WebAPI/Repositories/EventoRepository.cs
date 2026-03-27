using EventPlus.WebAPI.BdContectEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _context;

    public EventoRepository(EventContext context)
    {
        _context = context; 
    }

    /// <summary>
    /// Atualiza um evento usando o rastreamento automatico
    /// </summary>
    /// <param name="id">id do evento a ser atualizado</param>
    /// <param name="instituicao">Novos dados do evento</param>
    public void Atualizar(Guid id, Evento evento)
    {
        var eventoBuscado = _context.Eventos.Find(id);

        if(eventoBuscado != null)
        {
            eventoBuscado.Nome = evento.Nome;
            eventoBuscado.DataEvento = evento.DataEvento;
            eventoBuscado.Descricao = evento.Descricao;
            eventoBuscado.IdtipoEvento = evento.IdtipoEvento;
            eventoBuscado.Idinstituicao = evento.Idinstituicao;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca um evento por id
    /// </summary>
    /// <param name="id">id do evento a ser buscado</param>
    /// <returns>Objeto do Evento com as informações do evento buscado</returns>
    public Evento BuscarPorId(Guid IdEvento)
    {
        return _context.Eventos.Include(e => e.IdtipoEventoNavigation).FirstOrDefault(e => e.Idevento == IdEvento)!;
    }

    /// <summary>
    /// Cadastra um novo evento
    /// </summary>
    /// <param name="instituicao">Evento a ser cadastrado</param>
    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um evento
    /// </summary>
    /// <param name="id">id do evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var eventoBuscado = _context.Eventos.Find(id);

        if(eventoBuscado != null)
        {
            _context.Eventos.Remove(eventoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de eventos cadastrados
    /// </summary>
    /// <returns>Uma lista de eventos</returns>
    public List<Evento> Listar()
    {
        return _context.Eventos.OrderBy(e => e.Nome).ToList();
    }

    /// <summary>
    /// Metodo que lista eventos filtrando pelas presencas de um usuario
    /// </summary>
    /// <param name="IdUsuario">Id do usuario para filtragem</param>
    /// <returns>Lista de eventos filtrados por usuario</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos.Include(e => e.IdtipoEventoNavigation).Include(e => e.IdinstituicaoNavigation).Where(e => e.Presencas.Any(p => p.Idusuario == IdUsuario && p.Situacao == true)).ToList();
    }

    /// <summary>
    /// Metodo que busca os proximos eventos que irao acontecer 
    /// </summary>
    /// <returns>Lista os proximos eventos</returns>
    public List<Evento> ListarProximos()
    {
        return _context.Eventos.Include(e => e.IdtipoEventoNavigation).Include(e => e.IdinstituicaoNavigation).Where(e => e.DataEvento >= DateTime.Now).OrderBy(e => e.DataEvento).ToList();
    }
}

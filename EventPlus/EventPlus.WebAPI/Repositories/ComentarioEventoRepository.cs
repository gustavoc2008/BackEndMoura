using EventPlus.WebAPI.BdContectEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class ComentarioEventoRepository : IComentarioEventoRepository
{
    private readonly EventContext _context;


    public ComentarioEventoRepository(EventContext context)
    {
        _context = context;
    }


    /// <summary>
    /// Busca um comentário específico feito por um usuário em um evento específico
    /// </summary>
    /// <param name="IdUsuario">ID do Usuário</param>
    /// <param name="IdEventos">ID do Evento</param>
    /// <returns>Objeto ComentarioEvento encontrado ou nulo</returns>
    public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEventos)
    {
        return _context.ComentarioEventos.FirstOrDefault(c => c.Idusuario == IdUsuario && c.Idusuario == IdEventos)!;
    }


    /// <summary>
    /// Cadastra um novo comentário
    /// </summary>
    /// <param name="comentarioEvento">Objeto ComentarioEvento a ser cadastrado</param>
    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        _context.ComentarioEventos.Add(comentarioEvento);
        _context.SaveChanges();
    }


    /// <summary>
    /// Deleta um comentário existente pelo seu ID
    /// </summary>
    /// <param name="IdComentarioEvento">ID do Comentário a ser deletado</param>
    public void Deletar(Guid IdComentarioEvento)
    {
        var comentarioBuscado = _context.ComentarioEventos.Find(IdComentarioEvento);


        if (comentarioBuscado != null)
        {
            _context.ComentarioEventos.Remove(comentarioBuscado);
            _context.SaveChanges();
        }

    }


    /// <summary>
    /// Lista todos os comentários de um evento específico
    /// </summary>
    /// <param name="IdEvento">ID do evento</param>
    /// <returns>Lista de Comentarios do evento</returns>
    public List<ComentarioEvento> List(Guid IdEvento)
    {
        return _context.ComentarioEventos
                .Where(c => c.Idevento == IdEvento)
                .ToList();
    }


    /// <summary>
    /// Lista apenas os comentários que têm permissão de serem exibidos (Exibe == true) para um evento específico
    /// </summary>
    /// <param name="IdEvento">ID do evento</param>
    /// <returns>Lista de Comentários filtrados para exibição</returns>
    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        return _context.ComentarioEventos

                .Where(c => c.Idevento == IdEvento && c.Exibe == true)
                .ToList();
    }
}

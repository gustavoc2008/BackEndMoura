using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interface;

public interface IPresencaRepository
{
    void Inscrever(Presenca presenca);
    void Deletar(Guid id);
    List<Presenca> Listar();
    Presenca BuscarPorId(Guid id);
    void Atualizar(Guid id, Presenca presenca);
    List<Presenca> ListarMinhas(Guid IdUsuario);
}

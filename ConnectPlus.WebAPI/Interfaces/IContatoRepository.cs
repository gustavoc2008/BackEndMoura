using ConnectPlus.Models;
using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.WebAPI.Interfaces
{
    public interface IContatoRepository
    {
        void Cadastrar(Contato contato);
        void Deletar(Guid id);
        List<Contato> Listar();
        void Atualizar(Guid id, Contato contato);
        Contato BuscarPorId(Guid id);
    }
}

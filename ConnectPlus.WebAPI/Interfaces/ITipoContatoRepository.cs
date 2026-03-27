using ConnectPlus.Models;
using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.WebAPI.Interfaces
{
    public interface ITipoContatoRepository
    {
        void Cadastrar(TipoContato tipoContato);
        void Deletar(Guid id);
        List<TipoContato> Listar();
        void Atualizar(Guid id, TipoContato tipoContato);
        TipoContato BuscarPorId(Guid id);
    }
}

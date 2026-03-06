using Filmes.WebAPI.Models;

namespace Filmes.WebAPI.Interface
{
    public interface IUsuarioRepository
    {
        void Cadastrar(TbUsuario novoUsuario);
        TbUsuario BuscarPorId(Guid id);
        TbUsuario BuscarPorEmailESenha(string email, string senha);
    }
}

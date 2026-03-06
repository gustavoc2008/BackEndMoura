using Filmes.WebAPI.Models;

namespace Filmes.WebAPI.Interface
{
    public interface IGeneroRepository
    {
        void Cadastrar(TbGenero novoGenero);
        List<TbGenero> Listar();
        void AtualizarIDCorpo(TbGenero generoAtualizado);
        void AtualizarIDUrl(Guid id, TbGenero genero);
        void Deletar(Guid id);
        TbGenero BuscarPorId(Guid id);
    }
}

using Filmes.WebAPI.Models;

namespace Filmes.WebAPI.Interface
{
    public interface IFilmeRepository
    {
        void Cadastrar(TbFilme novoFilme);
        List<TbFilme> Listar();
        void AtualizarIdCorpo(TbFilme filmeAtualizado);
        void AtualizarIdUrl(Guid id, TbFilme filmeAtualizado);
        void Deletar(Guid id);
        TbFilme BuscarPorId(Guid id);
    }
}

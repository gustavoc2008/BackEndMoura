using EventPlus.WebAPI.BdContectEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _context;

        public InstituicaoRepository(EventContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza uma instituição usando o rastreamento automatico
        /// </summary>
        /// <param name="id">id da instituição a ser atualizado</param>
        /// <param name="instituicao">Novos dados da instituição</param>
        public void Atualizar(Guid id, Instituicao instituicao)
        {
            var instituicaoBuscada = _context.Instituicaos.Find(id);

            if(instituicaoBuscada != null)
            {
                instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
                instituicaoBuscada.Endereco = instituicao.Endereco;
                instituicaoBuscada.Cnpj = instituicao.Cnpj;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca uma instituição por id
        /// </summary>
        /// <param name="id">id da instituição a ser buscado</param>
        /// <returns>Objeto da Instituição com as informações da instituição buscada</returns>
        public Instituicao BuscarPorId(Guid id)
        {
            return _context.Instituicaos.Find(id)!;
        }

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="instituicao">Instituição a ser cadastrada</param>
        public void Cadastrar(Instituicao instituicao)
        {
            _context.Instituicaos.Add(instituicao);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deleta uma instituição
        /// </summary>
        /// <param name="id">id da instituição a ser deletada</param>
        public void Deletar(Guid id)
        {
            var instituicaoBuscada = _context.Instituicaos.Find(id);

            if(instituicaoBuscada != null)
            {
                _context.Instituicaos.Remove(instituicaoBuscada);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca a lista de instituições cadastradas
        /// </summary>
        /// <returns>Uma lista de instituições</returns>
        public List<Instituicao> Listar()
        {
            return _context.Instituicaos.OrderBy(Instituicao => Instituicao.NomeFantasia).ToList();
        }
    }
}

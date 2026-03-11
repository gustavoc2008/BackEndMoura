using EventPlus.WebAPI.BdContectEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _context;

        public TipoUsuarioRepository(EventContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Atualiza um tipo de usuario usando o rastreamento automatico
        /// </summary>
        /// <param name="id">id do tipo usuario a ser atualizado</param>
        /// <param name="tipoUsuario">Novos dados do tipo usuario</param>
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);

            if(tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um tipo de usuario por id
        /// </summary>
        /// <param name="id">id do tipo usuario a ser buscado</param>
        /// <returns>Objeto do tipoUsuario com as informações do tipo de usuario buscado</returns>
        public TipoUsuario BuscarPorId(Guid id)
        {
            return _context.TipoUsuarios.Find(id)!;
        }

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="tipoUsuario">Tipo de usuario a ser cadastrado</param>
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            _context.TipoUsuarios.Add(tipoUsuario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="id">id do tipo usuario a ser deletado</param>
        public void Deletar(Guid id)
        {
            var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);

            if(tipoUsuarioBuscado != null)
            {
                _context.TipoUsuarios.Remove(tipoUsuarioBuscado);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Busca a lista de tipo de usuarios cadastrados
        /// </summary>
        /// <returns>Uma lista de tipo usuarios</returns>
        public List<TipoUsuario> Listar()
        {
            return _context.TipoUsuarios.OrderBy(TipoUsuario => TipoUsuario.Titulo).ToList();
        }
    }
}

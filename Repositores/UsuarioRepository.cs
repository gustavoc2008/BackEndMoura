using Filmes.WebAPI.BdContectFilme;
using Filmes.WebAPI.Interface;
using Filmes.WebAPI.Models;
using Filmes.WebAPI.Utils;

namespace Filmes.WebAPI.Repositores
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FilmeContext _context;

        public UsuarioRepository(FilmeContext context)
        {
            _context = context;
        }

        public TbUsuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                TbUsuario usuarioBuscado = _context.TbUsuarios.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TbUsuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TbUsuario novoUsuario)
        {
            try
            {
                novoUsuario.Idusuario = Guid.NewGuid().ToString();

                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha);

                _context.TbUsuarios.Add(novoUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

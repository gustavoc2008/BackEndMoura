using EventPlus.WebAPI.BdContectEvent;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;

    public UsuarioRepository(EventContext context)
    {
        _context = context; 
    }

    /// <summary>
    /// Busca o usuario pelo email e valida o hash da senha
    /// </summary>
    /// <param name="Email">Email do usuario</param>
    /// <param name="Senha">Senha do usuario</param>
    /// <returns>Retorn</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        //Primeiro buscamos o usuario pelo email
        var usuarioBuscado = _context.Usuarios.Include(usuario => usuario.IdtipoUsuarioNavigation).FirstOrDefault(usuario => usuario.Email == Email);

        //Verifica se o usuario realmente existe
        if (usuarioBuscado != null)
        {
            //comparamos o Hash da senha digitada com o que esta no banco
            bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }
        }

        return null!;
    }

    /// <summary>
    /// Busca um usuario peli Id, incluindo os dados do seu tipo usuario
    /// </summary>
    /// <param name="IdUsuario">Id do usuario a ser buscado</param>
    /// <returns>Usuario buscado</returns>
    public Usuario BuscarPorId(Guid IdUsuario)
    {
        return _context.Usuarios.Include(usuario => usuario.IdtipoUsuarioNavigation).FirstOrDefault(usuario => usuario.Idusuario == IdUsuario)!;
    }

    /// <summary>
    /// Cadastra um novo usuario com a senha criptografada
    /// </summary>
    /// <param name="usuario">Usuario a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}

using Filmes.WebAPI.BdContectFilme;
using Filmes.WebAPI.Interface;
using Filmes.WebAPI.Models;

namespace Filmes.WebAPI.Repositores
{
    public class FilmeRepository : IFilmeRepository
    {
        public readonly FilmeContext _context;

        public FilmeRepository(FilmeContext context)
        {
            _context = context;
        }

        public void AtualizarIdCorpo(TbFilme filmeAtualizado)
        {
            try
            {
                TbFilme filmeBuscado = _context.TbFilmes.Find(filmeAtualizado.Idfilme)!;

                if(filmeBuscado != null)
                {
                    filmeBuscado.Titulo = filmeAtualizado.Titulo;
                    filmeBuscado.Idgenero = filmeAtualizado.Idgenero;
                }

                _context.TbFilmes.Update(filmeBuscado!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AtualizarIdUrl(Guid id, TbFilme filmeAtualizado)
        {
            try
            {
                TbFilme filmeBuscado = _context.TbFilmes.Find(id.ToString())!;

                if(filmeBuscado != null)
                {
                    filmeBuscado.Titulo = filmeAtualizado.Titulo;
                    filmeBuscado.Idgenero = filmeAtualizado.Idgenero;
                }

                _context.TbFilmes.Update(filmeBuscado!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                
            }
        }

        public TbFilme BuscarPorId(Guid id)
        {
            try
            {
                TbFilme filmeBuscado = _context.TbFilmes.Find(id.ToString())!;
                return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TbFilme novoFilme)
        {
            try
            {
                novoFilme.Idfilme = Guid.NewGuid().ToString(); 

                _context.TbFilmes.Add(novoFilme);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TbFilme filmeBuscado = _context.TbFilmes.Find(id.ToString())!;

                if(filmeBuscado != null)
                {
                    _context.TbFilmes.Remove(filmeBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TbFilme> Listar()
        {
            try
            {
                List<TbFilme> listaFilmes = _context.TbFilmes.ToList();
                return listaFilmes;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}

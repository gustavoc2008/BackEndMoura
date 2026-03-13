using Filmes.WebAPI.BdContectFilme;
using Filmes.WebAPI.Interface;
using Filmes.WebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Repositories;

public class GeneroRepository : IGeneroRepository
{
    private readonly FilmeContext _context;
    public GeneroRepository(FilmeContext context)
    {
        _context = context;
    }

    public void AtualizarIdCor(TbGenero generoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void AtualizarIDCorpo(TbGenero generoAtualizado)
    {
        try
        {
            TbGenero generoBuscado = _context.TbGeneros.Find(generoAtualizado.Idgenero)!;

            if(generoBuscado != null)
            {
                generoBuscado.Nome = generoAtualizado.Nome;
            }

            _context.TbGeneros.Update(generoBuscado!);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public void AtualizarIdUrl(Guid id, TbGenero generoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void AtualizarIDUrl(Guid id, TbGenero generoAtualizado)
    {
        try
        {
            TbGenero generoBuscado = _context.TbGeneros.Find(id.ToString())!;

            if (generoBuscado != null)
            {
                generoBuscado.Nome = generoAtualizado.Nome;
            }

            _context.TbGeneros.Update(generoBuscado!);
            _context.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public TbGenero BuscarPorId(Guid id)
    {
        try
        {
            TbGenero generoBuscado = _context.TbGeneros.Find(id.ToString())!;

            return generoBuscado;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Cadastrar(TbGenero novoGenero)
    {
        try
        {
            novoGenero.Idgenero = Guid.NewGuid().ToString();

            _context.TbGeneros.Add(novoGenero);

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
            TbGenero generoBuscado = _context.TbGeneros.Find(id.ToString())!;

            if (generoBuscado != null)
            {
                _context.TbGeneros.Remove(generoBuscado);
            }
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            throw;
        }
    }



    public List<TbGenero> Listar()
    {
        try
        {
            List<TbGenero> listaGeneros = _context.TbGeneros.ToList();
            return listaGeneros;
        }
        catch (Exception e)
        {
            throw;
        }
    }
}

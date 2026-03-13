using System;
using System.Collections.Generic;
using Filmes.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.WebAPI.BdContectFilme;

public partial class FilmeContext : DbContext
{
    public FilmeContext()
    {
    }

    public FilmeContext(DbContextOptions<FilmeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbFilme> TbFilmes { get; set; }

    public virtual DbSet<TbGenero> TbGeneros { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FilmesBD;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbFilme>(entity =>
        {
            entity.HasKey(e => e.Idfilme).HasName("PK__tb_filme__4C3389CAD103F900");

            entity.HasOne(d => d.IdgeneroNavigation).WithMany(p => p.TbFilmes).HasConstraintName("FK__tb_filme__IDGene__5EBF139D");
        });

        modelBuilder.Entity<TbGenero>(entity =>
        {
            entity.HasKey(e => e.Idgenero).HasName("PK__tb_gener__40E9040FE3B5522F");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__tb_usuar__523111696DBB78D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

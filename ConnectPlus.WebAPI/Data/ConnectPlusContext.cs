using ConnectPlus.Models;
using ConnectPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConnectPlus.WebAPI.Data;

public partial class ConnectPlusContext : DbContext
{
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<TipoContato> TipoContatos { get; set; }
    public ConnectPlusContext()
    {
    }

    public ConnectPlusContext(DbContextOptions<ConnectPlusContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ConnectPlus;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoContato>(entity =>
        {
            entity.ToTable("TipoContato");
            entity.HasKey(e => e.IdTipoContato);
        });

        modelBuilder.Entity<Contato>(entity =>
        {
            entity.ToTable("Contato");
            entity.HasKey(e => e.IdContato);

            entity.HasOne(d => d.IdTipoContatoNavigation)
                .WithMany(p => p.Contatos)
                .HasForeignKey(d => d.IdTipoContato);
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

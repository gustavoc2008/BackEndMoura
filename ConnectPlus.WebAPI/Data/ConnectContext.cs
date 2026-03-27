using System;
using System.Collections.Generic;
using ConnectPlus.Models;
using ConnectPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.WebAPI.Data
{
    public partial class ConnectContext : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<TipoContato> TipoContatos { get; set; }
        public ConnectContext()
        {
        }

        public ConnectContext(DbContextOptions<ConnectContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ConnectPlus;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

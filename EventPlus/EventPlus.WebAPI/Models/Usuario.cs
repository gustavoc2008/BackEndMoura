using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("Usuario")]
[Index("Email", Name = "UQ__Usuario__A9D1053451285354", IsUnique = true)]
public partial class Usuario
{
    [Key]
    [Column("IDUsuario")]
    public Guid Idusuario { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(256)]
    public string Email { get; set; } = null!;

    [StringLength(60)]
    public string Senha { get; set; } = null!;

    [Column("IDTipoUsuario")]
    public Guid? IdtipoUsuario { get; set; }

    [JsonIgnore]
    [InverseProperty("IdusuarioNavigation")]
    public virtual ICollection<ComentarioEvento> ComentarioEventos { get; set; } = new List<ComentarioEvento>();

    [ForeignKey("IdtipoUsuario")]
    [InverseProperty("Usuarios")]
    public virtual TipoUsuario? IdtipoUsuarioNavigation { get; set; }

    [JsonIgnore]
    [InverseProperty("IdusuarioNavigation")]
    public virtual ICollection<Presenca> Presencas { get; set; } = new List<Presenca>();
}

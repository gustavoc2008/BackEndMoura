using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("ComentarioEvento")]
public partial class ComentarioEvento
{
    [Key]
    [Column("IDComentarioEvento")]
    public Guid IdcomentarioEvento { get; set; }

    [StringLength(200)]
    public string Descricao { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataComentario { get; set; }

    public bool Exibe { get; set; }

    [Column("IDEvento")]
    public Guid? Idevento { get; set; }

    [Column("IDUsuario")]
    public Guid? Idusuario { get; set; }

    [ForeignKey("Idevento")]
    [InverseProperty("ComentarioEventos")]
    public virtual Evento? IdeventoNavigation { get; set; }

    [ForeignKey("Idusuario")]
    [InverseProperty("ComentarioEventos")]
    public virtual Usuario? IdusuarioNavigation { get; set; }
}

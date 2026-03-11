using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("Presenca")]
public partial class Presenca
{
    [Key]
    [Column("IDPresenca")]
    public Guid Idpresenca { get; set; }

    public bool Situacao { get; set; }

    [Column("IDEvento")]
    public Guid? Idevento { get; set; }

    [Column("IDUsuario")]
    public Guid? Idusuario { get; set; }

    [ForeignKey("Idevento")]
    [InverseProperty("Presencas")]
    public virtual Evento? IdeventoNavigation { get; set; }

    [ForeignKey("Idusuario")]
    [InverseProperty("Presencas")]
    public virtual Usuario? IdusuarioNavigation { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("TipoEvento")]
public partial class TipoEvento
{
    [Key]
    [Column("IDTipoEvento")]
    public Guid IdtipoEvento { get; set; }

    [StringLength(100)]
    public string Titulo { get; set; } = null!;

    [JsonIgnore]
    [InverseProperty("IdtipoEventoNavigation")]
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}

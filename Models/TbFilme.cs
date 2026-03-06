using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Filmes.WebAPI.Models;

[Table("tb_filme")]
public partial class TbFilme
{
    [Key]
    [Column("IDFilme")]
    [StringLength(40)]
    [Unicode(false)]
    public string Idfilme { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Imagem { get; set; }

    [Column("IDGenero")]
    [StringLength(40)]
    [Unicode(false)]
    public string? Idgenero { get; set; }

    [ForeignKey("Idgenero")]
    [InverseProperty("TbFilmes")]
    public virtual TbGenero? IdgeneroNavigation { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Filmes.WebAPI.Models;

[Table("tb_genero")]
public partial class TbGenero
{
    [Key]
    [Column("IDGenero")]
    [StringLength(40)]
    [Unicode(false)]
    public string Idgenero { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [InverseProperty("IdgeneroNavigation")]
    public virtual ICollection<TbFilme> TbFilmes { get; set; } = new List<TbFilme>();
}

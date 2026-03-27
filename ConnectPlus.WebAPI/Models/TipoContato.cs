using System;
using System.Collections.Generic;
using ConnectPlus.WebAPI.Models;

namespace ConnectPlus.Models
{
    public partial class TipoContato
    {
        public Guid IdTipoContato { get; set; }

        public string Titulo { get; set; } = null!;

        public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
    }
}
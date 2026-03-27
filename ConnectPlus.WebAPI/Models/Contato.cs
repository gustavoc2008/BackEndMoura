using ConnectPlus.Models;
using System;
using System.Collections.Generic;

namespace ConnectPlus.WebAPI.Models
{
    public partial class Contato
    {
        public Guid IdContato { get; set; }

        public string Nome { get; set; } = null!;

        public string DadosDoContato { get; set; } = null!;

        public string? Imagem { get; set; }

        public Guid IdTipoContato { get; set; }

        public virtual TipoContato IdTipoContatoNavigation { get; set; } = null!;
    }
}

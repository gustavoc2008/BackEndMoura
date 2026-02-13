using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade08;

public class Usuario
{
    public bool Autenticar(string senha)
    {
        return senha == "123";
    }
}
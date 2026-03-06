using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade07
{
    public class Carro : Veiculo
    {
        public override void Mover()
        {
            Console.WriteLine("O carro se move usando motor.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade05
{
    public class Pessoa
    {
     public string Nome { get; set; }
     public int Idade { get; set; }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

        public void ExibirDados()
        {
            Console.WriteLine($"Nome: " + Nome);

            if(Idade > 0)
            {
                Console.WriteLine($"Idade: " + Idade);        
            }
        }
    }
}
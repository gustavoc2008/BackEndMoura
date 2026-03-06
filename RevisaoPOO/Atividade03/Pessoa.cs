using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade03
{
    public class Pessoa
    {
        public string Nome;
        private int idade;
        public int Idade
        {
            get{return idade;}
            set
            {
                if (value > 0)
                {
                    idade = value;
                }

                else
                {
                    Console.WriteLine($"Idade Invalida");
                }
            }
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Nome: " + Nome);

            if(idade > 0)
            {
                Console.WriteLine($"Idade: " + Idade);  
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char[] vetor = new char[100];

            for(int i = 0; i <= 99; i++)
            {
                if (i % 2 == 0)
                {
                    vetor[i] = 'P';
                }
                else (vetor[i]) = 'I';

                Console.WriteLine($"{i}: {vetor[i]}");
            }

            Console.ReadKey();

        }
    }
}

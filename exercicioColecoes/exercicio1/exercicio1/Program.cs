using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace exercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[5];
            int total=0, media;

            Console.WriteLine("=== Calculador de média:===\n");

            for (int i = 0; i <= 4; i++)
            {
                try
                {
                    Console.WriteLine($"Informe o {i+1}º número:");
                    numeros[i] = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("ERRO: Formato incorreto! - " + ex.Message + "\n");
                }
                catch(ArgumentNullException ex)
                {
                    Console.WriteLine("ERRO: Valor nulo! - " + ex.Message + "\n");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("ERRO Inesperado - " + ex.Message + "\n");
                }

                total += numeros[i];
            }

            media = total / 5;

            Console.WriteLine("Média: " + media);
            Console.ReadKey();
        }
    }
}

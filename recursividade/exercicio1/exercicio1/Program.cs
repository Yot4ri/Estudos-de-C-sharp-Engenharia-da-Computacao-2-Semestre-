using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero = 0;

            try
            {
                Console.WriteLine("=== Soma de Número ===\n\n Informe um número:");
                numero = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"ERRO: VALOR INVÁLIDO - Informe um número válido!\n{ex.Message} ");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ERRO: VALOR NULO - Informe um número!\n{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }

            int soma = 0;
            Soma(soma,numero);

            Console.ReadKey();

        }

        static void Soma(int soma,int numero)
        {

            if (numero > 0)
            {
                soma += numero;

                Soma(soma, numero - 1);
            }
            else
            {
                Console.WriteLine($"{soma}");
            }

        }
    }
}

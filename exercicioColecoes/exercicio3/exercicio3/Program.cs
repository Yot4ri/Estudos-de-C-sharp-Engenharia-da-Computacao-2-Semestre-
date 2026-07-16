using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace exercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] matriz = new int[3, 3];
            int soma = 0;

            for(int i = 0; i <= 2; i++)
            {
                for(int j = 0; j <= 2; j++) {
                    
                    try
                    {
                        Console.WriteLine("Informe o número para a posição ["+ i +","+ j +"]:");
                        matriz[i, j] = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("ERRO: Formato incorreto! - " + ex.Message + "\n");
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine("ERRO: Valor nulo! - " + ex.Message + "\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERRO Inesperado - " + ex.Message + "\n");
                    }

                    soma += matriz[i, j];
                }
            }

            Console.WriteLine($"\nSoma total: {soma}");
            Console.ReadKey();

        }
    }
}

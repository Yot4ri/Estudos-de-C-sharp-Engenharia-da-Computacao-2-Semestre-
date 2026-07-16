using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] matrizA = new int[4, 4];
            int[,] matrizB = new int[4, 4];
            int[,] matrizC = new int[4, 4];
            Boolean cadastradoA = false, cadastradoB = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cadastradoA = false;
                    cadastradoB = false;

                    Console.Clear();
                    do
                    {
                        try
                        {
                            Console.WriteLine("Informe o número para a posição [" + i + "," + j + "] da matriz A:");
                            matrizA[i, j] = int.Parse(Console.ReadLine());
                            cadastradoA = true;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("ERRO: Formato incorreto! - " + ex.Message + "\n");
                            cadastradoA = false;
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine("ERRO: Valor nulo! - " + ex.Message + "\n");
                            cadastradoA = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("ERRO Inesperado - " + ex.Message + "\n");
                            cadastradoA = false;
                        }
                    }
                    while (cadastradoA != true);

                    do
                    {
                        try
                        {
                            Console.WriteLine("Informe o número para a posição [" + i + "," + j + "] da matriz B:");
                            matrizB[i, j] = int.Parse(Console.ReadLine());
                            cadastradoB = true;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("ERRO: Formato incorreto! - " + ex.Message + "\n");
                            cadastradoB = false;
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine("ERRO: Valor nulo! - " + ex.Message + "\n");
                            cadastradoB = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("ERRO Inesperado - " + ex.Message + "\n");
                            cadastradoB = false;
                        }
                    }
                    while (cadastradoB != true);

                    matrizC[i,j] = matrizA[i,j] + matrizB[i,j];
                }
            }

            Console.WriteLine("=== Matriz C: ===");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("");
                
                for (int j = 0; j < 4; j++) {
                    if(j == 0)
                    {
                        Console.Write("|");
                    }

                    Console.Write(matrizC[i,j] );

                    if(j == 3)
                    {
                        Console.Write("|");
                    }
                }
            }

            Console.WriteLine();

        }
    }
}

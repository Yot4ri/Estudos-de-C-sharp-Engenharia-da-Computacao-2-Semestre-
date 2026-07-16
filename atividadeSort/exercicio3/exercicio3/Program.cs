using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vetor = new int[10];
            int numero = 0, temp;
            bool trocado;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine("Informe o número para adicionar ao vetor:");
                    numero = int.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"ERRO: Valor nulo - {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"ERRO: Valor inválido - {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: {ex.Message}");
                }

                vetor[i] = numero;
            }
            Console.Clear();

            for(int i = 0; i < vetor.Length - 1; i++)
            {
                trocado = false;
                
                for(int j = 0; j < vetor.Length - i - 1; j++)
                {
                    if (vetor[j] > vetor[j + 1] && vetor[j] != vetor[j+1])
                    {
                        //troca vetor[j] e vetor[j+1] de lugar
                        temp = vetor[j];
                        vetor[j] = vetor[j + 1];
                        vetor[j + 1] = temp;
                        trocado = true;
                    }

                    mostrarVetor(vetor);
                    
                }
                    if (trocado == false)
                    {
                        break;
                    }
            }

            Console.ReadKey();
        }

        static void mostrarVetor(int[] vetor)
        {
            for(int i = 0; i < vetor.Length - 1; i++)
            {
                Console.Write(vetor[i] + " ");
            }
            Console.WriteLine("\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] vetor = new int[10];
            int numero = 0, indiceMinimo, temp;


            //Preenche o vetor
            for(int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine("Informe o número para adicionar ao vetor:");
                    numero = int.Parse(Console.ReadLine());
                }
                catch(ArgumentNullException ex)
                {
                    Console.WriteLine($"ERRO: Valor nulo - {ex.Message}");
                }
                catch(FormatException ex)
                {
                    Console.WriteLine($"ERRO: Valor inválido - {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"ERRO: {ex.Message}");
                }

                vetor[i] = numero;
            }

            //Ordena o vetor
            for(int i = 0; i < 10; i++)
            {
                indiceMinimo = i;

                for(int j = i + 1; j < 10; j++)
                {
                    if (vetor[j] < vetor[indiceMinimo])
                       {
                        indiceMinimo = j; //Encontra o índice do número que é de fato o menor no vetor
                    }

                    //vetor[i] = número que vai ser substituido de lugar, que está selecionado. 
                    temp = vetor[i];
                    vetor[i] = vetor[indiceMinimo]; //Substitui o menor número pela posição i
                    vetor[indiceMinimo] = temp; //Coloca o número da posição i no lugar onde foi retirado o de menor indice
                }
            }

            Console.Clear();

            Console.WriteLine("=== Números em ordem crescente ===");
            foreach(int num in vetor)
            {
                Console.WriteLine(num);
            }
            Console.ReadKey();


        }
    }
}

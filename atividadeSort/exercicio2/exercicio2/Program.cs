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

            int[] vetor = new int[10];
            int[] vetor2 = new int[10];
            int numero = 0, indiceMinimo, temp, trocaSelecao = 0, trocaInsercao = 0, chave;


            //Preenche o vetor
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
                vetor2[i] = numero;
            }
            Console.Clear();

            //Ordena o vetor utilizando o método de seleção
            for (int i = 0; i < 10; i++)
            {
                indiceMinimo = i;

                for (int j = i + 1; j < 10; j++) 
                {
                    if (vetor[j] < vetor[indiceMinimo])
                    {
                        indiceMinimo = j; //Encontra o índice do número que é de fato o menor no vetor
                    }

                    if (indiceMinimo != i)
                    {
                        //vetor[i] = número que vai ser substituido de lugar, que está selecionado. 
                        temp = vetor[i];
                        vetor[i] = vetor[indiceMinimo]; //Substitui o menor número pela posição i
                        vetor[indiceMinimo] = temp; //Coloca o número da posição i no lugar onde foi retirado o de menor indice
                        trocaSelecao++; //Contador de trocas nesse modelo de ordenação
                    }
                }
            }

            //Ordena o vetor utilizando o método de inserção
            for(int i = 0; i < 10; i++) //vetor2.length = 10
            {
                chave = vetor2[i]; //Número para base de comparação, ele é a referência
                int j = i - 1;//Número a ser comparado vai ser o anterior a chave

                //Move os elementos que são maiores que o vetor para uma posição acima (criando espaço para a inserção do novo valor)
                while (j >= 0 && vetor2[j] > chave) //Enquanto j não ultrapassa o mínimo do vetor E o número na posição j seja maior que a chave...
                {
                    vetor2[j + 1] = vetor2[j];//Move todo os números "para a direita"
                    j--;
                    trocaInsercao++;
                }
                vetor2[j + 1] = chave;//Por fim, coloca o número ordenado na posição que foi "aberta" com a mudança dos números afetados pelo while, que subiram no vetor.
            }

            Console.WriteLine($"=== Número de trocas ===\nNº trocas pela inserção: {trocaInsercao}\nNº trocas pela seleção: {trocaSelecao}");
            Console.Write("Vetor organizado: \n");
            Console.Write("Seleção: ");
            foreach (int num in vetor)
            {
                Console.Write($"{num} ");
            }
            Console.Write("\nInserção: ");
            foreach(int num in vetor2)
            {
                Console.Write($"{num} ");
            }
            Console.ReadKey();
        }
    }
}

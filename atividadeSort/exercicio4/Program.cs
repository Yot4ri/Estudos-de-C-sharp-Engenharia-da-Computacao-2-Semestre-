using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio4
{
    internal class Program
    {
        int temp = 0;
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();

            Random aleatorio = new Random();
            int quantidade = 0;

            try //Preenchimento de lista de acordo com a indicação do usuário
            {
                Console.WriteLine("Informe a quantidade de números para a lista:");
                quantidade = int.Parse(Console.ReadLine());
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

            for (int i = 0; i < quantidade; i++)
            {
                int numero = aleatorio.Next(1, 9);
                lista.Add(numero);
            }

            Console.Clear();

            Console.WriteLine("Informe a opção desejada para ordenação:\n1 - Seleção\n2 - Insertion\n3 - Bubble");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    ordenarSelecao(lista);
                    break;

                case 2:
                    ordenarInsertion(lista);
                    break;

                case 3:
                    ordenarBubble(lista);
                    break;

                default:
                    Console.WriteLine("Informe um número válido");
                    break;
            }

            Console.ReadKey();
        }

        static void ordenarSelecao(List<int> lista)
        {
            int indiceMinimo, temp = 0;

            //Ordena o lista utilizando o método de seleção
            for (int i = 0; i < lista.Count; i++)
            {
                indiceMinimo = i;

                for (int j = i + 1; j < 10; j++)
                {
                    if (lista[j] < lista[indiceMinimo])
                    {
                        indiceMinimo = j; //Encontra o índice do número que é de fato o menor no lista
                    }

                    if (indiceMinimo != i)
                    {
                        //lista[i] = número que vai ser substituido de lugar, que está selecionado. 
                        temp = lista[i];
                        lista[i] = lista[indiceMinimo]; //Substitui o menor número pela posição i
                        lista[indiceMinimo] = temp; //Coloca o número da posição i no lugar onde foi retirado o de menor indice
                    }
                }
            }

            exibirLista(lista);
        }

        static void ordenarInsertion(List<int> lista)
        {
            int chave = 0;
            //Ordena o lista utilizando o método de inserção
            for (int i = 0; i < lista.Count; i++) //lista2.length = 10
            {
                chave = lista[i]; //Número para base de comparação, ele é a referência
                int j = i - 1;//Número a ser comparado vai ser o anterior a chave

                //Move os elementos que são maiores que o lista para uma posição acima (criando espaço para a inserção do novo valor)
                while (j >= 0 && lista[j] > chave) //Enquanto j não ultrapassa o mínimo do lista E o número na posição j seja maior que a chave...
                {
                    lista[j + 1] = lista[j];//Move todo os números "para a direita"
                    j--;
                }
                lista[j + 1] = chave;//Por fim, coloca o número ordenado na posição que foi "aberta" com a mudança dos números afetados pelo while, que subiram no lista.
            }

            exibirLista(lista);
        }

        static void ordenarBubble(List<int> lista)
        {
            int temp;

            for (int i = 0; i < lista.Count - 1; i++)
            {
                bool trocado = false;

                for (int j = 0; j < lista.Count - i - 1; j++)
                {
                    if (lista[j] > lista[j + 1] && lista[j] != lista[j + 1])
                    {
                        //troca lista[j] e lista[j+1] de lugar
                        temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                        trocado = true;
                    }

                }
                if (trocado == false)
                {
                    break;
                }
            }

            exibirLista(lista);
        }

        static void exibirLista(List<int> lista)
        {
            foreach(int valor in lista)
            {
                Console.Write(valor + " ");
            }
        }

    }
}

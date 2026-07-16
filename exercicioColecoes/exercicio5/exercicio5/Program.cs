using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String> lista = new List <String>();
            int opcao = 0;

            do
            {
                try
                {
                    Console.WriteLine("Informe um número do menu:\n1 - Adicionar Produto\n2 - Remover Produto\n3 - Exibir Lista\n4 - Encerrar o programa\n");
                    opcao = int.Parse(Console.ReadLine());
                }
                catch(FormatException ex)
                {
                    Console.WriteLine($"ERRO: Valor inválido - Informe um número!\n{ex.Message}\n");
                }
                catch(ArgumentNullException ex)
                {
                    Console.WriteLine($"ERRO: Valor nulo - Informe um número\n{ex.Message}\n");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"ERRO INESPERADO - {ex.Message}\n");
                }

                switch (opcao)
                {
                    case 1:
                        AdicionarProduto(lista);
                        break;

                    case 2:
                        ExcluirProduto(lista);
                        break;

                    case 3:
                        ExibirLista(lista);
                        break;

                    case 4:
                        ConfirmarEncerramento();
                        break;

                    default:

                        break;
                }

            }
            while (true);
        }

        public static void AdicionarProduto(List <String> lista)
        {
            String item = "";

            try
            {
                Console.WriteLine("Informe um item para adicionar a lista:");
                item = Console.ReadLine().Trim().ToLower();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ERRO: Valor nulo - Informe um número\n{ex.Message}\n");
                item = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO INESPERADO - {ex.Message}\n");
                item = "";
            }

            lista.Add(item);
            Console.WriteLine("\nItem adicionado com sucesso!\n");
            
        }

        public static void ExibirLista(List<String> lista)
        {
            foreach(var item in lista)
            {
                Console.WriteLine(item);
            }
        }

        public static void ExcluirProduto(List<String> lista)
        {
            String itemDeletar;

            try
            {
                Console.WriteLine("Informe o item para ser deletado");
                itemDeletar = Console.ReadLine().ToLower().Trim();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ERRO: Valor nulo - Informe um número\n{ex.Message}\n");
                itemDeletar = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO INESPERADO - {ex.Message}\n");
                itemDeletar = "";
            }

             if(lista.Remove(itemDeletar)) //Se o item for removido da lista, ele já vai fazer isso, uma vez que foreach não permite alterar a lista
             {
                lista.Remove(itemDeletar);
                Console.WriteLine($"Item {itemDeletar} foi removido da lista!\n");
             }
             else
             {
                Console.WriteLine($"Não existe o item {itemDeletar} na lista!\n");
             }
        }

        public static void ConfirmarEncerramento()
        {
            char confirmacao = 'S';

            do
            {

                try
                {
                    Console.WriteLine("Encerrar o programa? (S/N)");
                    confirmacao = char.Parse(Console.ReadLine().ToUpper());

                    if(confirmacao != 'S' && confirmacao != 'N')
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"ERRO: Valor inválido - Informe S - Sim ou N - Não!\n{ex.Message}\n");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"ERRO: Valor nulo - Informe uma letra válida!\n{ex.Message}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO INESPERADO - {ex.Message}\n");
                }

                if(confirmacao == 'S')
                {
                    Console.Clear();
                    Console.WriteLine("\nEncerrando programa...");
                    Environment.Exit(0); //Encerra o programa
                }

            }
            while (confirmacao == 'S');
        }

    }
}
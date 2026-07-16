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
            String linha = "";

            try
            {
                Console.WriteLine("=== Validador de String invertida ===\n\nInforme um texto:");
                linha = Console.ReadLine();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ERRO: VALOR NULO - Informe um texto!\n{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }

            String novaString = "";
            int tamanho = linha.Length - 1;
            
            InversorString(novaString, linha, tamanho);
            Console.ReadKey();


        }
        static Boolean InversorString(String novaString, String linha, int tamanho)
        {
            if (tamanho != 0) //Gera a palavra invertida
            {
                novaString += linha[tamanho];
                InversorString(novaString, linha, tamanho - 1);
            }
            else
            {
                novaString += linha[0];

                if (novaString == linha) //Verifica se a palavra invertida e a original são iguais
                {
                    Console.WriteLine("true");
                    return true; //Palavras iguais
                }
                else
                {
                    Console.WriteLine("false");
                    return false; //Palavras diferentes
                }
            }

            return false; //Caso dê algum bug que saia do loop, retorna false
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercicio2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            String linha = "";

            try
            {
                Console.WriteLine("=== Inversor de String ===\n\nInforme um texto:");
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
            InversorString(novaString,linha, tamanho);


            Console.ReadKey();
        }
        static void InversorString(String novaString,String linha, int tamanho)
        {
            if (tamanho != 0)
            {
                novaString += linha[tamanho];
                InversorString(novaString, linha, tamanho - 1);
            }
            else
            {
                novaString += linha[0];
                Console.WriteLine(novaString);
            }
        }
    }
}

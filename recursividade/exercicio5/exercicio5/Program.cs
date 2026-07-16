using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace exercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String pasta = "";

            try
            {
                Console.WriteLine("=== Scanner de Arquivos ===\nInforme o caminho da pasta a ser analisada");
                pasta = Console.ReadLine();
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine($"ERRO: VALOR NULO - Informe o nome de uma pasta");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }


            if (Directory.Exists(pasta)) //Verifica se a pasta existe
            {
                scannearPasta(pasta);
            }

            Console.ReadKey();

        }

        static void scannearPasta(String caminho) //Método que busca cada caminho em um determinado diretório
        {
            String[] arquivos = Directory.GetFiles(caminho); //Retorna os arquivos de um diretório específico

            foreach(String arquivo in arquivos)
            {
                Console.WriteLine(arquivo);
                Console.Write("\n");
            }

            String[] subpastas = Directory.GetDirectories(caminho); //Retorna as pastas em um diretório específico

            foreach(String subpasta in subpastas)
            {
                scannearPasta(subpasta); //Retorna a recursividade, scaneando a próxima pasta dentro do diretório
            }
        }
    }
}

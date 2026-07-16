using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<String> palavras = new HashSet<String>();

            Console.WriteLine("Digite palavras (digite 'fim' para parar):");

            // Preenche o conjunto com os números digitados pelo usuário
            while (true)
            {
                Console.Write("Palavra: ");
                string palavra = Console.ReadLine().ToLower();
                if (palavra == "fim")
                    break;
                palavras.Add(palavra);
            }

            // Exibe os números únicos digitados pelo usuário
            Console.WriteLine("=== Palavras digitadas: ===");
            foreach (var palavra in palavras)
            {
                Console.WriteLine(palavra);
            }
        }

    }
}

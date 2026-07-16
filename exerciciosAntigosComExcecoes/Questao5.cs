using System;

namespace Questao5
{
    internal class Questao5
    {
        static void Main(string[] args)
        {
            string senhaDigitada;
            int numTentativas = 0;
            bool continuar = true;

            do
            {
                try
                {
                    Console.WriteLine("Digite a senha");
                    senhaDigitada = Console.ReadLine();
                }
                catch(System.NullReferenceException ex)
                {
                    Console.WriteLine($"ERRO: Valor nulo - Informe uma senha válida \n {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"ERRO: {ex.Message}");
                }


                if (senhaDigitada == "teste")
                {
                    Console.WriteLine("ACESSO PERMITIDO");
                    continuar = false;

                    if (numTentativas > 0)
                    {
                        Console.WriteLine($"Número de tentativas: {numTentativas}");
                        continuar = false;
                    }

                }

                else
                {
                    Console.WriteLine("ACESSO NEGADO!");
                    numTentativas++;
                }

            }
            while (continuar == true);

            finally{
                Console.WriteLine("Programa Finalizado!");
            }

            Console.ReadKey();
        }
    }
}

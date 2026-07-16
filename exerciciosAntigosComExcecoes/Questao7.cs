using System;

namespace Questao7
{
    internal class Questao7
    {
        static void Main(string[] args)
        {
            int numero, fatorial = 1;

            do
            {
                try
                {
                    Console.WriteLine("Informe o número para o valor fatorial:");
                    numero = int.Parse(Console.ReadLine());

                    for (int i = 1; i <= numero; i++)
                    {
                        fatorial *= i;
                    }
                }
                catch (System.NullReferenceException ex)
                {
                    Console.WriteLine("Informe um valor válido");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: {ex.Message}");
                }

                finally
                {
                    Console.WriteLine($"Fatorial: {fatorial}");
                    Console.ReadKey();
                }
                return;
            }
            while (true);
            
        }
    }
}

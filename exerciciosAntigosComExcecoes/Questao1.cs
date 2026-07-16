using System;

namespace Questao1
{
    internal class Questao1
    {
        static void Main(string[] args)
        {
            Single numero1, numero2 = 0;

            try
            {
                Console.WriteLine("Informe o primeiro número: ");
                numero1 = Single.Parse(Console.ReadLine());
            }
            catch(System.ArgumentNullException ex)
            {
                Console.WriteLine($"ERRO: Valor nulo - Informe um valor! \n{ex.Message}");
            }

            try
            {
                Console.WriteLine("Informe o segundo número: ");
                numero2 = Single.Parse(Console.ReadLine());
            }
            catch (System.DivideByZeroException ex)
            {
                Console.WriteLine($"ERRO: Divisão por zero - Não se pode dividir por 0! \n{ex.Message}");
            }
            catch(System.ArgumentNullException ex)
            {
                Console.WriteLine($"ERRO: Valor nulo - Informe um valor! \n{ex.Message}");
            }

            finally
            {
                Single divisao = numero1 / numero2;

                Console.WriteLine($"Resultado da divisão: {divisao:f2}");
                Console.ReadKey();
            }
        }

    }
}

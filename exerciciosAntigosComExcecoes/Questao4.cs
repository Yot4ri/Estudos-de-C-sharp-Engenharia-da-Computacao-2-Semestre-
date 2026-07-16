using System;

namespace Questao4
{
    internal class Questao4
    {
        static void Main(string[] args)
        {
            float nota1, nota2, media;
            bool continuar;
            int testeContinuar;

            do
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Informe a primeira nota: ");
                        nota1 = float.Parse(Console.ReadLine());

                        if (nota1 < 0 || nota1 > 10)
                        {
                            Console.WriteLine("\n ERRO - Nota Inválida: Informe um número entre 1 a 10;");
                        }
                    }
                    catch (System.InvalidCastException ex)
                    {
                        Console.WriteLine($"ERRO - Valor inválido: Informe um número {ex.Message}");
                    }
                    catch (System.NullReferenceException ex)
                    {
                        Console.WriteLine($"ERRO - Valor nulo: Informe ao menos um número {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERRO: {ex.Message}");
                    }

                }
                while (nota1 < 0 || nota1 > 10);

                do
                {
                    try
                    {
                        Console.WriteLine("Informe a primeira nota: ");
                        nota2 = float.Parse(Console.ReadLine());

                        if (nota2 < 0 || nota2 > 10)
                        {
                            Console.WriteLine("\n ERRO - Nota Inválida: Informe um número entre 1 a 10;");
                        }
                    }
                    catch (System.InvalidCastException ex)
                    {
                        Console.WriteLine($"ERRO - Valor inválido: Informe um número {ex.Message}");
                    }
                    catch (System.NullReferenceException ex)
                    {
                        Console.WriteLine($"ERRO - Valor nulo: Informe ao menos um número {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERRO: {ex.Message}");
                    }
                }
                while (nota2 < 0 || nota2 > 10);

                media = (nota1 + nota2) / 2;

                Console.WriteLine($"A média do aluno é {media:f2}.");
                Console.WriteLine("\nNovo cálculo? \n1.Sim \n2.Não");
                testeContinuar = int.Parse(Console.ReadLine());

                if (testeContinuar == 1)
                {
                    continuar = true;
                }
                else
                {
                    continuar = false;
                }
            }
            while (continuar == true);

            finally{
                Console.WriteLine("\nPrograma finalizado.");
                Console.ReadKey();
            }
        }
    }
}

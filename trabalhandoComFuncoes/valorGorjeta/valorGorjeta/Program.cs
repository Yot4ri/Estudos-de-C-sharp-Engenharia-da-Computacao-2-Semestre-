using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace valorGorjeta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float porcentagemGorjeta = 0, valorConta = 0, total = 0, valorGorjeta = 0;
            int opcao = 0;
            Boolean continuarMenu = true;


            do
            {
                try
                {
                    Console.WriteLine("=== Calculadora de gorjeta ===");
                    Console.WriteLine("\nInforme o valor total da conta");
                    valorConta = float.Parse(Console.ReadLine());

                    Console.WriteLine("Informe a porcentagem de Gorjeta");
                    porcentagemGorjeta = float.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"ERRO 1: VALOR NULO - Informe um valor válido\n{ex.Message} \n");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ERRO 2: VALOR INVÁLIDO - Informe um valor válido\n{ex.Message} \n");
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"ERRO 3: FORMATO INVÁLIDO - Informe um número válido\n{ex.Message}\n");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO 4: INDEFINIDO\n{ex.Message} \n ");
                    break;
                }
            }
            while (valorConta == 0 || porcentagemGorjeta == 0);
            do
            {
                Console.WriteLine("\nInforme a opção desejada:\n1 - Calcular Gorjeta\n2 - Exibir total");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        total = CalcularGorjeta(valorConta, porcentagemGorjeta);
                        valorGorjeta = total - valorConta;
                        VoltarMenu();

                        break;

                    case 2:
                        ExibirConta(total, valorGorjeta);
                        VoltarMenu();

                        break;

                    default:
                        Console.WriteLine("Opção inexistente");
                        VoltarMenu();

                        break;
                }
            }
            while (continuarMenu == true);

        }

        static float CalcularGorjeta(float total, float porcentagemDesconto)
        {

            float valorConta = 0;
            float valorGorjeta = 0;
            char continuar = 'S';

            do
            {
                try
                {
                    if (total == 0)
                    {
                        throw new ArgumentNullException();
                    }

                    else
                    {
                        valorGorjeta = total * (porcentagemDesconto / 100);
                        valorConta = total + valorGorjeta;
                        continuar = 'N';
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"ERRO: Valor Nulo! - Informe um valor válido! \n {ex.Message}\n");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: - {ex.Message} \n");
                    break;
                }
            }
            while (continuar == 'S');

            return valorConta;

        }

        static void ExibirConta(float total, float valorGorjeta)
        {
            char continuar = 'S';

            do
            {
                try
                {
                    if (total == 0)
                    {
                        throw new ArgumentException("Valor da conta não pode ser zero.");
                    }
                    else
                    {
                        Console.WriteLine($"Valor da conta: {total:f2}");
                        Console.WriteLine($"Valor da gorjeta: {valorGorjeta:f2}");
                        Console.WriteLine($"Total a pagar: {(total):f2}");
                        continuar = 'N';
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"ERRO: Valor Nulo! - Informe um valor válido! \n {ex.Message}\n");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: - {ex.Message} \n");
                    break;
                }
            }
            while (continuar == 'S');
        }

        static void VoltarMenu()
        {
            char resposta;

            Console.Write("\nDeseja voltar ao menu? (S/N)\n");
            resposta = char.Parse(Console.ReadLine().ToUpper());

            if (resposta == 'S')
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine("Encerrando o programa...");
                Console.ReadKey();
                Environment.Exit(0); //Encerra o programa
            }
        }

    }
}

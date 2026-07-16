using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carteiraCriptomoeda
{
    internal class Program
    {

        static void Main(string[] args)
        {
            double saldo = 0.0;
            int opcao = 0;
            string carteiraOrigem = "";
            Boolean cadastrado = false, continuarMenu = true;

            Console.WriteLine("===Simulador de criptomoedas===\n");

            do
            {
                try
                {
                    Console.WriteLine("\nInforme o saldo:");
                    saldo = double.Parse(Console.ReadLine());

                    Console.WriteLine("\nInforme o código da carteira");
                    carteiraOrigem = Console.ReadLine();

                    if (carteiraOrigem.Length != 34)
                    {
                        throw new ArgumentException("\nInforme uma carteira válida (mínimo de 34 caracteres)");
                    }
                    cadastrado = true;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"\nERRO: Valor nulo - Informe um número\n{ex.Message}\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"\nERRO: Valor inválido - Informe um número\n{ex.Message}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nERRO: Ocorreu um erro inesperado\n{ex.Message}\n");
                }
            }
            while (cadastrado == false);

            do
            {
                Console.WriteLine($"\nSaldo inicial: {saldo:f2}\n");
                Console.WriteLine($"Informe uma opção do menu\n1 - Realizar nova transação\n2 - Consultar saldo\n3 - Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        RealizarTransacao(ref saldo, carteiraOrigem);

                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Carteira de {carteiraOrigem}\n");
                        Console.WriteLine($"Saldo atual: R${saldo:f2}");

                        VoltarMenu(ref continuarMenu);

                        break;

                    case 3:

                        Console.WriteLine("Encerrando o programa...");
                        Console.ReadKey();
                        Environment.Exit(0); //Encerra o programa
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        VoltarMenu(ref continuarMenu);

                        break;
                }
            }
            while (continuarMenu == true);

        }

        static void RealizarTransacao(ref double saldo, string carteiraOrigem)
        {
            string carteiraDestino = "";
            double valorTransferencia = 0;

            try
            {
                Console.WriteLine("\nInforme a carteira de destino");
                carteiraDestino = Console.ReadLine();

                if (carteiraDestino.Length != 34)
                {
                    throw new ArgumentException("\nInforme uma carteira válida (mínimo de 34 caracteres)\n");
                }
                else if (carteiraDestino == "")
                {
                    throw new ArgumentNullException();
                }

                Console.WriteLine("\nInforme o valor a ser transferido:\n");
                valorTransferencia = double.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"\nERRO: Valor nulo - Informe um número\n{ex.Message}\n");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nERRO: Valor inválido - Informe um número\n{ex.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERRO: Ocorreu um erro inesperado\n{ex.Message}\n");
            }

            if (ValidarTransacao(saldo, carteiraOrigem, carteiraDestino, valorTransferencia) == true)
            {
                saldo = saldo - valorTransferencia;
            }
        }

        static Boolean ValidarTransacao(double saldoAtual, string carteiraOrigem, string carteiraDestino, double valor)
        {
            try
            {
                if (saldoAtual < valor)
                {
                    throw new InvalidOperationException("\nValor da transferência é maior que o saldo!");
                }
                else if(carteiraOrigem == carteiraDestino)
                {
                    throw new ArgumentException("\nNão se pode transferir para uma mesma carteira!");
                }
                else
                {
                    Console.WriteLine("\nTransferência concluída com sucesso!");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\nHouve um erro durante a transação {ex.Message}");
                return false;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return true;
        }


        static void VoltarMenu(ref Boolean continuarMenu)
        {
            char resposta='0';

            try
            {
                Console.Write("\nDeseja voltar ao menu? (S/N)\n");
                resposta = char.Parse(Console.ReadLine().ToUpper());

            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERRO: Indefinido - {ex.Message}");
            }

            if (resposta == 'S')
            {
                Console.Clear();
                return;
            }
            else
            {
                continuarMenu = false;
                Console.WriteLine("Encerrando o programa...");
                Console.ReadKey();
                Environment.Exit(0); //Encerra o programa
            }
        }
    }
}

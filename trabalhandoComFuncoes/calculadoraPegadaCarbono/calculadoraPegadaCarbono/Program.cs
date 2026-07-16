using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculadoraPegadaCarbono
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            bool continuarMenu = true;
            double totalCarbono = 0;

            Console.WriteLine("=== EcoTracker - Calculadora de Pegada de Carbono ===");

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1 - Calcular Viagem Única");
                Console.WriteLine("2 - Calcular Viagem com Múltiplos Trechos");
                Console.WriteLine("3 - Ver Total Acumulado");
                Console.WriteLine("4 - Sair");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:

                        try
                        {
                            Console.WriteLine("Distância (km):");
                            double distancia = double.Parse(Console.ReadLine());

                            Console.WriteLine("Tipo de transporte (CARRO/METRO/ONIBUS):");
                            string transporte = Console.ReadLine().ToUpper();

                            double resultado = CalcularPegadaCarbono(distancia, transporte);

                            Console.WriteLine($"Pegada de carbono: {resultado:F2} kg CO2");
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }

                        break;

                    case 2:

                        char continuar = 'S';

                        do
                        {
                            AdicionarTrecho(ref totalCarbono);

                            Console.WriteLine("Adicionar outro trecho? (S/N)");
                            continuar = char.Parse(Console.ReadLine().ToUpper());

                        } while (continuar == 'S');

                        break;

                    case 3:

                        Console.WriteLine($"Total acumulado de CO2: {totalCarbono:F2} kg");
                        break;

                    case 4:

                        continuarMenu = false;
                        Console.Clear();
                        Console.WriteLine("Encerrando programa...");
                        break;

                    default:

                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (continuarMenu);
        }


        static double CalcularPegadaCarbono(double distanciaKm, string tipoTransporte)
        {
            if (distanciaKm < 0)
                throw new ArgumentOutOfRangeException("Distância não pode ser negativa.");

            double fator;

            switch (tipoTransporte)
            {
                case "CARRO":
                    fator = 0.17;
                    break;

                case "METRO":
                    fator = 0.03;
                    break;

                case "ONIBUS":
                    fator = 0.09;
                    break;

                default:
                    throw new ArgumentException("Tipo de transporte inválido.");
            }

            return distanciaKm * fator;
        }


        static void AdicionarTrecho(ref double totalCarbono)
        {
            try
            {
                Console.WriteLine("Distância do trecho (km):");
                double distancia = double.Parse(Console.ReadLine());

                Console.WriteLine("Tipo de transporte (CARRO/METRO/ONIBUS):");
                string transporte = Console.ReadLine().ToUpper();

                double resultado = CalcularPegadaCarbono(distancia, transporte);

                totalCarbono += resultado;

                Console.Clear();
                Console.WriteLine($"Trecho adicionado: {resultado:F2} kg CO2");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar trecho: {ex.Message}");
            }
        }
    }
}

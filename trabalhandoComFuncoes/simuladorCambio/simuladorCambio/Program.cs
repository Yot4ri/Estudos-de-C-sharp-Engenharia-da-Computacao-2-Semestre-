using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simuladorCambio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            bool continuarMenu = true;

            List<decimal> historico = new List<decimal>();

            Console.WriteLine("=== Simulador de Mercado de Câmbio ===");

            do
            {
                Console.WriteLine("\n1 - Consultar Cotação do Dólar");
                Console.WriteLine("2 - Converter BRL para USD");
                Console.WriteLine("3 - Ver Histórico de Cotações");
                Console.WriteLine("4 - Sair");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:

                        try
                        {
                            decimal cotacao = ObterCotacaoDolar();

                            historico.Add(cotacao);

                            Console.WriteLine($"Cotação atual: R$ {cotacao:F2}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case 2:

                        try
                        {
                            Console.WriteLine("Valor em BRL:");
                            decimal brl = decimal.Parse(Console.ReadLine());

                            decimal cotacao = ObterCotacaoDolar();

                            historico.Add(cotacao);

                            decimal usd = brl / cotacao;

                            Console.WriteLine($"USD: {usd:F2}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case 3:

                        if (historico.Count == 0)
                        {
                            Console.WriteLine("Nenhuma cotação registrada.");
                        }
                        else
                        {
                            Console.WriteLine("Histórico:");

                            foreach (decimal cotacao in historico)
                            {
                                Console.WriteLine($"R$ {cotacao:F2}");
                            }
                        }

                        break;

                    case 4:

                        continuarMenu = false;
                        break;
                }

            } while (continuarMenu);
        }


        static decimal ObterCotacaoDolar()
        {
            Random random = new Random();

            int chance = random.Next(1, 101);

            if (chance <= 70)
            {
                decimal valor = (decimal)(random.NextDouble() * 0.5 + 5.0);
                return valor;
            }
            else
            {
                throw new InvalidOperationException("O mercado está instável no momento.");
            }
        }
    }
}

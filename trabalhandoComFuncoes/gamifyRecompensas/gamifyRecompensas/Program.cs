using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamifyRecompensas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            bool continuarMenu = true;
            int totalMoedas = 0;

            Console.WriteLine("=== GamifyRewards ===");

            do
            {
                Console.WriteLine("\n1 - Registrar Tarefa Concluída");
                Console.WriteLine("2 - Simular Dia de Trabalho");
                Console.WriteLine("3 - Consultar Total de Moedas");
                Console.WriteLine("4 - Sair");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:

                        try
                        {
                            Console.WriteLine("Nível de dificuldade (1-5):");
                            int nivel = int.Parse(Console.ReadLine());

                            Console.WriteLine("Tempo gasto (segundos):");
                            int tempo = int.Parse(Console.ReadLine());

                            int recompensa = CalcularRecompensa(nivel, tempo);

                            totalMoedas += recompensa;

                            Console.WriteLine($"Você ganhou {recompensa} moedas!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case 2:

                        Random random = new Random();

                        for (int i = 0; i < 5; i++)
                        {
                            int nivel = random.Next(1, 6);
                            int tempo = random.Next(10, 60);

                            int recompensa = CalcularRecompensa(nivel, tempo);

                            totalMoedas += recompensa;

                            Console.WriteLine($"Tarefa {i + 1}: +{recompensa} moedas");
                        }

                        break;

                    case 3:

                        Console.WriteLine($"Total de moedas: {totalMoedas}");
                        break;

                    case 4:

                        continuarMenu = false;
                        break;
                }

            } while (continuarMenu);
        }


        static int CalcularRecompensa(int nivelDificuldade, int tempoGastoSegundos)
        {
            if (nivelDificuldade < 1 || nivelDificuldade > 5)
                throw new ArgumentOutOfRangeException("Nível de dificuldade inválido. Deve ser entre 1 e 5.");

            if (tempoGastoSegundos < 0)
                throw new ArgumentOutOfRangeException("O tempo gasto não pode ser negativo.");

            int recompensa = nivelDificuldade * 10;

            if (tempoGastoSegundos < 30)
                recompensa += 50;

            return recompensa;
        }
    }
}

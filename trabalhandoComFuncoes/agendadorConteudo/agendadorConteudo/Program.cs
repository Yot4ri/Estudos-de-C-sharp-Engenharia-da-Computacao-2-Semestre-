using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendadorConteudo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            bool continuarMenu = true;

            List<string> postsAgendados = new List<string>();

            Console.WriteLine("=== SocialScheduler ===");

            do
            {
                Console.WriteLine("\n1 - Agendar Novo Post");
                Console.WriteLine("2 - Visualizar Posts Agendados");
                Console.WriteLine("3 - Limpar Agendamentos");
                Console.WriteLine("4 - Sair");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:

                        try
                        {
                            Console.WriteLine("Digite o texto do post:");
                            string texto = Console.ReadLine();

                            Console.WriteLine("Data do agendamento (dd/mm/aaaa hh:mm):");
                            DateTime data = DateTime.Parse(Console.ReadLine());

                            string postFormatado = FormatarPostAgendado(texto, data);

                            postsAgendados.Add(postFormatado);

                            Console.WriteLine("Post agendado com sucesso!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro inesperado: {ex.Message}");
                        }

                        break;

                    case 2:

                        if (postsAgendados.Count == 0)
                        {
                            Console.WriteLine("Nenhum post agendado.");
                        }
                        else
                        {
                            Console.WriteLine("\nPosts agendados:");

                            foreach (string post in postsAgendados)
                            {
                                Console.WriteLine(post);
                            }
                        }

                        break;

                    case 3:

                        postsAgendados.Clear();
                        Console.WriteLine("Todos os agendamentos foram removidos.");

                        break;

                    case 4:

                        continuarMenu = false;
                        Console.WriteLine("Encerrando programa...");
                        break;

                    default:

                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (continuarMenu);
        }


        static string FormatarPostAgendado(string texto, DateTime dataAgendamento)
        {
            if (string.IsNullOrWhiteSpace(texto) || texto.Length > 280)
            {
                throw new ArgumentException("O texto do post excede o limite de 280 caracteres ou está vazio.");
            }

            if (dataAgendamento < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("A data de agendamento não pode ser no passado.");
            }

            return $"[{dataAgendamento:dd/MM/yyyy HH:mm}] - {texto}";
        }
    }
}

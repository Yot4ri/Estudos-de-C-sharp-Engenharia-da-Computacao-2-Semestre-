    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace comandoDrone
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                int opcao = 0;
                double altitude = 0.0, distancia = 0.0;
                bool continuarMenu = true;
                string comando;
                char testeContinuar = 'S';

                Console.WriteLine("=== Processador de Comandos de Drone ===");

                do
                {
                    Console.WriteLine($"\nAltitude atual: {altitude} metros\nDistância atual: {distancia} metros\n");

                    Console.WriteLine($"Informe uma opção do menu\n1 - Comando individual\n2 - Rota Pré-Definida\n3 - Sair");
                    opcao = int.Parse(Console.ReadLine());


                    switch (opcao)
                    {
                        case 1:
                            try
                            {
                                Console.WriteLine("Informe a direção para mover: (SUBIR/DESCER/AVANÇAR/RETORNAR)");
                                comando = Console.ReadLine().ToUpper();

                                if(comando != "SUBIR" && comando != "DESCER" && comando != "AVANÇAR" && comando != "RETORNAR")
                                {
                                    throw new InvalidOperationException();
                                }
                                else
                                {
                                    ExecutarComandoDrone(comando, ref altitude, ref distancia);
                                }
                            }
                            catch (ArgumentNullException ex)
                            {
                                Console.WriteLine($"ERRO: VALOR NULO - Informe um valor válido\n{ex.Message} \n");
                                break;
                            }
                            catch(InvalidOperationException ex) 
                            {
                                Console.WriteLine($"Comando inválido - Informe um comando válido\n{ex.Message}\n");
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"ERRO INDEFINIDO - Informe um valor válido\n{ex.Message} \n");
                                break;
                            }

                            VoltarMenu(ref continuarMenu);
                            break;

                        case 2:
                            String[] rota = new string[4];
                            for(int i = 0; i < 4; i++)
                            {
                            try
                            {
                                Console.WriteLine($"Informe a direção para mover: (SUBIR/DESCER/AVANÇAR/RETORNAR)");
                                Console.WriteLine($"Comando {i + 1} de 4");
                                comando = Console.ReadLine().ToUpper();
                                    if (comando != "SUBIR" && comando != "DESCER" && comando != "AVANÇAR" && comando != "RETORNAR")
                                    {
                                        throw new InvalidOperationException();
                                    }
                                    else
                                    {
                                        rota[i] = comando;
                                        Console.WriteLine("Informar um novo comando? (S/N)");
                                        testeContinuar = char.Parse(Console.ReadLine().ToUpper());
                                        if (testeContinuar == 'N')
                                        {
                                            break;
                                        }
                                    }
                                }
                                catch (ArgumentNullException ex)
                                {
                                    Console.WriteLine($"ERRO: VALOR NULO - Informe um valor válido\n{ex.Message}\n");
                                    break;
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine($"Comando inválido - Informe um comando válido\n{ex.Message}\n");
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"ERRO INDEFINIDO - Informe um valor válido\n{ex.Message}\n");
                                    break;
                                }
                            }
                            
                            ExecutarRota(rota, ref altitude, ref distancia);
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
                while (continuarMenu);
            }

            static void ExecutarComandoDrone(string comando, ref double altitude, ref double distancia)
            {
                switch (comando)
                {
                    case "SUBIR":
                        altitude += 5;
                        Console.WriteLine($"Drone subiu para {altitude} metros.");
                        break;

                    case "DESCER":
                        if (altitude >= 5) 
                        {
                            altitude -= 5;
                            Console.WriteLine($"Drone desceu para {altitude}");
                        }
                        break;

                    case "AVANÇAR":
                        distancia += 5;
                        Console.WriteLine($"Drone avançou para {distancia} metros.");
                        break;

                    case "RETORNAR":
                        if(distancia >= 5)
                        {
                            distancia -= 5;
                            Console.WriteLine($"Drone retornou para {distancia} metros.");
                        }
                    break;
                }
            }

            static void ExecutarRota(String[] rota, ref double altitude, ref double distancia)
            {
                foreach(string comando in rota) //para cada comando na rota, executa o comando do drone
                {
                    if (comando != null)
                    {
                        ExecutarComandoDrone(comando, ref altitude, ref distancia);
                    }
                }
            }
            static void VoltarMenu(ref bool continuarMenu)
            {
                char resposta = '0';

                try
                {
                    Console.Write("\nDeseja voltar ao menu? (S/N)\n");
                    resposta = char.Parse(Console.ReadLine().ToUpper());

                }
                catch (Exception ex)
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
                }
            }
        }
    }

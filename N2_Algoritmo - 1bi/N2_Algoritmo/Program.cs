using System;

namespace N2_Algoritmo
{
    internal class Program
    {
        /*O Programa tem como principal funcionalidade cadastrar e atualizar os dados de um único animal de modo a registrar o seu estágio de tratamento dentro 
         * do ambiente de uma clínica veterinária. Os valores são armazenados em variáveis, mas, para futuras evoluções, pode ser integrado a um sistema de Banco de
         * dados, permitindo assim, o armazenamento dos dados*/
        static void Main(string[] args)
        {

            //Declaração de variáveis que serão utilizadas no decorrer do código
            int opcao,idResgate = 0, idadeAnimal = 0, situacaoAnimal = 0; //1 = Em tratamento; 2 = Disponível; 3 = Adotado
            Boolean continuarMenu = true;
            String nomeAnimal = "", especieAnimal = "", textoSituacaoAnimal = "";

            Console.WriteLine("=== PROJETO SALVADORES DE ANJOS ===\n");

            do
            {
                //Coleta de opção que será utilizada no menu adiante
                try 
                {
                    Console.WriteLine("Informe a opção desejada:\n1 - Informar dados do Animal\n2 - Atualizar situação do animal\n3 - Exibir dados do Animal atual\n4 - Novo cadastro (limpar dados)\n5 - sair\n");
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"ERRO 1: VALOR NULO \n{ex.Message} \n");
                    opcao = 0;
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ERRO 2: VALOR INVÁLIDO \n{ex.Message} \n");
                    opcao = 0;
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"ERRO 3: FORMATO INVÁLIDO \n{ex.Message}\n");
                    opcao = 0;
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO 4: INDEFINIDO \n{ex.Message} \n ");
                    opcao = 0;
                    break;
                }

                //Resultado do menu de opções, que solicita a função de acordo com o que foi indicado anteriormente
                switch (opcao)
                {

                    case 1://Informar dados do Animal
                        informarDadosAnimal(ref idResgate, ref nomeAnimal, ref especieAnimal, ref idadeAnimal, ref situacaoAnimal, ref textoSituacaoAnimal);
                        VoltarMenu();

                        break;

                    case 2://Atualizar dados do Animal
                        atualizarAnimal(ref idResgate, ref situacaoAnimal, ref nomeAnimal, ref textoSituacaoAnimal);
                        VoltarMenu();

                        break;

                    case 3://Exibir dados do Animal
                        ExibirDados(ref idResgate, ref nomeAnimal, ref especieAnimal, ref idadeAnimal, ref situacaoAnimal, ref textoSituacaoAnimal);
                        VoltarMenu();

                        break;

                    case 4://Limpar dados armazenados nas variáveis, de modo a "resetar" todo o processo
                        LimparDados(ref idResgate, ref nomeAnimal, ref especieAnimal, ref idadeAnimal, ref situacaoAnimal, ref textoSituacaoAnimal);
                        VoltarMenu();

                        break;

                    case 5://Encerra o ambiente
                        Console.WriteLine("Encerrando o programa...");
                        Environment.Exit(0);
                        
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inexistente");
                        VoltarMenu();

                        break;
                }
            }
            while(continuarMenu);
            
        }

        /*Função destinada à coleta e tratamento de exceções para o caso de ser solicitado o cadastro de um novo animal, ou seja,
         * é onde o usuário informa todos os dados sobre o animal*/
        static void informarDadosAnimal(ref int idResgate, ref string nomeAnimal, ref string especieAnimal, ref int idadeAnimal, ref int situacaoAnimal, ref String textoSituacaoAnimal)
        {
            try //Valida o Id de resgate
            {
                Console.Clear();
                Console.WriteLine("\nInforme o ID do resgate");
                idResgate = int.Parse(Console.ReadLine());

                if(idResgate <= 0)
                {
                    idResgate = 0;
                    throw new Exception("O ID de resgate deve ser maior que zero");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Entrada inválida, digite apenas números");
                idResgate = 0;
                return;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"VALOR NULO");
                idResgate = 0;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                idResgate = 0;
                return;
            }

            try //Valida a idade do animal
            {
                Console.WriteLine("\nInforme a idade do Animal:");
                idadeAnimal = int.Parse(Console.ReadLine());

                if(idadeAnimal < 0 || idadeAnimal > 30)
                {
                    idResgate = 0;
                    idadeAnimal = 0;
                    throw new Exception("Idade inválida. Deve ser entre 0 e 30 anos");
                }
            }
            catch (FormatException)
            {
                idResgate = 0;
                idadeAnimal = 0;
                Console.WriteLine("Entrada inválida, digite apenas números");
                return;
            }
            catch (ArgumentNullException)
            {
                idResgate = 0;
                idadeAnimal = 0;
                Console.WriteLine($"VALOR NULO");
                return;
            }
            catch (Exception ex)
            {
                idResgate = 0;
                idadeAnimal = 0;
                Console.WriteLine($"ERRO: {ex.Message}");
                return;
            }

            try //Validação do Nome
            {
                Console.WriteLine("\nInforme o nome do Animal:");
                nomeAnimal = Console.ReadLine();

                if(nomeAnimal == "")
                {
                    idResgate = 0;
                    idadeAnimal = 0;
                    throw new ArgumentNullException("Nome não podem ser vazio!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                nomeAnimal = "";
                idResgate = 0;
                idadeAnimal = 0;
                return;
            }

            try //Validação da Espécie
            {
                Console.WriteLine("\nInforme a espécie do Animal:");
                especieAnimal = Console.ReadLine();

                if (especieAnimal == "")
                {
                    nomeAnimal = "";
                    idResgate = 0;
                    idadeAnimal = 0;
                    throw new ArgumentNullException("Espécie não podem ser vazio!");
                }
            }
            catch (Exception ex)
            {
                nomeAnimal = "";
                idResgate = 0;
                idadeAnimal = 0;
                especieAnimal = "";
                Console.WriteLine($"ERRO: {ex.Message}");
                return;
            }

            if (idResgate != 0 && nomeAnimal != "" && especieAnimal != "" && idadeAnimal != 0)
            {
                situacaoAnimal = 1;
                textoSituacaoAnimal = "Em tratamento";
                Console.Clear();
                Console.WriteLine($"Animal: '{nomeAnimal}'\nID: {idadeAnimal}\n\nCadastrado com sucesso!\nSituação inicial: {textoSituacaoAnimal}");
            }
        }

        /*Função destinada à atualização e tratamento de exceções para o caso de ser solicitado a atualização dos dados do animal. De forma específica, permite
         * a alteração da situação do Animal, mas não altera as outras varíáveis do programa*/
        static void atualizarAnimal(ref int idResgate, ref int situacaoAnimal, ref string nomeAnimal, ref String textoSituacaoAnimal)
        {
            int testeSituacao = 0;

            if(idResgate == 0)
            {
                Console.Clear();
                Console.WriteLine("Nenhum animal cadastrado para atualizar. Por favor, cadastre um animal primeiro.");
                return;
            }
            else
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Informe a situação do animal: \n1 - Em tratamento | 2 - Disponível | 3 - Adotado.");
                    testeSituacao = int.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("VALOR NULO.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Digite apenas números.");
                }

                switch (testeSituacao)
                {
                    case 1:
                        Console.WriteLine("Transição de situação inválida.");
                        return;

                    case 2:
                        if(situacaoAnimal == 1)
                        {
                            situacaoAnimal = testeSituacao;
                        }
                        else
                        {
                            Console.WriteLine("Transição de situação inválida.");
                            return;
                        }
                            break;

                    case 3:
                        if(situacaoAnimal == 1)
                        {
                            Console.WriteLine("Animal ainda em tratamento.");
                            return;
                        }
                        if(situacaoAnimal == 2)
                        {
                            situacaoAnimal = testeSituacao;
                        }
                        else
                        {
                            Console.WriteLine("Animal já adotado. Situação final.");
                            return;
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inexistente.");
                        break;
                }
            }

            if(situacaoAnimal == testeSituacao)
            {

                //Switch para alterar o texto da situação, que será utilizado para informar o usuário futuramente
                switch (situacaoAnimal)
                {
                    case 1:
                        textoSituacaoAnimal = "Em tratamento";
                        break;

                    case 2:
                        textoSituacaoAnimal = "Disponível";
                        break;

                    case 3:
                        textoSituacaoAnimal = "Adotado";
                        break;
                }

                Console.Clear();
                Console.WriteLine($"Situação do animal {nomeAnimal} atualizada para: {textoSituacaoAnimal}.");
            }
        }

        /*Destinada a exibição dos dados do animal*/
        static void ExibirDados(ref int idResgate, ref string nomeAnimal, ref string especieAnimal, ref int idadeAnimal, ref int situacaoAnimal, ref string textoSituacaoAnimal)
        {
            if(idResgate == 0)
            {
                Console.Clear();
                Console.WriteLine("Nenhum animal cadastrado para atualizar. Por favor, cadastre um animal primeiro.");
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"====== DADOS DO ANIMAL ======\nID de resgate: {idResgate}\nNome: {nomeAnimal}\nEspécie: {especieAnimal}\nIdade: {idadeAnimal}\nSituação: {textoSituacaoAnimal}");
            }
        }

        /*Tem o objetivo de "resetar" os dados das variáveis, deletando qualquer coisa que estivesse armazenada nelas*/
        static void LimparDados(ref int idResgate, ref string nomeAnimal, ref string especieAnimal, ref int idadeAnimal, ref int situacaoAnimal, ref string textoSituacaoAnimal)
        {
            idResgate = 0;
            nomeAnimal = "";
            especieAnimal = "";
            idadeAnimal = 0;
            situacaoAnimal = 0;
            textoSituacaoAnimal = "";

            Console.Clear();
            Console.WriteLine("Dados do animal limpos. Pronto para um novo cadastro.");
        }

        /*Pergunta ao usuário se ele deseja retornar ao Menu, caso contrário, encerra o programa*/
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
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeDiagnostica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char proceed = 'S';

            int option = 0, testOption;
            char continueMenu = 'S';
            string[] nomes = new string[30];
            string[,] equipamentos = new string[30,3];
            string[] clientesEspeciais = new string[30];
            int[,] diasAlugados = new int[30, 3];
            string nomeCliente;
            int[] total = new int[30];

            do
            {

                //Informa o menu e aguarda uma seleção válida de acordo com as opções disponíveis.
                do
                {
                    try
                    {
                        Console.WriteLine("=== Controle de Locações === \n1 - Cadastrar cliente\n2 - Registrar equipamentos alugados \n3 - Calcular valor da locação\n4 - Listar todos os clientes \n5 - Exibir Clientes Especiais\n6 - Sair\n");
                        testOption = int.Parse(Console.ReadLine());

                        if (testOption > 6 || testOption < 1)
                        {
                            Console.WriteLine("ERRO - Opção inválida \n");
                            continueMenu = 'S';
                        }

                        else
                        {
                            option = testOption;
                            continueMenu = 'N';
                        }
                    }
                    catch(System.NullReferenceException ex) 
                    {
                        Console.WriteLine("ERRO: Valor nulo - Informe ao menos um valor!");
                    }

                } while (continueMenu == 'S');

                //Direciona ao método de acordo com a opção selecionada
                switch (option)
                {
                    case 1:
                        CadastrarCliente();
                        break;

                    case 2:
                        RegistrarEquipamento();
                        break;

                    case 3:
                        CalcularLocacao();
                        break;

                    case 4:
                        ListarTodosClientes();
                        break;

                    case 5:
                        ClientesEspeciais();
                        break;

                    case 6: 

                        proceed = 'N';
                        Console.WriteLine("Precione para fechar");
                        Console.ReadKey();
                        break;
                }

            } while (proceed == 'S');

            //Métodos de execução de acordo com o menu

            //Cadastra os clientes
            void CadastrarCliente()
            {
                string novoNome;
                bool cadastroRealizado = false;

                Console.WriteLine("\nInforme o nome do cliente\n");
                novoNome = Console.ReadLine();

                for(int i = 0; i <= 29; i++){
                    if (nomes[i] == null)
                    {
                        nomes[i] = novoNome;
                        break;
                    }
                    else if(i == 30 && cadastroRealizado == false)
                    {
                        Console.WriteLine("Limite de clientes cadastrados atingido!");
                    }
                }

                Console.WriteLine("Cliente cadastrado com sucesso!");
                ConfirmarContinuacao();
            }

            void RegistrarEquipamento()
            {
                char novoEquipamento = 'S';
                bool realizado = false;
                int testeDiasAlugados;
                Console.WriteLine("\nRegistrar equipamentos alugados\n\nInforme o nome do cliente:");
                nomeCliente = Console.ReadLine();
                

                for (int i = 0; i <= 29; i++)
                {
                    int j = 0;

                    if (nomes[i] == nomeCliente)
                    {
                        do
                        {
                            Console.WriteLine("Informe o equipamento que deseja alugar\n");
                            equipamentos[i,j] = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Informe a quantidade de dias\n");
                                testeDiasAlugados = int.Parse(Console.ReadLine());
                                diasAlugados[i, j] = testeDiasAlugados;

                                if(testeDiasAlugados == 0)
                                {
                                    Console.WriteLine("Informe um número de dias maior que 0");
                                }

                            }
                            while(testeDiasAlugados == 0 || testeDiasAlugados < 0);
                            
                            Console.WriteLine("Gostaria de informar outro equipamento?(S/N)");
                            novoEquipamento = char.Parse(Console.ReadLine().ToUpper());
                            j++;

                            if(novoEquipamento == 'S' && j == 3)
                            {
                                Console.WriteLine("Número máximo de equipamentos informados");
                            }
                        }
                        while (novoEquipamento == 'S' && j <= 2);

                        realizado = true;
                    }
                    else if(i == 30 && realizado == false)
                    {
                        Console.WriteLine("Usuário não encontrado");
                    }
                }
                Console.WriteLine("Equipamentos registrados!\n");
                ConfirmarContinuacao();
            }

            void CalcularLocacao() 
            {
                Console.WriteLine("Informe o nome do cliente");
                nomeCliente = Console.ReadLine();

                for(int i = 0; i <= 29; i++)
                {
                    if (nomes[i] == nomeCliente)
                    {
                        for(int j = 0; j<= 2; j++)
                        {
                             if(equipamentos[i,j] != null)
                            {
                                total[i] = (diasAlugados[i,j] * 50) + total[i];
                            }
                        }                 

                        Console.WriteLine($"=== Locação de: {nomeCliente} ===\nValor: R${total[i]}");       
                    }
                }

                ConfirmarContinuacao();
            }

            //Lista todos os clientes
            void ListarTodosClientes()
            {
                Console.WriteLine("---Clientes cadastrados:--- \n");
                
                for(int i = 0; i <= 29; i++)
                {
                    if (nomes[i] != null)
                    {
                        Console.WriteLine(nomes[i]);
                    }
                }
                ConfirmarContinuacao();
            }

            void ClientesEspeciais()
            {
                int contador = 0;

                for (int i = 0; i <= 29; i++)
                {
                    if (nomes[i] != null)
                    {
                        for (int j = 0; j <= 2; j++)
                        {
                            if (equipamentos[i, j] != null)
                            {
                                total[i] = (diasAlugados[i, j] * 50) + total[i];
                            }
                        }

                        if (total[i] >= 500)
                        {
                            clientesEspeciais[contador] = nomes[i];
                        }

                        Console.WriteLine($"{clientesEspeciais[contador]};");
                    }
                }

                ConfirmarContinuacao();
            }

            //No caso da confirmação ser positiva, o menu voltará a aparecer
            void ConfirmarContinuacao()
            {
                char testContinue;
                do
                {
                    Console.WriteLine("\nDeseja voltar ao menu? (S/N)");
                    testContinue = char.Parse(Console.ReadLine().ToUpper());

                    if(testContinue != 'S' && testContinue != 'N')
                    {
                        Console.WriteLine("ERRO: Valor inválido! - Informe S ou N (Sim/Não)");
                        
                    }

                    else
                    {
                        if(testContinue == 'S')
                        {
                            proceed = 'S';
                        }

                        else
                        {
                            proceed = 'N';
                        }
                    }

                } while (proceed != 'S' && proceed != 'N');

                Console.Clear();
            }
        }
    }
}

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

            int option, testOption;
            char continueMenu;
            string[] nomes = new string[30];
            string[,] equipamentos = new string[30,3];

            do
            {

                //Informa o menu e aguarda uma seleção válida de acordo com as opções disponíveis.
                do
                {
                    Console.WriteLine("=== Controle de Locações === \n1 - Cadastrar cliente\n2 - Registrar equipamentos alugados \n3 - Calcular valor da locação (Não desenvolvido)\n4 - Listar todos os clientes \n5 - Clientes com locação acima de R$500,00(Não desenvolvido) \n6 - Sair");
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
                        
                        break;
                }

            } while (proceed == 'S');

            //Métodos de execução de acordo com o menu

            //Cadastra os clientes
            void CadastrarCliente()
            {
                string novoNome;

                Console.WriteLine("Informe o nome do cliente\n");
                novoNome = Console.ReadLine();

                for(int i = 0; i < 30; i++){
                    if (nomes[i] == null)
                    {
                        nomes[i] = novoNome;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Limite de clientes cadastrados atingido!");
                    }
                }

                Console.WriteLine("Cliente cadastrado com sucesso!");
                ConfirmarContinuacao();
            }

            void RegistrarEquipamento()//Não tenho certeza se esse método funciona como deveria, por estar utilizando matriz
            {
                string nomeCliente, equipamento;
                Console.WriteLine("Registrar equipamentos alugados\n\nInforme o nome do cliente:");
                nomeCliente = Console.ReadLine();

                for(int i = 0; i <= 30; i++)
                {
                    if (nomes[i] == nomeCliente && i < 30)
                    {
                        Console.WriteLine("Cliente encontrado! \n\nInforme os equipamentos alugados: (Um por vez, para finalizar, aperte a tecla ENTER)");
                        equipamento = Console.ReadLine();

                        if(equipamento != "")
                        {
                            for(int j = 0; j <= 3; j++)
                            {
                                if(equipamentos[i,j] == null)
                                {
                                    equipamentos[i,j] = equipamento;
                                    break;
                                }
                                else if(j == 3)
                                {
                                    Console.WriteLine("Limite de equipamentos cadastrados para este cliente atingido!");
                                }
                            }
                        }

                        Console.WriteLine("Gostaria de alugar por quanto tempo? (Em dias)");
                        int tempoLocacao = int.Parse(Console.ReadLine());

                    }
                    else if(i == 30)
                    {
                        Console.WriteLine("Cliente não encontrado!");
                    }
                }

                ConfirmarContinuacao();
            }

            void CalcularLocacao() //Não desenvolvido
            {

                ConfirmarContinuacao();
            }

            //Lista todos os clientes
            void ListarTodosClientes()
            {
                Console.WriteLine("---Clientes cadastrados:--- \n");
                
                for(int i = 0; i <= 30; i++)
                {
                   Console.WriteLine(nomes[i]);
                }
                ConfirmarContinuacao();
            }

            void ClientesEspeciais()
            {

                ConfirmarContinuacao();
            }

            //No caso da confirmação ser positiva, o menu voltará a aparecer
            void ConfirmarContinuacao()
            {
                char testContinue;
                do
                {
                    Console.WriteLine("\nDeseja voltar ao menu? (S/N)");
                    testContinue = char.Parse(Console.ReadLine());

                    if(testContinue != 'S' && testContinue != 'N')
                    {
                        Console.WriteLine("ERRO: Valor inválido! - Informe com S ou N (Sim/Não)");
                        
                        
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
                

            }
        }
    }
}

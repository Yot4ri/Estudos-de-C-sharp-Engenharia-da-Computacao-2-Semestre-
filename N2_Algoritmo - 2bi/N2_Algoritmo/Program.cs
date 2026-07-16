using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N2_Algoritmo
{
    internal class Program
    {
        /*O Programa tem como principal funcionalidade cadastrar e atualizar os dados de um único animal de modo a registrar o seu estágio de tratamento dentro 
         * do ambiente de uma clínica veterinária. Os valores são armazenados em variáveis, mas, para futuras evoluções, pode ser integrado a um sistema de Banco de
         * dados, permitindo assim, o armazenamento dos dados*/


        /*O Dicionário me pareceu o mais adequado para a associação chave-valor (id - valor),
        por conta de não poderem existir vários valores, foram criados vários dicionários,
        que futuramente são lidos individualmente como variáveis 
        em cada um dos métodos que são utilizados*/
        static Dictionary<int, string> nomes = new Dictionary<int, string>();
        static Dictionary<int, string> especies = new Dictionary<int, string>();
        static Dictionary<int, int> idades = new Dictionary<int, int>();
        static Dictionary<int, string> situacoes = new Dictionary<int, string>();

        static void Main(string[] args)
        {

            //Declaração de variáveis que serão utilizadas no decorrer do código
            int opcao,idResgate = 0, idadeAnimal = 0, situacaoAnimal = 0; //1 = Em tratamento; 2 = Disponível; 3 = Adotado
            Boolean continuarMenu = true;
            String nomeAnimal = "", especieAnimal = "", textoSituacaoAnimal = "";
            String caminho = null;


            Console.WriteLine("=== PROJETO SALVADORES DE ANJOS ===\n");

            do
            {
                //Coleta de opção que será utilizada no menu adiante
                try 
                {
                    Console.WriteLine("Informe a opção desejada:\n1 - Informar dados do Animal\n2 - Atualizar situação do animal\n3 - Exibir dados do Animal atual\n4 - Novo cadastro (limpar dados)\n5 - Exibir histórico de resgates\n6 - Exibir histórico ordenado por idade\n7 - Salvar histórico em arquivo\n8 - Carregar histórico de arquivo (Parcialmente desenvolvido, mas não funcional)\n9 - Buscar animal por ID(Não desenvolvido)\n0 - Sair\n");
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
                        continuarMenu = VoltarMenu(continuarMenu);

                        break;

                    case 2://Atualizar dados do Animal
                        atualizarAnimal(ref idResgate, ref situacaoAnimal, ref nomeAnimal, ref textoSituacaoAnimal);
                        continuarMenu = VoltarMenu(continuarMenu);

                        break;

                    case 3://Exibir dados do Animal
                        ExibirDados(ref idResgate, ref nomeAnimal, ref especieAnimal, ref idadeAnimal, ref situacaoAnimal, ref textoSituacaoAnimal);
                        continuarMenu = VoltarMenu(continuarMenu);

                        break;

                    case 4://Limpar dados armazenados nas variáveis, de modo a "resetar" todo o processo
                        LimparDados(ref idResgate, ref nomeAnimal, ref especieAnimal, ref idadeAnimal, ref situacaoAnimal, ref textoSituacaoAnimal);
                        continuarMenu = VoltarMenu(continuarMenu);

                        break;

                    case 5:
                        ExibirHistorico(nomes, especies, idades, situacoes);
                        continuarMenu = VoltarMenu(continuarMenu);
                        break;

                    case 6:
                        ExibirHistoricoOrdenado(nomes, especies, idades, situacoes);
                        continuarMenu = VoltarMenu(continuarMenu);
                        break;

                    case 7:
                        caminho = VerificarArquivo();
                        SalvarHistoricoArquivo(nomes, especies, idades, situacoes, caminho);
                        continuarMenu = VoltarMenu(continuarMenu);
                        break;

                    case 8:
                        caminho = VerificarArquivo();
                        CarregarHistoricoArquivo(caminho, nomes, especies, idades, situacoes);
                        continuarMenu = VoltarMenu(continuarMenu);
                        break;

                    case 9:
                        BuscarPorId();
                        continuarMenu = VoltarMenu(continuarMenu);
                        break;

                    case 0: //Encerra o ambiente
                        Console.Clear();
                        Console.WriteLine("Encerrando o programa...");
                        continuarMenu = false;

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inexistente");
                        VoltarMenu(continuarMenu);

                        break;
                }
            }
            while(continuarMenu == true);
            
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
                Console.WriteLine($"Animal: '{nomeAnimal}'\nID: {idadeAnimal}\nEspécie: {especieAnimal}\nCadastrado com sucesso!\nSituação inicial: {textoSituacaoAnimal}");

                nomes[idResgate] = nomeAnimal;
                especies[idResgate] = especieAnimal;    
                idades[idResgate] = idadeAnimal;
                situacoes[idResgate] = textoSituacaoAnimal;

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

        static void ExibirHistorico(Dictionary<int, string> nomes, Dictionary<int, string> especies, Dictionary<int, int> idades, Dictionary<int, string> situacoes)
        {
            int quantidade = 0;

            Console.Clear();
            Console.WriteLine("\n=== Histórico de resgates do dia ===\n");

            foreach (var registroNome in nomes)
            {
                int registro = registroNome.Key, idadeRegistro = idades[registro];
                string especieRegistro = especies[registro], situacaoRegistro = situacoes[registro];

                quantidade += 1;
                Console.WriteLine($"Id Resgate: {registroNome.Key}\nNome: {registroNome.Value}\nEspécie: {especieRegistro}\nIdade: {idadeRegistro}\nSituação: {situacaoRegistro}\n------------------------------\n");
            }
            if (quantidade == 0)
            {
                Console.WriteLine("Não há registros nessa sessão!");
                return;

            }

        }

        static void ExibirHistoricoOrdenado(Dictionary<int, string> nomes, Dictionary<int, string> especies, Dictionary<int, int> idades, Dictionary<int, string> situacoes)
        {
            int quantidade = 0;
            List<int> listaIdades = new List<int>();

            Console.Clear();
            Console.WriteLine("\n=== Animais ordenados do mais novo ao mais velho ===\n");

            foreach(var registroIdade in idades)//Preenche a lista de idades, para futura ordenação
            {
                listaIdades.Add(registroIdade.Value);
                quantidade += 1;
            }

            if(quantidade >= 1)
            {
                int tamanho = listaIdades.Count; //Tamanho da lista

                //Ordena a lista, e armazena em listaIdades
                for (int i = 0; i < tamanho; i++)
                {
                    int indiceMinimo = i;

                    for (int j = i + 1; j < tamanho; j++)
                    {
                        if (listaIdades[j] < listaIdades[indiceMinimo])
                        {
                            indiceMinimo = j; //Encontra o índice do número que é de fato o menor no vetor
                        }

                        //vetor[i] = número que vai ser substituido de lugar, que está selecionado. 
                        int temp = listaIdades[i];
                        listaIdades[i] = listaIdades[indiceMinimo]; //Substitui o menor número pela posição i
                        listaIdades[indiceMinimo] = temp; //Coloca o número da posição i no lugar onde foi retirado o de menor indice
                    }
                }

                foreach (var registroIdade in idades)
                {
                    foreach (var idadeOrdenada in listaIdades)
                    {
                        if (registroIdade.Value == idadeOrdenada)
                        {
                            int chave = registroIdade.Key;

                            string nome = nomes[chave], especie = especies[chave], situacao = situacoes[chave]; 

                            Console.WriteLine($"Id registro: {registroIdade.Key}\nNome: {nome}\nEspécie: {especie}\nIdade: {registroIdade.Value}\nSituação{situacao}");
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhum animal para ordenar.");
            }
        }

        static void SalvarHistoricoArquivo(Dictionary<int, string> nomes, Dictionary<int, string> especies, Dictionary<int, int> idades, Dictionary<int, string> situacoes, string caminho)
        {

            int quantidade = 0;
            String textoArquivo = "";

            if ((Directory.Exists(caminho) == true && File.Exists($"{caminho}\\animais_salvadores.txt") == false) && caminho != null)
            {
                try
                {
                    foreach (var registroNome in nomes)
                    {
                        int registro = registroNome.Key, idadeRegistro = idades[registro];
                        string especieRegistro = especies[registro], situacaoRegistro = situacoes[registro];

                        quantidade += 1;
                        textoArquivo += $"Id Resgate: {registroNome.Key}\nNome: {registroNome.Value}\nEspécie: {especieRegistro}\nIdade: {idadeRegistro}\nSituação: {situacaoRegistro}\n------------------------------\n\n";
                    }
                    if (quantidade == 0)
                    {
                        Console.WriteLine("Não há registros nessa sessão!");
                        return;

                    }

                    File.WriteAllText("Z:\\EC2\\projetosC#\\N2_Algoritmo\\N2_Algoritmo\\animais_salvadores.txt", textoArquivo);
                    Console.WriteLine("Histórico salvo com sucesso em animais_salvadores.txt.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: {ex.Message}");
                    textoArquivo = null;
                }
            }
            else
            {
                Console.WriteLine("O arquivo já existe!");
            }
        }

        static void CarregarHistoricoArquivo(string caminho, Dictionary<int, string> nomes, Dictionary<int, string> especies, Dictionary<int, int> idades, Dictionary<int, string> situacoes)
        {
            int opcaoCarregarHistorico = 0;


            if (File.Exists(caminho) == true)
            {
                string texto = File.ReadAllText(caminho);
                List<string> registro = new List<string>();

                if (nomes.Values == null)//Não existem registros no histórico;
                {

                }   
                else
                {
                    try
                    {

                        Console.WriteLine("Já existem registros nessa sessão, você gostaria de:\n1 - Substituir pelo histórico do arquivo\n2 – Acumular (adicionar ao histórico atual)?");
                        opcaoCarregarHistorico = int.Parse(Console.ReadLine());

                        if(opcaoCarregarHistorico != 1 && opcaoCarregarHistorico != 2)
                        {
                            throw new FormatException();
                        }
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Informe um número");
                        opcaoCarregarHistorico = 0;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Informe um número válido");
                        opcaoCarregarHistorico = 0;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Erro inesperado {ex.Message}");
                        opcaoCarregarHistorico = 0;
                    }

                    switch (opcaoCarregarHistorico)
                    {
                        case 1:
                            //Pendente==============================================
                            break;

                        case 2:
                            //Pendente==============================================
                            break;

                        default:
                            Console.WriteLine("Informe um número válido de acordo com o menu!");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado. Nenhum dado carregado.");
            }
        }

        static void BuscarPorId()
        {

        }

        static String VerificarArquivo() //Método para verificar a existência de um arquivo ou pasta
        {
            Console.Clear();
            String caminho = null;

            try
            {
                Console.WriteLine("Informe o caminho do arquivo:\n");
                caminho = Console.ReadLine();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("\nERRO: VALOR NULO - Informe o caminho de um arquivo.");
                caminho = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERRO: {ex.Message}");
                caminho = null;
            }

            if (File.Exists(caminho) == true || Directory.Exists(caminho) == true) //Verifica se o caminho existe
            {
                Console.WriteLine("\nO arquivo ou pasta existe no caminho indicado!");
                return caminho;
            }
            else
            {
                Console.WriteLine("\nO arquivo ou pasta não existe no caminho indicado!\n");
                caminho = null;
                return null;
            }

        }

        /*Pergunta ao usuário se ele deseja retornar ao Menu, caso contrário, encerra o programa*/
        static Boolean VoltarMenu(bool continuarMenu)
        {
            char resposta;

            Console.Write("\nDeseja voltar ao menu? (S/N)\n");
            resposta = char.Parse(Console.ReadLine().ToUpper());

            if (resposta == 'S')
            {
                Console.Clear();
                return continuarMenu = true;
            }
            else
            {
                Console.WriteLine("Encerrando o programa...");
                Console.ReadKey();
                continuarMenu = false;
                return false;
            }
        }

        
    }
}
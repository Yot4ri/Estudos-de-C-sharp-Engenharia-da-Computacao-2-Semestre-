using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Mime;

namespace manipulacaoArquivosPastas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            Boolean continuarMenu = true;
            String caminho;


            do
            {
                try
                {
                    Console.WriteLine("=== Gerenciador de Arquivos ===\n\n1 - Verificar existência de arquivo ou pasta\n2 - Criar e renomear pasta\n3 - Criar, renomear ou excluir arquivo de texto\n4 - Ler e editar arquivo de texto\n5 - Listar arquivos e pastas\n6 - Mover arquivos e pastas\n7 - Copiar arquivos e pastas\n8 - Mostrar informações do arquivo/pasta\n");
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERRO: OPÇÃO INVÁLIDA! - Informe um número do Menu!");
                    opcao = 0;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ERRO: VALOR NULO! - Informe um número do Menu!");
                    opcao = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: INDEFINIDO - {ex.Message}");
                    opcao = 0;
                }


                switch (opcao)
                {
                    case 1:
                        caminho = VerificarArquivo(); //Verifica se o arquivo do caminho existe
                        break;

                    case 2:
                        caminho = VerificarArquivo();
                        int opcao2 = 0;

                        if (caminho != null)
                        {
                            try
                            {
                                Console.WriteLine("Você deseja:\n1 - Criar Arquivo\n2 - Renomear Arquivo\n");

                                opcao2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("ERRO: OPÇÃO INVÁLIDA! - Informe um número do Menu!");
                                opcao2 = 0;
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine("ERRO: VALOR NULO! - Informe um número do Menu!");
                                opcao2 = 0;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"ERRO: INDEFINIDO - {ex.Message}");
                                opcao2 = 0;
                            }

                            switch (opcao2) //Verifica se o usuário quer criar uma pasta nova ou renomear uma já existente
                            {
                                case 1:
                                    CriarPasta(caminho);
                                    break;

                                case 2:
                                    RenomearPasta(caminho);
                                    break;

                                default:

                                    break;
                            }
                        }

                        break;

                    case 3:
                        caminho = VerificarArquivo();
                        int opcao3 = 0;

                        if (caminho != null)
                        {
                            try
                            {
                                Console.WriteLine("Você deseja:\n1 - Criar arquivo de texto\n2 - Renomear arquivo de texto\n3 - Excluir arquivo de texto\n");

                                opcao3 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("ERRO: OPÇÃO INVÁLIDA! - Informe um número do Menu!");
                                opcao3 = 0;
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine("ERRO: VALOR NULO! - Informe um número do Menu!");
                                opcao3 = 0;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"ERRO: INDEFINIDO - {ex.Message}");
                                opcao3 = 0;
                            }

                            switch (opcao3) //Verifica se o usuário quer criar uma pasta nova ou renomear uma já existente
                            {
                                case 1:
                                    CriarArquivoTexto(caminho);
                                    break;

                                case 2:
                                    RenomearArquivoTexto(caminho);
                                    break;

                                case 3:
                                    ExcluirArquivoTexto(caminho);
                                    break;

                                default:
                                    break;
                            }
                        }

                        break;

                    case 4:
                        caminho = VerificarArquivo();
                        if (caminho != null)
                        {
                            LerEditarArquivoTexto(caminho);
                        }
                        break;

                    case 5:
                        caminho = VerificarArquivo();
                        if (caminho != null)
                        {
                            ListarArquivos_Pastas(caminho);
                        }
                        break;

                    case 6:
                        caminho = VerificarArquivo();
                        if (caminho != null)
                        {
                            MoverArquivo_Pasta(caminho);
                        }
                        break;

                    case 7:
                        caminho = VerificarArquivo();
                        if (caminho != null)
                        {
                            CopiarArquivo_Pasta(caminho);
                        }
                        break;

                    case 8:
                        caminho = VerificarArquivo();
                        if (caminho != null)
                        {
                            DadosArquivo(caminho);
                        }
                        break;

                    default:
                        break;

                }

                caminho = ""; //Limpa a variável caminho
                continuarMenu = ContinuarAplicacao();

            } while (continuarMenu == true);
        }

        //=========================== Case 1 / Genérico ===========================
        static String VerificarArquivo() //Método para verificar a existência de um arquivo ou pasta
        {
            Console.Clear();
            String caminho = null;

            try
            {
                Console.WriteLine("=== Verificar arquivo ===\nInforme o caminho do arquivo:\n");
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

        //=========================== Case 2 ===========================
        static void RenomearPasta(String caminho)
        {
            String novoCaminho;

            try
            {
                Console.WriteLine("=== Renomear Pasta ===\nInforme o caminho da nova pasta");
                novoCaminho = Console.ReadLine();

                if (Directory.Exists(caminho) == true && !Directory.Exists(novoCaminho))
                {
                    Directory.Move(caminho, novoCaminho);
                    Console.WriteLine("Diretório renomeado com sucesso!");
                }
                else
                {
                    Console.WriteLine("O caminho especificado não existe!");
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ERRO: VALOR NULO - Informe um caminho");
                novoCaminho = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO INDEFINIDO - {ex.Message}");
                novoCaminho = "";
            }
        }

        static void CriarPasta(String caminhoAntigo)
        {
            String nomePasta, caminhoNovo;

            try
            {
                Console.WriteLine("=== Adicionar Pasta ===\nInforme o nome da pasta");
                nomePasta = Console.ReadLine();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ERRO: VALOR NULO - Informe um nome para a pasta");
                nomePasta = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                nomePasta = null;
            }

            caminhoNovo = caminhoAntigo + $"\\{nomePasta}";

            if (Directory.Exists(caminhoNovo) == true)
            {
                Console.WriteLine("Pasta já existe!");
                caminhoNovo = "";
            }
            else
            {
                Directory.CreateDirectory(caminhoNovo);
                Console.WriteLine("Pasta criada com sucesso!");
            }

        }
        //=========================== Case 3 ===========================

        static Boolean CriarArquivoTexto(String caminho)
        {
            try
            {
                if (!Directory.Exists(caminho))
                {
                    Console.WriteLine("Informe um diretório válido!");
                    return false;
                }

                Console.WriteLine("Informe o nome do arquivo (ex: texto.txt):");
                string nomeArquivo = Console.ReadLine();

                string caminhoCompleto = Path.Combine(caminho, nomeArquivo);

                if (File.Exists(caminhoCompleto))
                {
                    Console.WriteLine("O arquivo já existe!");
                    return false;
                }

                Console.WriteLine("Informe o texto que será inserido no arquivo:");
                string textoArquivo = Console.ReadLine();

                File.WriteAllText(caminhoCompleto, textoArquivo ?? "");
                Console.WriteLine("Arquivo criado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
                return false;
            }
        }

        static Boolean RenomearArquivoTexto(String caminho)
        {
            String novoCaminho;

            try
            {
                Console.WriteLine("=== Renomear Arquivo ===\nInforme o nome do novo arquivo");
                novoCaminho = Console.ReadLine();

                if (File.Exists(caminho) == true)
                {
                    File.Move(caminho, novoCaminho);
                    Console.WriteLine("Arquivo renomeado com sucesso!");
                    return true;
                }
                else
                {
                    Console.WriteLine("O caminho especificado não existe!");
                    return false;
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ERRO: VALOR NULO - Informe um caminho");
                novoCaminho = "";
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO INDEFINIDO - {ex.Message}");
                novoCaminho = "";
                return false;
            }
        }

        static Boolean ExcluirArquivoTexto(String caminho)
        {
            if (File.Exists(caminho) == true)
            {
                File.Delete(caminho);
                return true;
            }
            else
            {
                return false;
            }
        }

        //=========================== Case 4 ===========================
        static Boolean LerEditarArquivoTexto(String caminho)
        {
            String novoTexto, antigoTexto = File.ReadAllText(caminho);
            char editar;

            Console.WriteLine(antigoTexto + "\n");

            try
            {
                Console.WriteLine("Deseja editar o texto? S/N");
                editar = char.Parse(Console.ReadLine().ToUpper());

                if (editar == 'S')
                {
                    try
                    {
                        Console.WriteLine("Informe o novo texto");
                        novoTexto = Console.ReadLine();

                        if (novoTexto != null)
                        {
                            File.WriteAllText(caminho, novoTexto);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Nenhum texto foi informado.");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ERRO INDEFINIDO - {ex.Message}");
                        novoTexto = null;
                        return false;
                    }

                }
                else
                {
                    editar = ' ';
                    return false;
                }

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ERRO: VALOR NULO - Informe um texto");
                novoTexto = null;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO INDEFINIDO - {ex.Message}");
                novoTexto = null;
                return false;
            }
        }

        //=========================== Case 5 ===========================

        static void ListarArquivos_Pastas(String caminho)
        {
            Console.WriteLine("=== Arquivos da Pasta ===");

            Console.WriteLine("Pastas:\n");
            foreach (String pasta in Directory.GetDirectories(caminho))
            {
                Console.WriteLine(pasta);
            }

            Console.WriteLine("Arquivos:\n");
            foreach (String arquivo in Directory.GetFiles(caminho))
            {
                Console.WriteLine(arquivo);
            }
        }

        //=========================== Case 6 ===========================
        static void MoverArquivo_Pasta(String caminho)
        {
            try
            {
                Console.WriteLine("Mover para qual caminho novo?");
                string novoCaminho = Console.ReadLine();

                if (string.IsNullOrEmpty(novoCaminho))
                {
                    Console.WriteLine("Caminho inválido!");
                    return;
                }

                if (File.Exists(caminho))
                {
                    File.Move(caminho, novoCaminho);
                    Console.WriteLine("Arquivo movido com sucesso!");
                }
                else if (Directory.Exists(caminho))
                {
                    Directory.Move(caminho, novoCaminho);
                    Console.WriteLine("Pasta movida com sucesso!");
                }
                else
                {
                    Console.WriteLine("O caminho de origem não existe!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }
        }

        //=========================== Case 7 ===========================
        static void CopiarArquivo_Pasta(String caminho)
        {
            try
            {
                Console.WriteLine("Copiar para qual caminho?");
                string novoCaminho = Console.ReadLine();

                if (string.IsNullOrEmpty(novoCaminho))
                {
                    Console.WriteLine("Caminho inválido!");
                    return;
                }

                if (File.Exists(caminho))
                {
                    File.Copy(caminho, novoCaminho, true);
                    Console.WriteLine("Arquivo copiado com sucesso!");
                }
                else if (Directory.Exists(caminho))
                {
                    CopiarDiretorio(caminho, novoCaminho);
                    Console.WriteLine("Diretório copiado com sucesso!");
                }
                else
                {
                    Console.WriteLine("O caminho de origem não existe!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }
        }

        // Método auxiliar para copiar diretórios
        static void CopiarDiretorio(string origem, string destino)
        {
            Directory.CreateDirectory(destino);

            foreach (string arquivo in Directory.GetFiles(origem))
            {
                string nomeArquivo = Path.GetFileName(arquivo);
                string destinoArquivo = Path.Combine(destino, nomeArquivo);
                File.Copy(arquivo, destinoArquivo, true);
            }

            foreach (string pasta in Directory.GetDirectories(origem))
            {
                string nomePasta = Path.GetFileName(pasta);
                string destinoPasta = Path.Combine(destino, nomePasta);
                CopiarDiretorio(pasta, destinoPasta);
            }
        }

        //=========================== Case 8 ===========================
        static void DadosArquivo(String caminho) //Pasta ou arquivo
        {
            if (File.Exists(caminho))
            {
                FileInfo arquivoInfo = new FileInfo(caminho); //Construtor

                Console.WriteLine($"Nome: {arquivoInfo.Name}\nData de criação: {arquivoInfo.CreationTime}\nÚltima modificação: {arquivoInfo.LastWriteTime}");
            }
            else if (Directory.Exists(caminho))
            {
                DirectoryInfo pastaInfo = new DirectoryInfo(caminho); //Construtor

                Console.WriteLine($"Nome: {pastaInfo.Name}\nData de criação: {pastaInfo.CreationTime}\nÚltima modificação: {pastaInfo.LastWriteTime}");
            }
        }

        //=========================== Case genérico final ===========================


        static Boolean ContinuarAplicacao()
        {
            Boolean alterado = false;

            do
            {
                try
                {
                    Console.WriteLine("Continuar o programa? (S/N)");
                    char resposta = char.Parse(Console.ReadLine().ToUpper());

                    if (resposta != 'S' && resposta != 'N')
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        if (resposta == 'S')
                        {
                            Console.Clear();
                            return true;
                        }
                        else if (resposta == 'N')
                        {
                            Console.Clear();
                            return false;
                        }
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ERRO: VALOR NULO - Informe uma letra válida!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERRO: VALOR INVÁLIDO - Informe uma letra válida!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO INESPERADO! {ex.Message}");
                }
            }
            while (alterado == false);

            Console.Clear();
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace exercicio6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double nota1 = 0, nota2 = 0, nota3 = 0;
            String nome = "";
            int idade = 0;
            Boolean novoCadastro = true;
            List<(string Nome, int Idade, double Nota1, double Nota2, double Nota3)> lista = new List<(string, int, double, double, double)>(); 
            //Lista para armazenar a tupla

            do
            {
                try
                {
                    Console.Write("Digite o nome: ");
                    nome = Console.ReadLine();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ERRO: VALOR NULO - Informe um nome!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: INESPERADO - {ex.Message}\n");
                }

                try
                {
                    Console.Write("Digite a idade: ");
                    idade = int.Parse(Console.ReadLine());

                    if(idade < 0 || idade > 100)
                    {
                        throw new Exception();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERRO: VALOR INVÁLIDO - Informe apenas números!\n");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ERRO: VALOR NULO - Informe um número!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: INESPERADO - {ex.Message}\n");
                }

                try
                {
                    Console.WriteLine("Nota 1: ");
                    nota1 = double.Parse(Console.ReadLine());

                    Console.WriteLine("Nota 2: ");
                    nota2 = double.Parse(Console.ReadLine());

                    Console.WriteLine("Nota 3 ");
                    nota3 = double.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("ERRO: VALOR INVÁLIDO - Informe apenas números!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ERRO: VALOR NULO - Informe um número!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO: INESPERADO - {ex.Message}\n");
                }

                //Define a tupla e adiciona à lista
                var boletim = (Nome: nome, Idade:idade, Nota1:nota1, Nota2:nota2, Nota3:nota3);
                lista.Add(boletim);

                Console.Clear();
                Console.WriteLine("=== Lista atual ===\n");
                
                foreach(var aluno in lista)
                {
                    Console.WriteLine($"Nome: {aluno.Nome}");
                    Console.WriteLine($"Idade: {aluno.Idade}");
                    Console.WriteLine($"Notas: {aluno.Nota1}, {aluno.Nota2}, {aluno.Nota3}");
                    Console.WriteLine("------------------------\n");
                }

                    ConfirmarNovoCadastro(ref novoCadastro);
            }
            while (novoCadastro == true);
        }

        public static void ConfirmarNovoCadastro(ref Boolean novoCadastro)
        {
            char confirmacao = 'S';

            do
            {
                try
                {
                    Console.WriteLine("Fazer novo cadastro? (S/N)");
                    confirmacao = char.Parse(Console.ReadLine().ToUpper());

                    if (confirmacao != 'S' && confirmacao != 'N')
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"ERRO: Valor inválido - Informe S - Sim ou N - Não!\n{ex.Message}\n");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"ERRO: Valor nulo - Informe uma letra válida!\n{ex.Message}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERRO INESPERADO - {ex.Message}\n");
                }

                if (confirmacao == 'N')
                {
                    Console.Clear();
                    Console.WriteLine("\nNeste caso, encerrando programa...");
                    novoCadastro = false;
                }

            }
            while (confirmacao != 'S' && confirmacao != 'N');
        }

    }
}

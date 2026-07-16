using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numero = 0, contador = 0;

            try
            {
                Console.WriteLine("=== Calculador de dígitos ===\n\nInforme um número:");
                numero = int.Parse(Console.ReadLine());
                if (numero < 0) //É negativo
                {
                    throw new FormatException("ERRO: NÚMERO NEGATIVO - Informe um número inteiro e positivo");
                }
            }
            catch (FormatException) 
            {
                Console.WriteLine("ERRO: FORMATO INVÁLIDO - Informe um número inteiro e positivo");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ERRO: NÚMERO NULO - Informe um número!\n{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO: {ex.Message}");
            }

            contadorNumero(numero,contador);
            Console.ReadKey();

        }

        static int contadorNumero(int numero, int contador)
        {
            String numString = numero.ToString(); //Converte o número em uma String, permitindo a análise por caractére 
            int tamanhoMaximo = numString.Length; //Tamanho máximo do número

            if (Char.IsNumber(numString[contador]) == true) //Verifica se é um número
            {
                if (contador + 1 < tamanhoMaximo) //Garante que não passe do tamanho da numString, quebrando o índice
                {
                    contadorNumero(numero, contador + 1);
                }
                else if (contador + 1 == tamanhoMaximo)
                {
                    contador += 1;
                    Console.WriteLine(contador);
                    return contador;
                }
            }
            return 0; //Caso dê erro, retorna 0
        }
    }
}

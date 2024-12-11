using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Utils
{
    internal static class Input
    {
        public static int LerInteiro(int minimo = int.MinValue, int maximo = int.MaxValue)
        {
            while (true)
            {
                try
                {
                    string entrada = Console.ReadLine();
                    if (int.TryParse(entrada, out int valor) && valor >= minimo && valor <= maximo)
                    {
                        return valor;
                    }
                    Console.WriteLine($"Entrada invalida. Por favor, digite um numero inteiro entre {minimo} e {maximo}.");
                }
                catch
                {
                    Console.WriteLine("Entrada invalida. Por favor, digite um numero inteiro valido.");
                }
            }
        }

        public static decimal LerDecimal(decimal minimo = decimal.MinValue, decimal maximo = decimal.MaxValue)
        {
            while (true)
            {
                try
                {
                    string entrada = Console.ReadLine();
                    if (decimal.TryParse(entrada, out decimal valor) && valor >= minimo && valor <= maximo)
                    {
                        return valor;
                    }
                    Console.WriteLine($"Entrada invalida. Por favor, digite um numero decimal entre {minimo} e {maximo}.");
                }
                catch
                {
                    Console.WriteLine("Entrada invalida. Por favor, digite um numero decimal valido.");
                }
            }
        }

        public static string LerString(int minLength = 1, int maxLength = int.MaxValue)
        {
            while (true)
            {
                try
                {
                    string entrada = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrEmpty(entrada) &&
                        entrada.Length >= minLength &&
                        entrada.Length <= maxLength)
                    {
                        return entrada;
                    }
                    Console.WriteLine($"Entrada invalida. Digite uma texto com tamanho entre {minLength} e {maxLength} caracteres.");
                }
                catch
                {
                    Console.WriteLine("Entrada invalida. Tente novamente.");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                    string entrada = Console.ReadLine().Trim();
                    
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
                    string entrada = Console.ReadLine().Trim();

                    //substituir o separador decimal
                    entrada = entrada.Replace('.', ',');
                    //retirar os zeros iniciais 
                    entrada = entrada.TrimStart('0');

                    //garantir que a entrada tenha , 
                    if (!entrada.Contains(",")) 
                    {
                        entrada += ",00";
                    }

                    //garantir que a entrada contenha sempre no minimo duas casas decimais
                    if (entrada.Contains(",") && entrada.Length - entrada.IndexOf(",") < 3)
                    {
                        if (entrada.Length - entrada.IndexOf(",") == 1)
                        {
                            entrada += "00";
                        }
                        else
                        {
                            entrada += "0";
                        }
                    }




                    if (decimal.TryParse(entrada, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal valor) && valor >= minimo && valor <= maximo)
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

        public static string LerCPF(int minLength = 11, int maxLength = 11)
        {
            while (true)
            {
                try
                {
                    string entrada = Console.ReadLine().Trim();

                    if (!string.IsNullOrEmpty(entrada) &&
                        entrada.Length >= minLength &&
                        entrada.Length <= maxLength &&
                        Regex.IsMatch(entrada, @"^[0-9]+$"))
                    {
                        return entrada;
                    }
                    Console.WriteLine($"Entrada invalida. O CPF deve conter 11 digitos numericos.");
                }
                catch
                {
                    Console.WriteLine("Entrada invalida. Tente novamente.");
                }
            }
        }

        public static string LerNome(int minLength = 1, int maxLength = 100)
        {
            while (true)
            {
                try
                {
                    string entrada = Console.ReadLine().Trim();

                    if (!string.IsNullOrEmpty(entrada) &&
                        entrada.Length >= minLength &&
                        entrada.Length <= maxLength &&
                        Regex.IsMatch(entrada, @"^[a-zA-Z\s]+$"))
                    {
                        return entrada;
                    }

                    Console.WriteLine($"Entrada invalida. O nome deve conter entre {minLength} e {maxLength} caracteres e apenas letras e espacos.");
                }
                catch
                {
                    Console.WriteLine("Entrada invalida. Tente novamente.");
                }
            }
        }

        public static string LerString(int minLength = 1, int maxLength = int.MaxValue)
        {
            while (true)
            {
                try
                {
                    string entrada = Console.ReadLine().Trim();

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

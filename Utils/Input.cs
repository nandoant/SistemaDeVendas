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
                    Console.WriteLine($"Entrada inválida. Por favor, digite um número inteiro entre {minimo} e {maximo}.");
                }
                catch
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro válido.");
                }
            }
        }

        public static double LerDouble(double minimo = double.MinValue, double maximo = double.MaxValue)
        {
            while (true)
            {
                try
                {
                    bool executando = true;
                    String entrada = null;

                    while (executando){
                    entrada = Console.ReadLine();
                    if(entrada != null)
                        if(entrada.Contains("."))
                            System.Console.WriteLine("Utilize vírgula ao invés de ponto para separar decimais. Tente novamente: ");
                        else if(entrada.Contains(","))
                            if(entrada.Length - entrada.IndexOf(",") > 3)
                                System.Console.WriteLine("Utilize no máximo 2 casas decimais. Tente novamente: ");
                            else
                                executando = false;
                    }

                    if (double.TryParse(entrada, out double valor) && valor >= minimo && valor <= maximo)
                    {
                        return valor;
                    }
                    Console.WriteLine($"Entrada inválida. Por favor, digite um número entre {minimo} e {maximo}.");
                }
                catch
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
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
                    Console.WriteLine($"Entrada inválida. Digite uma texto com tamanho entre {minLength} e {maxLength} caracteres.");
                }
                catch
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }
            }
        }
    }
}

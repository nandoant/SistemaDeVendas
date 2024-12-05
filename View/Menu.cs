using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.View
{
    internal class Menu
    {
        public void Inicializar()
        {
            Boolean executando = true;


            while (executando) {
                menuPrincipal();
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        executando = false;
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Opcao invalida tente novamente");
                        break;
                }
            }

            Console.WriteLine("Adeus!");
        }

        private void menuPrincipal()
        {
            Console.WriteLine("=== Sistema de Vendas ===");
            Console.WriteLine("1. Cliente");
            Console.WriteLine("2. Produtos");
            Console.WriteLine("3. Vendas");
            Console.WriteLine("0. Sair");
            Console.WriteLine("Escolha uma opcao: ");
        }
    }
}

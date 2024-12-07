using SistemaDeVendas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.View
{
    internal class Menu
    {
        private readonly ProdutoView produtoView = new ProdutoView();
        private readonly ClienteView clienteView = new ClienteView();
        private readonly VendaView vendaView = new VendaView();

        public void Inicializar()
        {
            bool executando = true;

            while (executando)
            {
                ExibirMenuPrincipal();
                int opcao = Input.LerInteiro(0,3);

                switch (opcao)
                {
                    case 0:
                        executando = false;
                        break;
                    case 1:
                        clienteView.Menu();
                        break;
                    case 2:
                        produtoView.Menu();
                        break;
                    case 3:
                        vendaView.Menu();
                        break;
                    default:
                        Console.WriteLine("Opcao invalida. Tente novamente.");
                        break;
                }
            }

            Console.WriteLine("Adeus!");
        }

        private void ExibirMenuPrincipal()
        {
            Console.WriteLine("\n=== Sistema de Vendas ===");
            Console.WriteLine("1. Cliente");
            Console.WriteLine("2. Produtos");
            Console.WriteLine("3. Vendas");
            Console.WriteLine("0. Encerrar Programa");
            Console.Write("Escolha uma opção: ");
        }

    }
}


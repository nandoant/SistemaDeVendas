using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.View
{
    internal class Menu
    {
        private ProdutoView produtoView = new ProdutoView();
        private ClienteView clienteView = new ClienteView();
        private VendaView vendaView = new VendaView();  
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
                        clienteView.Menu();
                        break;
                    case 2:
                        produtoView.Menu();
                        break;
                    case 3:
                        vendaView.Menu();
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
            Console.WriteLine("\n=== Sistema de Vendas ===");
            Console.WriteLine("1. Cliente");
            Console.WriteLine("2. Produtos");
            Console.WriteLine("3. Vendas");
            Console.WriteLine("0. Sair");
            Console.WriteLine("Escolha uma opcao: ");
        }
    }
}

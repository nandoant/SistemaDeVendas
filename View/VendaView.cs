using SistemaDeVendas.Model;
using SistemaDeVendas.Service;
using SistemaDeVendas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.View
{
    internal class VendaView
    {
        private VendaService service = new VendaService();  

        public void Menu()
        {
            bool executando = true;

            while (executando) 
            {
                exibirMenu();
                int opcao = Input.LerInteiro(0,4);
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
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Opcao invalida. Tente novamente.");
                        break;
                }
            }
            
        }

        public void exibirMenu()
        {
            Console.WriteLine("\n=== Menu de Vendas ===");
            Console.WriteLine("1. Nova Venda");
            Console.WriteLine("2. Buscar Venda");
            Console.WriteLine("3. Listar Vendas");
            Console.WriteLine("4. Totalizacao");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opcao: ");
        }

        public void buscarVenda()
        {
            Console.WriteLine("Digite o codigo da venda:");
            Console.Write("opcao: ");
            int vendaId = Input.LerInteiro(0);

            Venda venda= service.buscar(vendaId);

            if (venda == null)
            {
                Console.WriteLine("Venda nao encontrada");
                return;
            }

            Console.WriteLine(venda);

        }


    }
}

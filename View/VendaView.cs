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
        private VendaService vendaService = new VendaService();
        private ClienteService clienteService = new ClienteService();
        private ProdutoService produtoService = new ProdutoService();

        public void Menu()
        {
            bool executando = true;
            while (executando) 
            {
                Console.Clear();
                exibirMenu();
                int opcao = Input.LerInteiro(0,4);
                Console.Clear();
                switch (opcao)
                {
                    case 0:
                        executando = false;
                        break;
                    case 1:
                        adicionarVenda();
                        break;
                    case 2:
                        buscarVenda();
                        break;
                    case 3:
                        listarVendas();
                        break;
                    case 4:
                        totalizacao();
                        break;
                    default:
                        Console.WriteLine("Opcao invalida. Tente novamente.");
                        break;
                }
                if (opcao != 0) 
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
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
            Console.WriteLine("\n=== Buscar uma Venda ===");
            Console.WriteLine("Digite o codigo da venda:");
            Console.Write("Escolha um codigo: ");
            int vendaId = Input.LerInteiro(0);

            Venda venda= vendaService.buscar(vendaId);

            if (venda == null)
            {
                Console.WriteLine("Venda nao encontrada");
                return;
            }

            venda.Exibir();

        }

        public void listarVendas()
        {
            Console.WriteLine("\n=== Todas as Vendas ===");
            if(vendaService.listar().Count() == 0)
            {
                Console.WriteLine("Nenhuma venda cadastrada.");
                return;
            }
            foreach (var venda in vendaService.listar())
            {
                Console.WriteLine("ID: "+venda.Id+", Valor Total: "+venda.getValorTotal());
            }
        }

        public void totalizacao()
        {
            double total = 0;
            int count = 0;
            foreach (var venda in vendaService.listar())
            {
                count++;
                total += venda.getValorTotal(); 
            }
            Console.WriteLine("\n=== Totalizacao ===");
            Console.WriteLine("Numero de Vendas: "+count+", Valor Total: "+total);
        }

    public void adicionarVenda()
    {
        Console.WriteLine("\n=== Adicionar Nova Venda ===");
        Console.WriteLine("Digite o id do cliente");
        int idCliente = Input.LerInteiro(0);

        /*if (clienteService.buscar(idCliente) == null)
        {
            Console.WriteLine("Cliente não encontrado.");
            return;
        }*/

        Venda venda = new Venda(idCliente);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\nProdutos Disponíveis:");
            produtoService.Exibirlista();

            Console.WriteLine("\nID do Produto (Digite 0 para finalizar) : ");
            int produtoId = Input.LerInteiro();
            if (produtoId == 0) 
            { 
                break; 
            }
            else
            {
                Produto produto = produtoService.buscarPorId(produtoId);
                if (produto == null)
                {
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    venda.AdicionarProduto(produto);
                    Console.WriteLine("Produto adicionado à venda.");
                }
            }
        }

        if(venda.getProdutos().Count() == 0)
        {
            Console.WriteLine("A venda deve haver pelo menos um produto.");
            return;
        }
        vendaService.adicionar(venda);
        Console.WriteLine("Venda adicionada com sucesso!");
    }


    }
}

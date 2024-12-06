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
                        AdicionarVenda();
                        break;
                    case 2:
                        BuscarVenda();
                        break;
                    case 3:
                        ListarVendas();
                        break;
                    case 4:
                        ExibirTotalizacao();
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

        public void BuscarVenda()
        {
            Console.WriteLine("\n=== Buscar uma Venda ===");
            Console.WriteLine("Digite o codigo da venda:");
            int vendaId = Input.LerInteiro(0);

            Venda venda= vendaService.buscar(vendaId);

            if (venda == null)
            {
                Console.WriteLine("Venda nao encontrada");
                return;
            }

            venda.Exibir();

        }

        public void ListarVendas()
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

        public void ExibirTotalizacao()
        {
            var vendas = vendaService.listar();
            int count = vendas.Count();
            double total = vendas.Sum(venda => venda.getValorTotal());

            Console.WriteLine("\n=== Totalizacao ===");
            Console.WriteLine("Numero de Vendas: "+count+", Valor Total: "+total);
        }

        private void AdicionarVenda()
        {
            Console.WriteLine("\n=== Nova Venda ===");
            Console.Write("Digite o ID do cliente: ");
            int clienteId = Input.LerInteiro(0);

            /*
            Cliente cliente = clienteService.buscar(clienteId);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }
            */
            Venda venda = new Venda(clienteId);
            AdicionarProdutos(venda);

            if (!venda.getProdutos().Any())
            {
                Console.WriteLine("\nVenda cancelada - nenhum produto adicionado.");
                return;
            }

            vendaService.adicionar(venda);
            Console.WriteLine("\nVenda adicionada com sucesso!");
        }

        private void AdicionarProdutos(Venda venda)
        {
            bool adicionandoProdutos = true;
            while (adicionandoProdutos)
            {
                Console.Clear();
                Console.WriteLine("\nProdutos Disponíveis:");
                produtoService.Exibirlista();

                Console.Write("\nDigite o ID do Produto (0 para finalizar): ");
                int produtoId = Input.LerInteiro();

                if (produtoId == 0)
                {
                    adicionandoProdutos = false;
                }
                else
                {
                    Produto produto = produtoService.buscarPorId(produtoId);
                    if (produto == null)
                    {
                        Console.WriteLine("Produto não encontrado. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        venda.AdicionarProduto(produto);
                        Console.WriteLine("Produto adicionado à venda.");
                    }
                }
            }
        }
    }


}


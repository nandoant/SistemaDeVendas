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


        public void AdicionarVenda()
        {
            int clienteId = ObterIdCliente();
            
            var venda = CriarVendaComProdutos(clienteId);
            
            if (venda == null)
            {
                Console.WriteLine("\nVenda cancelada - Nenhum produto adicionado.");
                return;
            }

            vendaService.adicionar(venda);
            Console.WriteLine("\nVenda adicionada com sucesso!");
        }

        private int ObterIdCliente()
        {
            Console.WriteLine("\n=== Nova Venda ===");
            //clienteService.Exibirlista();
            Console.Write("Digite o ID do cliente: ");
            int idCliente = Input.LerInteiro(0);
            /*
            clienteService.buscar(idCliente);
            if (clienteService.buscar(idCliente) == null)
            {
                Console.WriteLine("Cliente nao encontrado. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return 0;
            }
            */
            return idCliente;
        }

        private Venda CriarVendaComProdutos(int clienteId)
        {
            var venda = new Venda(clienteId);

            while (true)
            {
                ExibirProdutosDisponiveis();

                Console.Write("\nDigite o ID do Produto (0 para finalizar): ");
                int produtoId = Input.LerInteiro();

                if (produtoId == 0)
                    break;

                AdicionarProdutoNaVenda(venda, produtoId);
            }

            if(venda.getProdutos().Length == 0) { return null; }
            return venda;
        }

        private void ExibirProdutosDisponiveis()
        {
            Console.Clear();
            Console.WriteLine("\nProdutos Disponiveis:");
            produtoService.Exibirlista();
        }

        private void AdicionarProdutoNaVenda(Venda venda, int produtoId)
        {
            var produto = produtoService.buscarPorId(produtoId);
            
            if (produto == null)
            {
                Console.WriteLine("Produto nao encontrado. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            venda.AdicionarProduto(produto);
            Console.WriteLine("Produto adicionado a venda.");
        }


    }


}


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
        private VendaController vendaController = new VendaController();
        private ClienteController clienteController = new ClienteController();
        private ProdutoController produtoController = new ProdutoController();

        public void Menu()
        {
            bool executando = true;
            while (executando)
            {
                ExibirMenu();
                Console.Write("\nEscolha uma opção: ");
                int opcao = Input.LerInteiro(0);

                switch (opcao)
                {
                    case 0: executando = false; break;
                    case 1: AdicionarVenda(); break;
                    case 2: BuscarVenda(); break;
                    case 3: ListarVendas(); break;
                    case 4: ExibirTotalizacao(); break;
                    default: Console.WriteLine("Opção inválida, tente novamente."); break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
            Console.Clear();
        }

        private void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Menu de Vendas =====");
            Console.WriteLine("1 - Adicionar Venda");
            Console.WriteLine("2 - Buscar Venda");
            Console.WriteLine("3 - Listar Vendas");
            Console.WriteLine("4 - Exibir Totalização das Vendas");
            Console.WriteLine("0 - Voltar");
        }

        public void AdicionarVenda()
        {
            Console.Clear();
            var clienteID = ObterClienteParaVenda();
            if (clienteID == -1)
                return;

            var venda = IniciarNovaVenda(clienteID);
            if (venda == null)
                return;

            AdicionarProdutosNaVenda(venda);

            if (venda.getProdutos().Count == 0)
            {
                Console.WriteLine("\nVenda cancelada - Nenhum produto adicionado.");
                return;
            }

            FinalizarVenda(venda);
        }

        private int ObterClienteParaVenda()
        {
            int clienteId = ObterIdCliente();
            if (clienteId == -1)
            {
                Console.WriteLine("\nVenda cancelada - Não possui cliente");
                return -1;
            }
            return clienteId;
        }

        private Venda IniciarNovaVenda(int clienteId)
        {
            try
            {
                return vendaController.CriarVenda(clienteId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar venda: {ex.Message}");
                return null;
            }
        }

        private void AdicionarProdutosNaVenda(Venda venda)
        {
            var mensagem = new StringBuilder();
            while (true)
            {
                Console.Clear();
                var produtos = ExibirProdutosDisponiveis();
                ExibirMensagemSeExistir(mensagem);

                Console.Write("\nDigite o ID do Produto (0 para finalizar): ");
                int produtoId = Input.LerInteiro(0, produtos.Length);
                if (produtoId == 0)
                    break;

                TentarAdicionarProduto(venda, produtoId, mensagem);
            }
        }

        private void ExibirMensagemSeExistir(StringBuilder mensagem)
        {
            if (mensagem.Length > 0)
            {
                Console.WriteLine(mensagem.ToString());
                mensagem.Clear();
            }
        }

        private void TentarAdicionarProduto(Venda venda, int produtoId, StringBuilder mensagem)
        {
            try
            {
                vendaController.AdicionarProduto(venda, produtoId);
                mensagem.Append("\nProduto adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                mensagem.Append($"\n{ex.Message}");
            }
        }

        private void FinalizarVenda(Venda venda)
        {
            try
            {
                vendaController.adicionar(venda);
                Console.WriteLine("\nVenda adicionada com sucesso!");
                ExibirVenda(venda);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar venda: {ex.Message}");
            }
        }

        private int ObterIdCliente()
        {
            Console.Clear();
            Console.WriteLine("\nClientes disponíveis:");
            var clientes = clienteController.listar();
            if (clientes == null)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return -1;
            }
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Codigo}, Nome: {cliente.Nome}");
            }

            Console.Write("\nDigite o ID do Cliente: ");
            int idCliente = Input.LerInteiro(1,clientes.Length);

            var clienteEncontrado = clienteController.buscar(idCliente);
            if (clienteEncontrado == null)
            {
                return -1;
            }

            return idCliente;
        }

        private Produto[] ExibirProdutosDisponiveis()
        {
            Console.Clear();
            Console.WriteLine("\nProdutos disponíveis:");
            var produtos = produtoController.listar();
            if (produtos == null)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return null;
            }
            foreach (var produto in produtos)
            {
                produto.Exibir();
                System.Console.WriteLine("-------------------------------------");
            }
            return produtos;
        }

        public void BuscarVenda()
        {
            Console.Clear();
            Console.Write("\nDigite o ID da Venda que deseja buscar: ");
            int idVenda = Input.LerInteiro(0);

            try
            {
                var venda = vendaController.buscar(idVenda);
                ExibirVenda(venda);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListarVendas()
        {
            Console.Clear();
            try
            {
                var vendas = vendaController.listar();
                if (vendas.Length == 0)
                {
                    Console.WriteLine("\nNenhuma venda cadastrada.");
                    return;
                }

                foreach (var venda in vendas)
                {
                    ExibirVenda(venda);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ExibirTotalizacao()
        {
            Console.Clear();
            try
            {
                var vendas = vendaController.listar();
                if (vendas.Length == 0)
                {
                    Console.WriteLine("\nNenhuma venda cadastrada.");
                    return;
                }

                double total = 0;
                int count = 0;
                foreach (var venda in vendas)
                {
                    count++;
                    total += venda.getValorTotal();
                }

                Console.WriteLine($"\nTotalização das Vendas: R$ {total.ToString("0.00")} ({count} vendas)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ExibirVenda(Venda venda)
        {
            Console.Clear();
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("ID da Venda: " + venda.Id);
            Console.WriteLine("ID do Cliente: " + venda.IdCliente);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Produtos:");
            foreach (var produto in venda.getProdutos().Keys)
            {
                produto.Exibir();
                Console.WriteLine("Quantidade: " + venda.getProdutos()[produto]);
                double subtotal = produto.Preco * venda.getProdutos()[produto];
                Console.WriteLine("Subtotal: " + subtotal.ToString("0.00"));
                Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine("Valor Total: " + venda.getValorTotal().ToString("0.00"));
            Console.WriteLine("-------------------------------------");
        }
    }
}
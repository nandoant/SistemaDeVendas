using SistemaDeVendas.Model;
using SistemaDeVendas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Service
{
    internal class VendaController
    {
        private VendaRepository vendaRepository;
        private ClienteRepository clienteRepository;
        private ProdutoRepository produtoRepository;

        public VendaController()
        {
            vendaRepository = VendaRepository.getInstance();
            produtoRepository = ProdutoRepository.getInstance();
            clienteRepository = ClienteRepository.getInstance();
        }

        public Venda CriarVenda(int clienteId)
        {
            if (clienteId <= 0)
            {
                throw new Exception("ID de cliente inválido.");
            }

            var cliente = clienteRepository.buscar(clienteId);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado.");
            }

            return new Venda(clienteId);
        }

        public void AdicionarProduto(Venda venda, int produtoId)
        {
            if (venda == null)
            {
                throw new Exception("Venda não pode ser nula.");
            }

            var produto = produtoRepository.buscarPorID(produtoId);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            venda.AdicionarProduto(produto);
        }

        public void adicionar(Venda venda)
        {
            if (venda == null) { throw new Exception("Venda inválida."); }

            // Validação do cliente
            var cliente = clienteRepository.buscar(venda.IdCliente);
            if (cliente == null) { throw new Exception("Venda possui um cliente que não existe."); }

            // Validação dos produtos
            if (venda.getProdutos().Count == 0) { throw new Exception("A venda deve conter pelo menos um produto."); }

            foreach (Produto produto in venda.getProdutos().Keys)
            {
                if (produto == null)
                    { throw new Exception("Venda possui um produto inválido."); }
                if (produtoRepository.buscarPorID(produto.Codigo) == null)
                    { throw new Exception("Venda possui um produto que não existe."); }
            }

            try { vendaRepository.adicionar(venda); }
            catch (Exception) { throw new Exception("Erro ao cadastrar a venda. Verifique os dados e tente novamente."); }
        }

        public Venda buscar(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID inválido.");
            }

            var venda = vendaRepository.buscar(id);
            if (venda == null)
            {
                throw new Exception("Venda não encontrada.");
            }

            return venda;
        }

        public Venda[] listar()
        {
            try
            {
                return vendaRepository.listar();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar as vendas.");
            }
        }
    }
}
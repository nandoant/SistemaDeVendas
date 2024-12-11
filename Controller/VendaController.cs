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
                throw new Exception("ID de cliente invalido.");
            }

            var cliente = clienteRepository.buscar(clienteId);
            if (cliente == null)
            {
                throw new Exception("Cliente nao encontrado.");
            }

            return new Venda(clienteId);
        }

        public void AdicionarProduto(Venda venda, int produtoId)
        {
            if (venda == null)
            {
                throw new Exception("Venda nao pode ser nula.");
            }

            var produto = produtoRepository.buscarPorID(produtoId);
            if (produto == null)
            {
                throw new Exception("Produto nao encontrado.");
            }

            venda.AdicionarProduto(produto);
        }

        public void adicionar(Venda venda)
        {
            if (venda == null) { throw new Exception("Venda invalida."); }

            // Validacao do cliente
            var cliente = clienteRepository.buscar(venda.IdCliente);
            if (cliente == null) { throw new Exception("Venda possui um cliente que nao existe."); }

            // Validacao dos produtos
            if (venda.getProdutos().Count == 0) { throw new Exception("A venda deve conter pelo menos um produto."); }

            foreach (Produto produto in venda.getProdutos().Keys)
            {
                if (produto == null)
                    { throw new Exception("Venda possui um produto invalido."); }
                if (produtoRepository.buscarPorID(produto.Codigo) == null)
                    { throw new Exception("Venda possui um produto que nao existe."); }
            }

            try { vendaRepository.adicionar(venda); }
            catch (Exception) { throw new Exception("Erro ao cadastrar a venda. Verifique os dados e tente novamente."); }
        }

        public Venda buscar(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID invalido.");
            }

            var venda = vendaRepository.buscar(id);
            if (venda == null)
            {
                throw new Exception("Venda nao encontrada.");
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
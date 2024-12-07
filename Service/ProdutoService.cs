using SistemaDeVendas.Repository;
using SistemaDeVendas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace SistemaDeVendas.Service
{
    internal class ProdutoService
    {
        private ProdutoRepository produtoRepo = ProdutoRepository.getInstance();
        private VendaRepository vendaRepo = VendaRepository.getInstance();

        public bool adicionar(string marca, string modelo, string descricao, double preco)
        {
            if (string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(modelo) || 
                string.IsNullOrWhiteSpace(descricao) || preco <= 0)
            {
                throw new Exception("Todos os campos são obrigatórios e o preço deve ser maior que zero.");
            }

            try
            {
                var produto = new Produto(marca, modelo, descricao, preco);
                produtoRepo.adicionar(produto);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar o produto. Verifique os dados e tente novamente.");
            }
        }

        public Produto[] listar()
        {
            var produtos = produtoRepo.listar();
            if (produtos == null || produtos.Count == 0)
            {
                return null;
            }

            return produtos.Values.ToArray();
        }
        public void Exibirlista()
        {
            var produtos = produtoRepo.listar();
            
            if (produtos == null || produtos.Count == 0)
            {
                Console.WriteLine("Não há produtos cadastrados.");
                return;
            }

            Console.WriteLine("=== LISTA DE PRODUTOS ===");
            foreach (var produto in produtos.Values)
            {
                produto.Exibir();
                Console.WriteLine("\n\t--------------------------");
            }
        }

        public Produto buscarPorId(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID inválido.");
            }

            var produto = produtoRepo.buscarPorID(id);
            
            if (produto == null)
            {
                Console.WriteLine($"Produto com ID {id} não encontrado.");
                return null;
            }

            Console.WriteLine("Produto encontrado:");
            produto.Exibir();
            return produto;
        }

    public Produto buscarPorId(int id, bool apenasConsulta)
    {
        if (id <= 0)
        {
            throw new Exception("ID inválido.");
        }

        var produto = produtoRepo.buscarPorID(id);

        if (produto == null)
        {
            return null;
        }

        return produto;
    }

        public bool remover(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID inválido.");
            }

            var produto = produtoRepo.buscarPorID(id);
            
            if (produto == null)
            {
                Console.WriteLine($"Produto com ID {id} não encontrado.");
                return false;
            }

            if (vendaRepo.contemProduto(id))
            {
                var vendas = vendaRepo.listar();
                foreach (var venda in vendas)
                {
                    if (produto.Codigo == venda.Id)
                    {
                        throw new Exception(
                            $"Não é possível excluir este produto, pois está vinculado à venda {venda.Id}");
                    }
                }
            }

            if (produtoRepo.excluir(id) != null)
            {
                Console.WriteLine("Produto excluído com sucesso!");
                return true;
            }

            return false;
        }
    }
}

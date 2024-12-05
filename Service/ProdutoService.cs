using SistemaDeVendas.Repository;
using SistemaDeVendas.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaDeVendas.Service
{
    internal class ProdutoService
    {
        private ProdutoRepository produtoRepo = ProdutoRepository.getInstance();

        public void adicionar(String marca, String modelo, String descricao, Double preco)
        {
            Produto produto = new Produto(marca, modelo, descricao, preco)
            try
            {
                produtoRepo.adicionar(produto);
            }catch (Exception ex) {
                throw new Exception("Não foi possível cadastrar o produto!");
            }
        }

        public void listar(Dictionary<int, Produto> lista) { 
            
        }

        public Produto remover(int id)
        {

        }

        public Produto buscarPorId(int id) {

        }
}

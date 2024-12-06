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
            lista = produtoRepo.listar();
            try
            {
                if (lista == null)
                {
                    Console.WriteLine("A lista está vazia!");
                }
                else
                {
                    foreach (Produto item in lista)
                    {
                        Console.WriteLine("Lista de produtos: ");
                        item.Exibir();
                        Console.WriteLine("\n\t--------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível listar os produtos.");
            }

        }

        public Produto buscarPorId(int id)
        {
            Produto produtoEncontrado = produtoRepo.buscarPorID(id);
            try
            {
                if (produtoEncontrado == null)
                {
                    Console.WriteLine("Produto com id: {0} não encontrado!", id);
                }
                else
                {
                    Console.WriteLine("Produto encontrado com sucesso!");
                    produtoEncontrado.Exibir();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar o produto pelo id!");
            }
        }


        public Produto remover(int id)
        {
            Produto produtoEncontrado = produtoRepo.buscarPorID(id);
            try
            {
                if (produtoEncontrado == null)
                {
                    Console.WriteLine("Produto com id: {0} não encontrado!", id);
                } else if (produtoEncontrado)
                {
                    Venda[] lista = vendaRepo.listar();
                    foreach (Venda venda in lista)
                    {
                        if (produtoEncontrado.Codigo == venda.Id)
                        {
                            Console.WriteLine("Não é possível excluir esse produto, o mesmo está sendo usado na venda {0}", venda.Id);
                        }
                    }

                }
                else
                {
                    Produto produtoExcluido = produtoRepo.excluir(produtoEncontrado);
                    Console.WriteLine("O produto = \n\t {0} \n Foi excluído com sucesso! ", produtoExcluido);
                }

             } catch (Exception ex){
                
                throw new Exception("Não foi possível buscar o produto pelo id!");
            }
        }
      

        
}

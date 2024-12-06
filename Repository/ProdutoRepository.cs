using SistemaDeVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Repository
{
    internal class ProdutoRepository
    {
        private static ProdutoRepository instance;
        private static Dictionary<int, Produto> produtoBD;
        private static int contador = 1;


        public ProdutoRepository()
        {
            produtoBD = new Dictionary<int, Produto>();
        }

        public static ProdutoRepository getInstance()
        {
            if (instance == null)
            {
                instance = new ProdutoRepository();
            }
            return instance;
        }

        public void adicionar(Produto produto)
        {
            produto.Codigo = contador;  
            produtoBD.Add(contador++, produto);
        }

        public Dictionary<int, Produto> listar()
        {
            return produtoBD;
        }

        public Produto buscarPorID(int id)
        {
            if (produtoBD.TryGetValue(id, out var produto))
            {
                return produto;
            }
            else
            {
                return null;
            }
        }



        public Produto excluir(int id)

        {
            if (produtoBD.TryGetValue(id, out var produto))
            {
                produtoBD.Remove(id);

                return produto;
            }
            else
            {
                return null;

            }

        }

    }
}

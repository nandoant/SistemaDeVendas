using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Model
{
    internal class Venda
    {
        private int id;
        private int idCliente;
        private Dictionary<int, Produto> carrinho;

        public Venda(int idCliente) 
        {
            this.idCliente = idCliente;
            this.carrinho = new Dictionary<int, Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produto != null && !carrinho.ContainsKey(produto.Codigo))
            {
                carrinho.Add(produto.Codigo, produto);
            }
        }

        public double getValorTotal()
        {
            double total = 0;
            foreach (var item in carrinho.Values)
            {
                total += item.Preco;
            }
            return total;
        }

        public int Id
        {
            get { return id; }
            set 
            {
                if (value < 0) return;
                id = value; 
            }
        }

        public int IdCliente
        {
            get { return idCliente; }
            set
            {
                if (value < 0) return;
                idCliente = value;
            }
        }

        public Produto[] getProdutos()
        {
            return carrinho.Values.ToArray();   
        }

        public Produto getProduto(int produtoId)
        {
            if (carrinho.TryGetValue(id, out var produto))
            {
                return produto;
            }
            else
            {
                return null;

            }
        }

        public void adicionarProduto(Produto produto)
        {
            carrinho.Add(produto.Codigo,produto);
        }

        public void Exibir()
        {
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("ID da Venda: " + this.Id);
            Console.WriteLine("ID do Cliente: " + this.IdCliente);
            Console.WriteLine("Produtos:");
            foreach(var produto in carrinho.Values)
            {
                produto.Exibir();
                Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine("Valor Total: " + getValorTotal());
            Console.WriteLine("-------------------------------------");
        }
    }
}
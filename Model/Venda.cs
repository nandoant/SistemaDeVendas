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
        private Dictionary<Produto, int> carrinho;

        public Venda(int idCliente) 
        {
            this.idCliente = idCliente;
            this.carrinho = new Dictionary<Produto, int>();
        }

        public void AdicionarProduto(Produto produto)
        {
            if (carrinho.ContainsKey(produto))
            {
                carrinho[produto]++;
            }
            else
            {
                carrinho.Add(produto, 1);
            }

        }

        public decimal getValorTotal()
        {
            decimal total = 0;
            foreach (var item in carrinho.Keys)
            {
                total += item.Preco * carrinho[item];
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

        public Dictionary<Produto, int> getProdutos()
        {
            return carrinho;   
        }

        public Produto getProduto(int produtoId)
        {
            foreach (var produto in carrinho.Keys)
            {
                if (produto.Codigo == produtoId)
                {
                    return produto;
                }
            }
            return null;
        }

        public void Exibir()
        {
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("ID da Venda: " + this.Id);
            Console.WriteLine("ID do Cliente: " + this.IdCliente);
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Produtos:");
            foreach(var produto in carrinho.Keys)
            {
                produto.Exibir();
                Console.WriteLine("Quantidade: " + carrinho[produto]);
                decimal subtotal = produto.Preco * carrinho[produto];
                Console.WriteLine("Subtotal: " + subtotal.ToString("0.00"));
                Console.WriteLine("-------------------------------------");
            }
            //exibir valor total considerando apenas 2 casas decimais, ex: 3000.00
            Console.WriteLine("Valor Total: " + getValorTotal().ToString("0.00"));
            Console.WriteLine("-------------------------------------");
        }
    }
}
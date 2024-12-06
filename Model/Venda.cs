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
        private List<Produto> carrinho;

        public Venda(int idCliente) 
        {
            this.idCliente = idCliente;
            this.carrinho = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            carrinho.Add(produto);
        }

        public double getValorTotal()
        {
            double total = 0;
            foreach (var item in carrinho)
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
            return carrinho.ToArray();   
        }

        public Produto getProduto(int produtoId)
        {
            foreach (Produto produto in carrinho)
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
            Console.WriteLine("Produtos:");
            foreach(var produto in carrinho)
            {
                produto.Exibir();
                Console.WriteLine("-------------------------------------");
            }
            Console.WriteLine("Valor Total: " + getValorTotal());
            Console.WriteLine("-------------------------------------");
        }
    }
}
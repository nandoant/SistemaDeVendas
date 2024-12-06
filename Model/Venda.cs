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
        int idCliente;
        Dictionary<int, Produto> carrinho;

        public Venda(int id, int idCliente) 
        {
            this.id = id;
            this.idCliente = idCliente;
            this.carrinho = new Dictionary<int, Produto>();
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
            get { return id; }
            set
            {
                if (value < 0) return;
                id = value;
            }
        }

        public Produto[] getProdutos()
        {
            return carrinho.Values.ToArray();   
        }

        public Produto GetProduto(int produtoId)
        {
            if (carrinho.ContainsKey(produtoId))
                return carrinho[produtoId];
            else
                return null;
        }

        public void Exibir()
        {
            Console.WriteLine("ID: " + this.Id);
            Console.WriteLine("ClienteID: " + this.IdCliente);
            Console.WriteLine("Produtos:");
            foreach(var produto in carrinho.Values)
            {
                produto.Exibir();
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("Valor Total: " + getValorTotal());
            Console.WriteLine("--------------------");
        }
    }
}

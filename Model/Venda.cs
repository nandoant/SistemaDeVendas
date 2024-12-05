﻿using System;
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


    }
}

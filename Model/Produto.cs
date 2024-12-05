using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Model
{
    internal class Produto
    {
        private int codigo;
        private String marca;
        private String modelo;
        private String descricao;
        private Double Preco;

        public Produto(String marca, String modelo, String descricao, Double preco) {
            this.codigo = codigo
            this.marca = Marca;
            this.modelo = Modelo;
            this.mescricao = Descricao;
            this.preco = Preco;

        }

        public int Codigo{
            get { return this.codigo; } 
            set { codigo = value; }
        }

        public String Marca
        {
            get { return this.marca; }
            set
            {
                if (value != null) return;
                marca = value;
            }
        }
              
        public String Modelo
        {
            get { return this.modelo; }
            set
            {
                if (value != null) return;
                modelo = value;
            }
        }

       public String Descricao
        {
            get { return this.descricao; }
            set
            {
                if (value != null) return;
                descricao = value;
            }
        }

        public Double Preco
        {
            get { return this.preco; }
            set
            {
                if (value <= 0) return;
                preco = value;
            }
        }



        public void Exibir() {
            Console.WriteLine("Código:    {0}", Codigo);
            Console.WriteLine("Marca :    {0}", Marca);
            Console.WriteLine("Modelo:    {0}", Modelo);
            Console.WriteLine("Descrição: {0}", Descricao);
            Console.WriteLine("Preço:     {0:C}", Preco);
            Console.WriteLine("");
        }



    }
}

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
        private Double preco;

        public Produto(String marca, String modelo, String descricao, Double preco) {
            this.codigo = codigo;
            this.marca = marca;
            this.modelo = modelo;
            this.descricao = descricao;
            this.preco = preco;

        }

        public int Codigo{
            get { return this.codigo; } 
            set { codigo = value; }
        }

        public String Marca
        {
            get { return this.marca; }
            set {  marca = value; }
        }
              
        public String Modelo
        {
            get { return this.modelo; }
            set {  modelo = value; }
           
        }

       public String Descricao
        {
            get { return this.descricao; }
            set { descricao = value;}
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
            Console.WriteLine("\tCódigo:    {0}", Codigo);
            Console.WriteLine("\tMarca :    {0}", Marca);
            Console.WriteLine("\tModelo:    {0}", Modelo);
            Console.WriteLine("\tDescrição: {0}", Descricao);
            Console.WriteLine("\tPreço:     {0:C}", Preco);
        }



    }
}

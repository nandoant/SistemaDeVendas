using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Model
{
    internal class Produto
    {
        private static int Contador = 1;
        public int Codigo { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Descricao { get; set; }
        public Double Preco { get; set; }

        public Produto(String Marca, String Modelo, String Descricao, Double Preco) {
            this.Codigo = Contador++;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Descricao = Descricao;
            this.Preco = Preco;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Model
{
    internal class Cliente
    {
        private int codigo;
        private string nome;
        private int idade;
        private string cpf;

        public Cliente(string nome, int idade, string cpf)
        {
            this.nome = nome;
            this.idade = idade;
            this.cpf = cpf;
        }

        public int Codigo
        {
            get 
            { 
                return codigo; 
            }
            set
            {
                if (value < 0) return;
                else this.codigo = value;   
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                this.nome = value;
            }
        }

        public int Idade
        {
            get
            {
                return idade;
            }
            set
            {
                if (value <= 0) return;
                else this.idade = value;
            }
        }

        public String Cpf
        {
            get
            {
                return cpf;
            }
            set
            {
                this.cpf = value;
            }
        }
    }
}

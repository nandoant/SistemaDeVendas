﻿using System;
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
                codigo = value;   
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
                nome = value;
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
                idade = value;
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
                cpf = value;
            }
        }

        public void Exibir()
        {
            Console.WriteLine($"\tID: {this.codigo}");
            Console.WriteLine($"\tNome: {this.nome}");
            Console.WriteLine($"\tIdade: {this.idade}");
            Console.WriteLine($"\tCPF: {this.cpf}");
        }
    }
}

﻿using SistemaDeVendas.Model;
using SistemaDeVendas.Service;
using SistemaDeVendas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.View
{
    internal class VendaView
    {
        private VendaService service = new VendaService();  
        private ProdutoService produtoService = new ProdutoService();

        public void Menu()
        {
            bool executando = true;

            while (executando) 
            {
                exibirMenu();
                int opcao = Input.LerInteiro(0,4);
                switch (opcao)
                {
                    case 0:
                        executando = false;
                        break;
                    case 1:
                        adicionarVenda();
                        break;
                    case 2:
                        buscarVenda();
                        
                        break;
                    case 3:
                        listarVendas();
                        break;
                    case 4:

                        break;
                    default:
                        Console.WriteLine("Opcao invalida. Tente novamente.");
                        break;
                }
            }
            
        }

        public void exibirMenu()
        {
            Console.WriteLine("\n=== Menu de Vendas ===");
            Console.WriteLine("1. Nova Venda");
            Console.WriteLine("2. Buscar Venda");
            Console.WriteLine("3. Listar Vendas");
            Console.WriteLine("4. Totalizacao");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opcao: ");
        }

        public void buscarVenda()
        {
            Console.WriteLine("\n=== Buscar uma Venda ===");
            Console.WriteLine("Digite o codigo da venda:");
            Console.Write("opcao: ");
            int vendaId = Input.LerInteiro(0);

            Venda venda= service.buscar(vendaId);

            if (venda == null)
            {
                Console.WriteLine("Venda nao encontrada");
                return;
            }

            Console.WriteLine(venda);

        }

        public void listarVendas()
        {
            Console.WriteLine("\n=== Todas as Vendas ===");
            foreach (var venda in service.listar())
            {
                Console.WriteLine("ID: "+venda.Id+", Valor Total: "+venda.getValorTotal());
            }
        }

        public void totalizacao()
        {
            double total = 0;
            int count = 0;
            foreach (var venda in service.listar())
            {
                count++;
                total += venda.getValorTotal(); 
            }
            Console.WriteLine("\n=== Totalizacao ===");
            Console.WriteLine("Numero de Vendas: "+count+", Valor Total: "+total);
        }

        public void adicionarVenda()
        {
            Console.WriteLine("\n=== Adicionar Nova Venda ===");
            Console.WriteLine("Digite o id do cliente");
            int idCliente = Input.LerInteiro(0);

            Venda venda = new Venda(idCliente);
            while(true)
            {
                Console.WriteLine("\nProdutos Disponiveis");
                produtoService.listar();

                Console.WriteLine("\nID do Produto (Digite 0 para finalizar) : ");
                int produtoId = Input.LerInteiro();
                if (idCliente == 0) { return; }
                else
                {
                    venda.adicionarProduto(produtoService.buscarPorId(produtoId);
                }
            }

        }


    }
}

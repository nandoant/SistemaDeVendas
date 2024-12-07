﻿using SistemaDeVendas.Service;
using SistemaDeVendas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.View
{
    internal class ClienteView
    {
        private ClienteController clienteService;

        public ClienteView()
        {
            clienteService = new ClienteController();
        }

        public void Menu()
        {
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("=== MENU DE CLIENTES ===");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Listar Clientes");
                Console.WriteLine("3 - Buscar Cliente");
                Console.WriteLine("4 - Excluir Cliente");
                Console.WriteLine("0 - Voltar");
                Console.Write("\nEscolha uma opção: ");

                opcao = Input.LerInteiro(0, 4);
                Console.Clear();
                switch (opcao)
                {
                    case 1: CadastrarCliente(); break;
                    case 2: ListarClientes(); break;
                    case 3: BuscarCliente(); break;
                    case 4: ExcluirCliente(); break;
                    case 0: break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            } while (opcao != 0);
        }

        private void CadastrarCliente()
        {
            Console.WriteLine("=== CADASTRO DE CLIENTE ===\n");

            Console.WriteLine("Nome: ");
            string nome = Input.LerString();

            Console.WriteLine("Idade: ");
            int idade = Input.LerInteiro(5,200);

            Console.WriteLine("Cpf: ");
            string cpf = Input.LerString(1,15);

            try
            {
                clienteService.adicionar(nome, idade, cpf);
                Console.WriteLine("\nCliente adicionado com sucesso!");
            }
            catch (Exception ex) 
            {
                Console.Write($"\nErro: {ex.Message}");
            }
        }

        private void ListarClientes()
        {
            try
            {
                if(clienteService.listar() == null)
                {
                    Console.WriteLine("Nenhum cliente cadastrado.");
                    return;
                }
                clienteService.exibirLista();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        private void BuscarCliente()
        {
            Console.WriteLine("=== BUSCAR CLIENTE ===");
            Console.WriteLine("Digite o código do cliente: ");
            int codigo = Input.LerInteiro(0);

            try
            {
                clienteService.buscar(codigo);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        private void ExcluirCliente()
        {
            Console.WriteLine("=== EXCLUIR CLIENTE ===");
            Console.WriteLine("Digite o código do cliente: ");
            int codigo = Input.LerInteiro(0);

            try
            {
                clienteService.remover(codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}

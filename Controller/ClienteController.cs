using SistemaDeVendas.Model;
using SistemaDeVendas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Service
{
    internal class ClienteController
    {
        private ClienteRepository clienteRepo = ClienteRepository.getInstance();
        private VendaRepository vendaRepo = VendaRepository.getInstance();

        public bool adicionar(string nome, int idade, string cpf)
        {
            if(string.IsNullOrWhiteSpace(nome) || idade < 0 || string.IsNullOrWhiteSpace(cpf))
            {
                throw new Exception("Todos os campos sao obrigatorios e a idade deve ser maior que zero.");
            }

            Dictionary<int, Cliente> clientes = clienteRepo.listar();
            foreach(var cliente in clientes)
            {
                if (cliente.Value.Cpf == cpf)
                    throw new Exception("Ja existe um cliente cadastrado com o Cpf informado.");
            }

            try
            {
                var cliente = new Cliente(nome, idade, cpf);
                clienteRepo.adicionar(cliente);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao cadastrar o cliente. Verifique os dados e tente novamente.");
            }
        }

        public Cliente[] listar()
        {
            var clientes = clienteRepo.listar();
            if(clientes == null || clientes.Count == 0)
            {
                return null;
            }

            return clientes.Values.ToArray();
        }

        public void exibirLista()
        {
            var clientes = clienteRepo.listar();

            if(clientes == null || clientes.Count == 0)
            {
                Console.WriteLine("Nao ha clientes cadastrados.");
                return;
            }

            Console.WriteLine("=== LISTA DE CLIENTES ===");
            Console.WriteLine("Clientes:");
            foreach(var cliente in clientes.Values)
            {
                cliente.Exibir();
                Console.WriteLine("-------------------------------------");
            }
        }

        public Cliente buscar(int codigo)
        {
            if(codigo < 0)
            {
                throw new Exception("Codigo do cliente invalido.");
            }

            var cliente = clienteRepo.buscar(codigo);

            if(cliente == null)
            {
                Console.WriteLine($"Cliente com Codigo {codigo} nao encontrado.");
                return null;
            }

            Console.WriteLine("Cliente encontrado");
            cliente.Exibir();
            return cliente;
        }

        public bool remover(int codigo)
        {
            if(codigo <= 0)
            {
                throw new Exception("Codigo do cliente invalido.");
            }

            var cliente = clienteRepo.buscar(codigo);

            if(cliente == null)
            {
                Console.WriteLine($"Cliente com Codigo {codigo} nao encontrado.");
                return false;
            }

            var vendas = vendaRepo.listar();
            foreach (var venda in vendas)
            {
                if (cliente.Codigo == venda.IdCliente)
                {
                    throw new Exception($"Nao e possivel excluir este cliente, pois esta vinculado a uma venda");
                }
            }

            if(clienteRepo.excluir(codigo) != null)
            {
                Console.WriteLine("Cliente excluido com sucesso!");
                return true;
            }

            return false;
        }
    }
}

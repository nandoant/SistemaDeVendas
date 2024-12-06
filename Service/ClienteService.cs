using SistemaDeVendas.Model;
using SistemaDeVendas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Service
{
    internal class ClienteService
    {
        private ClienteRepository clienteRepo = ClienteRepository.getInstance();
        private VendaRepository vendaRepo = VendaRepository.getInstance();

        public bool adicionar(string nome, int idade, string cpf)
        {
            if(string.IsNullOrWhiteSpace(nome) || idade <= 0 || string.IsNullOrWhiteSpace(cpf))
            {
                throw new Exception("Todos os campos são obrigatórios e a idade deve ser maior que zero.");
            }

            Dictionary<int, Cliente> clientes = clienteRepo.listar();
            foreach(var cliente in clientes)
            {
                if (cliente.Value.Cpf == cpf)
                    throw new Exception("Já existe um cliente cadastrado com o Cpf informado.");
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
                Console.WriteLine("Nao há clientes cadastrados.");
                return;
            }

            Console.WriteLine("=== LISTA DE CLIENTES ===");
            foreach(var cliente in clientes.Values)
            {
                cliente.Exibir();
                Console.WriteLine("\n\t--------------------------");
            }
        }

        public Cliente buscar(int codigo)
        {
            if(codigo <= 0)
            {
                throw new Exception("Código do cliente inválido.");
            }

            var cliente = clienteRepo.buscar(codigo);

            if(cliente == null)
            {
                Console.WriteLine($"Cliente com Código {codigo} não encontrado.");
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
                throw new Exception("Código do cliente inválido.");
            }

            var cliente = clienteRepo.buscar(codigo);

            if(cliente == null)
            {
                Console.WriteLine($"Cliente com Código {codigo} não encontrado.");
                return false;
            }

            var vendas = vendaRepo.listar();
            foreach (var venda in vendas)
            {
                if (cliente.Codigo == venda.IdCliente)
                {
                    throw new Exception($"Não é possível excluir este cliente, pois está vinculado à venda {venda.Id}");
                }
            }

            if(clienteRepo.excluir(codigo) != null)
            {
                Console.WriteLine("Cliente excluído com sucesso!");
                return true;
            }

            return false;
        }
    }
}

using SistemaDeVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Repository
{
    internal class ClienteRepository
    {
        private static ClienteRepository instance;
        public static Dictionary<int, Cliente> clientesDB;
        private static int contador = 1;

        private ClienteRepository()
        {
            clientesDB = new Dictionary<int, Cliente>();
        }

        public static ClienteRepository getInstance()
        {
            if(instance == null)
            {
                instance = new ClienteRepository();
            }
            return instance;
        }

        public void adicionar(Cliente cliente)
        {
            cliente.Codigo = contador;
            clientesDB.Add(contador++, cliente);
        }

        public Cliente buscar(int codigo)
        {
            if(clientesDB.TryGetValue(codigo, out var cliente))
            {
                return cliente;
            }
            else
            {
                return null;
            }
        }

        public Cliente[] listar()
        {
            return clientesDB.Values.ToArray();
        }

        public Cliente excluir(int codigo)
        {
            if(clientesDB.TryGetValue(codigo,out var cliente))
            {
                clientesDB.Remove(codigo); 

                return cliente;
            }
            else
            {
                return null;
            }
        }
    }
}

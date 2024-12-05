using SistemaDeVendas.Model;
using SistemaDeVendas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Service
{
    internal class VendaService
    {
        VendaRepository repository;
        public VendaService() 
        { 
            repository = VendaRepository.getInstance();
        }

        public void adicionar(Venda venda) { repository.adicionar(venda);}

        public Venda buscar(int id) { return repository.buscar(id); }

        public Venda[] listar() { return repository.listar(); }
    }
}

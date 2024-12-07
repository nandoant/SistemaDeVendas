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
        VendaRepository vendaRepository;
        ClienteRepository clienteRepository;
        ProdutoRepository produtoRepository;

        public VendaService() 
        { 
            vendaRepository = VendaRepository.getInstance();
            produtoRepository = ProdutoRepository.getInstance();
            clienteRepository = ClienteRepository.getInstance();
        }

        public void adicionar(Venda venda) 
        { 
            if(venda == null) { throw new Exception("Venda invalida."); }   

            //cliente
            if(clienteRepository.buscar(venda.IdCliente) == null) 
            { 
                throw new Exception("Venda possui um cliente que nao existe.");
            }

            //produtos
            if(venda.getProdutos().Length == 0) { throw new Exception("A venda deve conter pelo menos um produto."); }
            foreach (Produto produto in venda.getProdutos())
            {
                if(produto == null) { throw new Exception("Venda possui um produto invalido."); }
                if(produtoRepository.buscarPorID(produto.Codigo) == null) { throw new Exception("Venda possui um produto que nao existe."); }
            }
            
            try { vendaRepository.adicionar(venda);}
            catch (Exception) { throw new Exception("Erro ao cadastrar a venda. Verifique os dados e tente novamente."); }
        }

        public Venda buscar(int id) 
        { 
            if(id <= 0) { throw new Exception("ID invalido."); }
            try{ return vendaRepository.buscar(id); }
            catch (Exception) { throw new Exception("Venda nao encontrada."); }
        }

        public Venda[] listar() 
        { 
            try{ return vendaRepository.listar(); }
            catch (Exception) { throw new Exception("Erro ao listar as vendas."); }
        }
    }
}

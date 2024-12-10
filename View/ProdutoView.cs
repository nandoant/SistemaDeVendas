using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeVendas.Service;
using SistemaDeVendas.Utils;

namespace SistemaDeVendas.View
{
    internal class ProdutoView
    {
        private ProdutoController produtoController;
        
        public ProdutoView()
        {
            produtoController = new ProdutoController();
        }

        public void Menu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu de Produtos ===");
                Console.WriteLine("1. Cadastrar Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Buscar Produto");
                Console.WriteLine("4. Excluir Produto");
                Console.WriteLine("0. Voltar");
                Console.Write("\nEscolha uma opcao: ");

                opcao = Input.LerInteiro(0, 4);
                Console.Clear();
                switch (opcao)
                {
                    case 1: CadastrarProduto(); break;
                    case 2: ListarProdutos(); break;
                    case 3: BuscarProduto(); break;
                    case 4: ExcluirProduto(); break;
                    case 0: break;
                    default: Console.WriteLine("Opcao invalida!"); break;
                }
                

                if (opcao != 0) 
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            } while (opcao != 0);
        }

        private void CadastrarProduto()
        {
            Console.WriteLine("=== CADASTRO DE PRODUTO ===\n");
            
            Console.Write("Marca: ");
            string marca = Input.LerString();
            
            Console.Write("Modelo: ");
            string modelo = Input.LerString();
            
            Console.Write("Descricao: ");
            string descricao = Input.LerString();
            
            Console.Write("Preco (aceita apenas duas casas decimais, exemplo de formato valido: 3000,05): ");
            double preco = Input.LerDouble(1);
            try
            {
                produtoController.adicionar(marca, modelo, descricao, preco);
                Console.WriteLine("\nProduto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
        }
        

        private void ListarProdutos()
        {
            try
            {
                if (produtoController.listar() == null)
                {
                    Console.WriteLine("Nenhum produto cadastrado.");
                    return;
                }
                produtoController.Exibirlista();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
        }

        private void BuscarProduto()
        {
            Console.WriteLine("=== BUSCAR PRODUTO ===\n");
            Console.Write("Digite o codigo do produto: ");
            int codigo = Input.LerInteiro(0);
            try
            {
                produtoController.buscarPorId(codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
        }
        

        private void ExcluirProduto()
        {
            Console.WriteLine("=== EXCLUIR PRODUTO ===\n");
            Console.Write("Digite o codigo do produto: ");
            int codigo = Input.LerInteiro(0);
            try
            {
                produtoController.remover(codigo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
        }
    }
}


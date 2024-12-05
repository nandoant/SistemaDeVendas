﻿using SistemaDeVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVendas.Repository
{
    internal class VendaRepository
    {
        private static VendaRepository instance;
        private static Dictionary<int, Venda> vendasDB;
        private static int contador;


        VendaRepository()
        {
            vendasDB = new Dictionary<int, Venda>();    
        }

        public static VendaRepository getInstance()
        {
            if (instance == null)
            {
                instance = new VendaRepository();
            }
            return instance;
            
            
        }

        public void adicionar(Venda venda)
        {
            vendasDB.Add(contador++, venda);
        }

        public Venda buscar(int id)
        {
            if (vendasDB.TryGetValue(id, out var venda))
            {
                return venda;
            }
            else
            {
                return null;
            }
        }

        public Venda[] listar()
        {
            return vendasDB.Values.ToArray();
        }
    }
}

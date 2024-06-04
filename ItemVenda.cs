using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public class ItemVenda
    {
        public Produto Produto { get; private set; } // Associação entre classes - Composição
        public int Quantidade {get; private set;}
        public double Preco {get; private set;}
        public double Subtotal => Quantidade * Preco;
        public ItemVenda(int quantidade, double preco, Produto produto)
        {
            Produto = produto;
            Quantidade = quantidade;
            Preco = preco;
        }
    }
}
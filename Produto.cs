using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public class Produto
    {
        public long Codigo { get; set; }
        public string? Nome { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }

        public Produto(long codigo, string nome, double preco, int estoque)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
        }
    }

}
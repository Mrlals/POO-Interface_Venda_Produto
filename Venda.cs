using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public class Venda : IVenda
    {
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public List<ItemVenda> ItensVenda { get; set; }

        public Venda()
        {
            Data = DateTime.Now;
            ItensVenda = new List<ItemVenda>();
        }
        public void AdicionarItem(ItemVenda item)
        {
            ItensVenda.Add(item);
            CalcularTotal();
        }
        private void CalcularTotal()
        {
            Total = 0;
            foreach (var item in ItensVenda)
            {
                Total += item.Subtotal;
            }
        }
        public double CalcularDesconto()
        {
            int totalQuantidade = 0;
            foreach(var item in ItensVenda)
            {
                totalQuantidade += item.Quantidade;
            }
            if (totalQuantidade >= 50)
            {
                return Total * 0.2;
            }
            return 0;
        }
        public double TotalComDesconto()
        {
            return Total - CalcularDesconto();
        }
        public List<ItemVenda> ObterItens()
        {
            return new List<ItemVenda>(ItensVenda);
        }
    }
}
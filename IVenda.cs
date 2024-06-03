using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public interface IVenda
    {
        double Total { get; }
        List<ItemVenda> ItensVenda { get; set; }
        void AdicionarItem(ItemVenda item);
        double CalcularDesconto();
        double TotalComDesconto();
        List<ItemVenda> ObterItens();
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public interface IPagamento
    {
        DateTime Data { get; set; }
        double Total {get; set; }  
        void ProcessarPagamento(); 
    }
}
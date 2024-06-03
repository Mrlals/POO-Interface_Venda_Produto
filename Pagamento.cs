using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public abstract class Pagamento : IPagamento
    {
        public DateTime Data { get; set; }
        public double Total { get; set; }

        protected Pagamento(double total)
        {
            Data = DateTime.Now;
            Total = total;
        }

        public abstract void ProcessarPagamento();
    }
}
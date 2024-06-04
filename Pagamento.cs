using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public abstract class Pagamento
    {
        public DateTime Data { get; private set; }
        public double Total { get; private set; }

        protected Pagamento(double total)
        {
            Data = DateTime.Now;
            Total = total;
        }

        public abstract void ProcessarPagamento();
    }
}
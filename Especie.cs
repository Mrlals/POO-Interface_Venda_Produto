using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public class Especie : Pagamento
    {
        public double Quantia { get; private set; }
        public double Troco { get; private set; }

        public Especie(double total, double quantia) : base(total)
        {
            Quantia = quantia;
            Troco = quantia - total;
        }

        public override void ProcessarPagamento()
        {
            Troco = Quantia - Total;
            Console.WriteLine($"Pagamento em espécie efetuado.. Troco: R${Troco}");
        }
    }
}
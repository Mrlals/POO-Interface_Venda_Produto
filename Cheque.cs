using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public class Cheque : Pagamento
    {
        public long Numero { get; set; }
        public DateTime DataDeposito { get; set; }
        public int Situacao { get; set;}

        public Cheque(double total, long numero, DateTime dataDeposito, int situacao) : base(total)
        {
            Numero = numero;
            DataDeposito = dataDeposito;
            Situacao = situacao;
        }

        public override void ProcessarPagamento()
        {
            Console.WriteLine($"Pagamento com cheque efetuado. Número: {Numero}, Data de Depósito: {DataDeposito}, Situação: {Situacao}");
        }  
    }
}
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public class Cartao : Pagamento
    {
        public string? DadosTransacao { get; private set; }
        public int ResultadoTransacao { get; private set; }

        public Cartao(double total, string dadosTransacao) : base(total)
        {
            DadosTransacao = dadosTransacao;
        }

        public override void ProcessarPagamento()
        {
            Random random = new Random();
            ResultadoTransacao = random.Next(0, 2);
            
            if (ResultadoTransacao == 1)
            {
                Console.WriteLine($"Pagamento com cartão efetuado. Dados da Transação: {DadosTransacao}, Resultado: {ResultadoTransacao}");
            }
            else
            {
                Console.WriteLine($"Pagamento com cartão efetuado. Dados da Transação: {DadosTransacao}, Resultado: {ResultadoTransacao}");
            }
            
        }
    }
}
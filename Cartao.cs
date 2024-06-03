using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace VendaPagamentoProduto
{
    public class Cartao : Pagamento
    {
        public string? DadosTransacao { get; set; }
        public int ResultadoTransacao { get; private set; }



        public Cartao(double total, string dadosTransacao, int resultadoTransacao) : base(total)
        {
            DadosTransacao = dadosTransacao;
            ResultadoTransacao = resultadoTransacao;
        }

        public override void ProcessarPagamento()
        {
            Random random = new Random();
            int numeroAleatorio = random.Next(0, 2);
            
            if (numeroAleatorio ==1)
            {
                Console.WriteLine($"Pagamento com cartão efetuado. Dados da Transação: {DadosTransacao}, Resultado: {ResultadoTransacao}");
                ResultadoTransacao = 1;
            }
            else
            {
                Console.WriteLine($"Pagamento com cartão efetuado. Dados da Transação: {DadosTransacao}, Resultado: {ResultadoTransacao}");
                ResultadoTransacao = 0;
            }
            
        }
    }
}
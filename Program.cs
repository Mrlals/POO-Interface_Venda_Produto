// Main()

using System.Net.Http.Headers;
using VendaPagamentoProduto;

List<Produto> produtos = new List<Produto>();
IVenda venda = new Venda();

Console.WriteLine("CADASTRO DE PRODUTROS");
Console.WriteLine("Digite a quantidade de produtos que deseja cadastrar: ");
int numeroProdutos = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < numeroProdutos; i++)
{
    Console.WriteLine($"Produto {i + 1}");

    Console.WriteLine("Código: ");
    long codigo = Convert.ToInt64(Console.ReadLine());

    Console.WriteLine("Nome: ");
    string? nome = Console.ReadLine();

    Console.WriteLine("Preço: ");
    double preco = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Estoque: ");
    int estoque = Convert.ToInt32(Console.ReadLine());

    produtos.Add(new Produto(codigo, nome, preco, estoque));
}

Console.WriteLine("\nVENDA DE ITENS: ");
long codigoProduto = 1;
int contador = 1;
while (codigoProduto != 0)
{
    Console.WriteLine($"Digite o código do {contador}º produto ou digite 0, para finalizar:");
    codigoProduto = Convert.ToInt64(Console.ReadLine());
    if (codigoProduto == 0) break;

    Produto produtoSelecionado = produtos.Find(p => p.Codigo == codigoProduto);

    if (produtoSelecionado == null)
    {
        Console.WriteLine("Produto não encontrado !!");
        continue;
    }

    Console.WriteLine("Quantidade: ");
    int quantidade = Convert.ToInt32(Console.ReadLine());
    if (quantidade > produtoSelecionado.Estoque)
    {
        Console.WriteLine("Quantidade não disponível!!");
        continue;
    }
    produtoSelecionado.Estoque -= quantidade;
    ItemVenda itemVenda = new ItemVenda(quantidade, produtoSelecionado.Preco, produtoSelecionado);
    venda.AdicionarItem(itemVenda);
    contador ++;
}

Console.WriteLine("\nDescrição da Venda: ");

List<ItemVenda> itens = venda.ObterItens();
foreach (var item in itens)
{
    Console.WriteLine($"Produto: {item.Produto.Nome}, \tQuantidade: {item.Quantidade}, \tPreço Unitário: R$ {item.Preco}, \tSubtotal: R$ {item.Subtotal}");
}


Console.WriteLine($"Total da Venda: R$ {venda.Total}");
Console.WriteLine($"Desconto: R$ {venda.CalcularDesconto()}");
Console.WriteLine($"Total com Desconto: R$ {venda.TotalComDesconto()}");

Console.WriteLine("\nEscolha a forma de pagamento: ");
Console.WriteLine("1 - Espécie");
Console.WriteLine("2 - Cheque");
Console.WriteLine("3 - Cartão");

int opcao = Convert.ToInt32(Console.ReadLine());
IPagamento pagamento = null;

switch (opcao)
{
    case 1:
        Console.WriteLine("Valor de Pagamento: ");
        double quantia = Convert.ToDouble(Console.ReadLine());
        pagamento = new Especie(venda.TotalComDesconto(),quantia);
        break;
    case 2:
        Console.WriteLine("Número do Cheque: ");
        long numeroCheque = Convert.ToInt64(Console.ReadLine());
        DateTime dataDeposito = DateTime.Now;
        Console.WriteLine("Situação do Cheque, insira uma das opções abaixo: \n1 - Normal \n2 - PreDatado \n3 - Administrativo \n4 - Compensação ");
        int situacao = Convert.ToInt32(Console.ReadLine());
        pagamento = new Cheque(venda.TotalComDesconto(), numeroCheque, dataDeposito, situacao);
        break;
    case 3:
        Console.WriteLine("Dados da Transação(Insira uma informação(texto) relacionada ao cartão): ");
        string? dadosTransacao = Console.ReadLine();
        Console.WriteLine("resultado da Transação: ");
        Cartao cartaoPagamento = new Cartao(venda.TotalComDesconto(), dadosTransacao, 0);
        pagamento = cartaoPagamento;
        break;
    default:
        Console.WriteLine("Opção inválida !!");
        break;
}

pagamento.ProcessarPagamento();
if (pagamento is Cartao cartao)
{
    if (cartao.ResultadoTransacao  == 1)
    {
        Console.WriteLine("Pagamento realizado com sucesso.");
    }
    else
    {
        Console.WriteLine("Pagamento não aprovado.");
    }
    }
else
{
    Console.WriteLine("Pagamento realizado com sucesso.");
}
using System.Text;
using System.Threading;
using HotelHostingSystem.NET.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("---------------------------------");
Console.WriteLine("-------- Seja Bem-Vindo! --------");
Console.WriteLine(" Sistema de Hospedagem do Hotel ");
Console.WriteLine("---------------------------------");
Console.WriteLine();
Console.WriteLine();

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> listaHospedes = new List<Pessoa>();


Console.WriteLine("Quantos Hóspedes terão na sua reserva?");
int qtdeHospede = 0;
do
{
    qtdeHospede = Convert.ToInt16(Console.ReadLine());
    if (!(qtdeHospede != 0))
    {
        Console.WriteLine("Por favor insira a quantidade de hóspedes da sua reserva!");
    }

} while (qtdeHospede == 0);

// Loop para criar uma instância de Pessoa para cada hóspede
for (int i = 1; i <= qtdeHospede; i++)
{
    string nomeHospede = $"Hóspede {i}";
    Pessoa pessoa = new Pessoa(nomeHospede);
    listaHospedes.Add(pessoa);
}

string tipoSuite;
int qtdeDiasReservado;
int capacidadeSuite;
decimal valorDiariaSuite = 0;

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("---------------------------------");
Console.WriteLine("------- Configurando SUITE ------");
Console.WriteLine("---------------------------------");
Console.WriteLine();

Console.WriteLine("------------ ATENÇÃO ------------");
Console.WriteLine("Qual tipo de Suite você deseja?");
Console.WriteLine("Digite o NÚMERO da Opção!!!");
Console.WriteLine();
Console.WriteLine("1 - Master");
Console.WriteLine("2 - Premium");
Console.WriteLine("3 - Intermediária");
Console.WriteLine("4 - Básica");

do
{
    Console.WriteLine();
    tipoSuite = Console.ReadLine();
    if (string.IsNullOrEmpty(tipoSuite))
    {
        Console.WriteLine("Por favor, digite uma opção!");

    }
    else
    {
        switch (tipoSuite)
        {
            case "1":
                tipoSuite = "Master";
                valorDiariaSuite = 250.0m; // Valor para a suíte Master
                break;
            case "2":
                tipoSuite = "Premium";
                valorDiariaSuite = 200.0m; // Valor para a suíte Premium
                break;
            case "3":
                tipoSuite = "Intermediária";
                valorDiariaSuite = 130.0m; // Valor para a suíte Intermediária
                break;
            case "4":
                tipoSuite = "Básica";
                valorDiariaSuite = 85.0m; // Valor para a suíte Básica
                break;
            default:
                Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                tipoSuite = null; // Reiniciar o loop
                break;
        }
    }
} while (string.IsNullOrEmpty(tipoSuite));

Console.WriteLine();
Console.WriteLine("Qual deve ser a capacidade da Suite?");
do
{
    capacidadeSuite = Convert.ToInt16(Console.ReadLine());
    if (capacidadeSuite <= 0)
    {
        Console.WriteLine("Por favor, digite qual deve ser a capacidade da suite!");

    }
} while (capacidadeSuite <= 0);

Console.WriteLine();
Console.WriteLine("Quantos dias será reservado?");
do
{
    qtdeDiasReservado = Convert.ToInt16(Console.ReadLine());
    if (qtdeDiasReservado <= 0)
    {
        Console.WriteLine("Por favor, digite quantos dias será reservado!");

    }
} while (qtdeDiasReservado <= 0);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("---------------------------------");
Console.WriteLine("-------- Reservando SUITE -------");
Console.WriteLine("---------------------------------");
Console.WriteLine();

Console.WriteLine("Estamos preparando tudo para você...");

Suite suiteReservada = new(tipoSuite: tipoSuite, capacidade: capacidadeSuite, valorDiaria: valorDiariaSuite);
Reserva reserva = new Reserva(diasReservados: qtdeDiasReservado);

Console.WriteLine("Separando sua Suite...");
reserva.CadastrarSuite(suiteReservada);
reserva.CadastrarHospedes(listaHospedes);
Thread.Sleep(1500);
Console.WriteLine("Calculando o valor da sua reserva...");
decimal valorReservaSuite = reserva.CalcularValorReserva(qtdeDiasReservado);
Thread.Sleep(1000);


Console.WriteLine();
Console.WriteLine("----- Reserva Concluida!!! -----");
Console.WriteLine();
Console.WriteLine();

// Saídas
Console.WriteLine($"Suite: {tipoSuite}");
Console.WriteLine($"Quantidade de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor Diária: {valorDiariaSuite:C}");
Console.WriteLine($"Valor Reserva: {valorReservaSuite:C}");

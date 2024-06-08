namespace HotelHostingSystem.NET.Models;

public class Reserva
{
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {        
        if (Suite.Capacidade >= hospedes.Count)
        {
            Hospedes = hospedes;
        }
        else
        {
            Console.WriteLine();
            //Console.WriteLine("A capacidade da Suíte e o número de hóspedes cadastrados na reserva não estão em conformidade!\n" +
            //                  "REINICIANDO RESERVA ..!");      
            throw new Exception("A capacidade da Suíte e o número de hóspedes cadastrados na reserva não estão em conformidade!\n" +
                                "REINICIANDO RESERVA ..!");
        }
    }      

    public int ObterQuantidadeHospedes()
    {                
        return Hospedes.Count;
    }

    public decimal CalcularValorReserva(decimal qtdeDiarias)
    {
        decimal valorReserva;

        valorReserva = qtdeDiarias * Suite.ValorDiaria;

        if (qtdeDiarias >= 10)
        {
            //desconto de 10%
            decimal desconto = valorReserva * 0.10m;
            valorReserva -= desconto;
        }

        return valorReserva;
    }
}
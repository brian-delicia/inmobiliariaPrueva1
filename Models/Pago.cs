namespace inmobiliariaPrueva1.Models;

public class Pago
{
    public int Id {get; set;}

    public DateTime FechaDePago {get; set; }

    public decimal PagoParcial {get; set;}

    public decimal PagoTotal {get; set;}

    public TipoDePago Tipo {get; set;}

    public int IdReserva {get; set;}
    public Reserva Reserva  {get; set;}=new Reserva();




}
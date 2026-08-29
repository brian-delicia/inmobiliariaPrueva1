using System.ComponentModel.DataAnnotations;

namespace inmobiliariaPrueva1.Models;

public class Pago
{
    public int IdPago {get; set;}
    [Required]
    
    public DateTime FechaDePago {get; set; }
    [Required]
    public decimal PagoParcial {get; set;}
    [Required]
    public decimal PagoTotal {get; set;}
    [Required]
    public TipoDePago Tipo {get; set;}

    public Boolean Estado {get; set;}=true;

    public int IdReserva {get; set;}
    public Reserva Reserva  {get; set;}=new Reserva();




}
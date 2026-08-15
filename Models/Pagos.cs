namespace inmobiliariaPrueva1.Models;

public class Pagos
{
    public int Id {get; set;}

    public DateTime FechaDePago {get; set; }

    public decimal PagoParcial {get; set;}

    public decimal PagoTotal {get; set;}

    public TipoDePago Tipo {get; set;}




}
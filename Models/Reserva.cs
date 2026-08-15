namespace inmobiliariaPrueva1.Models;

public class Reserva
{
    public int Id {get; set;} 
    public Inquilino inquilino{get;set;}=new Inquilino();

    public Inmueble inmueble {get; set;}= new Inmueble();

    public decimal MontoDiario{get; set;}

    public DateTime FechaInicio{get; set;}

    public DateTime FechaFin{get; set;}

    public String Pago {get; set;}="";
    
}
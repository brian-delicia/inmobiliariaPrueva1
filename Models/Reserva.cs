using System.ComponentModel.DataAnnotations;

namespace inmobiliariaPrueva1.Models;

public class Reserva
{
    public int IdReserva {get; set;} 

    public Inquilino Inquilino{get;set;}=new Inquilino();
    [Required]
    public int IdInquilino {get; set;} 

    public Inmueble Inmueble {get; set;}= new Inmueble();
    [Required]
    public int IdInmueble {get; set;} 
    [Required]
    public decimal MontoDiario{get; set;}
    [Required]
    public DateTime FechaInicio{get; set;}
    [Required]
    public DateTime FechaFin{get; set;}

     public Boolean Estado {get; set;}=true;


    public List<Pago>Pagos {get; set;}=new List<Pago>();
    [Required]
    public int IdUsuario {get; set;} 
    public Usuario Usuario {get; set;} =new Usuario();


    
}
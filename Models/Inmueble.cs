using System.ComponentModel.DataAnnotations;

namespace inmobiliariaPrueva1.Models;

public class Inmueble
{
    
    public int IdInmueble {get; set;}
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ0-9\s.,#-]+$")]
    public String Direccion {get; set;}="";
    [Required]
    [Range(1,20,ErrorMessage ="La capacidad maxima es 20")]
    public int Capacidad {get; set;}
    [Required]
    public  TipoInmueble Tipo {get; set;}
    [Required]
    [Range(-90,90,ErrorMessage ="La latitud debe estar entre -90 y 90")]
    public float Latitud {get; set;}
    [Required]
    [Range(-180,180,ErrorMessage ="La longitud debe estar entre -180y 180")]
    public float Longitud {get; set;}
    [Required]
    public decimal PrecioAlquiler {set; get; }

    public Boolean Estado {set; get; }=true;

    public int IdPropietario {get; set;}
    public Propietario Propietario {get; set;}=new Propietario();

    public List<Reserva>ListaReservas {get; set;}= new List<Reserva>();

    


}
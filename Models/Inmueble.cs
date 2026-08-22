namespace inmobiliariaPrueva1.Models;

public class Inmueble
{
    
    public int IdInmueble {get; set;}
    public String Direccion {get; set;}="";
    public int Capacidad {get; set;}
    public  TipoInmueble Tipo {get; set;}

    public float Latitud {get; set;}

    public float Longitud {get; set;}

    public decimal PrecioAlquiler {set; get; }

    public Boolean Estado {set; get; }

    public int IdPropietario {get; set;}
    public Propietario Propietario {get; set;}=new Propietario();

    public List<Reserva>ListaReservas {get; set;}= new List<Reserva>();

    


}
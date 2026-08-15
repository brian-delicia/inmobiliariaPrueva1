namespace inmobiliariaPrueva1.Models;

public class Inmueble
{
    
    public int Id {get; set;}
    public String Direccion {get; set;}="";
    public int Capasidad {get; set;}
    public  TipoInmueble Tipo {get; set;}

    public float Cordenadas {get; set;}

    public decimal PrecioAlquiler {set; get; }

    public Boolean Estado {set; get; }


}
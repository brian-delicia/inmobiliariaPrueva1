using System.Numerics;

namespace inmobiliariaPrueva1.Models;

public class Propietario
{
    public int Dni {get; set;}
    public String Nombre{get; set;}="";
    public String Apellido{get; set;}="";
    public String Telefono {get; set;}="";

    public String Email {get; set;}="";
    
    public List<Inmueble> ListaInmuebles {get; set;}=new List<Inmueble>();
    

}
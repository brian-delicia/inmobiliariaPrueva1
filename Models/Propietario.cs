namespace inmobiliariaPrueva1.Models;

public class Propietario
{
    public int Dni {get; set;}
    public String nombre{get; set;}="";
    public String apellido{get; set;}="";
    public int Telefono {get; set;}

    public String Email {get; set;}="";
    
    public List<Inmueble> ListaInmuebles {get; set;}=new List<Inmueble>();
    

}
namespace inmobiliariaPrueva1.Models;

public class Propietario
{
    public int Dni {get; set;}
    public String Nombres{get; set;}="";
    public String Apellido{get; set;}="";
    public int Telefono {get; set;}

    public String Email {get; set;}="";
    
    public List<Inmueble> ListaInmuebles {get; set;}=new List<Inmueble>();
    

}
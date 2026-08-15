namespace inmobiliariaPrueva1.Models;

public class Inquilino
{
    public int Dni {get; set;}

    public String Nombre{get; set;}="";
    public String Apellido{get; set;}="";
    public int Telefono {get; set;}

    public String Email {get; set;} ="";
     
    public List<String>ListaReserva {get; set;}= new List<String>();

}
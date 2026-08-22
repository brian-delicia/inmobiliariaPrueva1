using System.Numerics;

namespace inmobiliariaPrueva1.Models;

public class Inquilino
{
    public int IdInquilino {get; set;}
    public int Dni {get; set;}

    public String Nombre{get; set;}="";
    public String Apellido{get; set;}="";
    public String Telefono {get; set;}="";

    public String Email {get; set;} ="";

    public Boolean Estado {get; set;}
     
    public List<Reserva>ListaReservas {get; set;}= new List<Reserva>();

}
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace inmobiliariaPrueva1.Models;

public class Inquilino
{
    public int IdInquilino {get; set;}
    [Required]
    [Range(1000000,99999999,ErrorMessage ="El Dni puede tener entre 7 y 8 digitos")]

    public int Dni {get; set;}
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$",ErrorMessage ="El nombre solo acepta letras y espacios")]
    public String Nombre{get; set;}="";
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$",ErrorMessage ="El Apellido solo acepta letras y espacios")]
    public String Apellido{get; set;}="";
    [Required]
    [RegularExpression(@"^\d{10,15}$",ErrorMessage ="El telefono es numerico y puede tener entre 10 y 15 digitos")]
    public String Telefono {get; set;}="";
    [Required]
    [EmailAddress]
    public String Email {get; set;} ="";

    public Boolean Estado {get; set;}=true;
     
    public List<Reserva>ListaReservas {get; set;}= new List<Reserva>();

}
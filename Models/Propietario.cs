using System.ComponentModel.DataAnnotations;//importar validaciones de formulario 

                                            
namespace inmobiliariaPrueva1.Models;

public class Propietario
{
    public int IdPropietario {get; set;}
    [Required]
    [Range(1000000, 99999999,
    ErrorMessage = "El DNI puede tener entre 7y8 números.")]
    public int Dni {get; set;}

    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$",
    ErrorMessage ="El nombre solo puede contener letras y espacios")]
    public String Nombre{get; set;}="";

    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$",
    ErrorMessage ="El apellido solo puede tener letras y espacios")]
    public String Apellido{get; set;}="";

    [Required]
    [RegularExpression(@"^\d{10,15}$",
    ErrorMessage ="El telefono es numerico y puede tener entre 10 y 15 digitos ")]
    public String Telefono {get; set;}="";
    
    [Required]
    [EmailAddress]
    public String Email {get; set;}="";

     public Boolean Estado {get; set;}=true;
    
    public List<Inmueble> ListaInmuebles {get; set;}=new List<Inmueble>();
    

}
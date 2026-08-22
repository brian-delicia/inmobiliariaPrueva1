using System.ComponentModel.DataAnnotations;//importar validaciones de formulario 

                                            
namespace inmobiliariaPrueva1.Models;

public class Propietario
{
    public int IdPropietario {get; set;}
    [Required]
    [Range(10000000, 99999999,
    ErrorMessage = "El DNI debe tener 8 números.")]
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
    [RegularExpression(@"^\d{10}$",
    ErrorMessage ="El telefono es numerico y puede tener 10 digitos ")]
    public String Telefono {get; set;}="";
    
    [Required]
    [EmailAddress]
    public String Email {get; set;}="";

     public Boolean Estado {get; set;}
    
    public List<Inmueble> ListaInmuebles {get; set;}=new List<Inmueble>();
    

}
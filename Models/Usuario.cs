using System.ComponentModel.DataAnnotations;

namespace inmobiliariaPrueva1.Models;

public class Usuario
{
    public int IdUsuario {get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-ZñÑ\s]+$",ErrorMessage ="El nombre solo puede tener letras y espacios")]
     public String Nombre {get; set;}="";
     [Required]
     [RegularExpression(@"^[a-zA-ZñÑ0-9.,#_-]+$",ErrorMessage ="se permiten letras numeros . , # _ -")]

     public String Contraseña {get; set; }="";
     [Required]
     public RolUsuario Rol {get; set;}

      public Boolean Estado {get; set;}=true;

     public List<Reserva> Reservas {get; set;} = new List<Reserva>();
     


}
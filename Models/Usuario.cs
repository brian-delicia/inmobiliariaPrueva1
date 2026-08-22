namespace inmobiliariaPrueva1.Models;

public class Usuario
{
    public int IdUsuario {get; set; }
     public String Nombre {get; set;}="";

     public String Contraseña {get; set; }="";

     public RolUsuario Rol {get; set;}

      public Boolean Estado {get; set;}

     public List<Reserva> Reservas {get; set;} = new List<Reserva>();
     


}
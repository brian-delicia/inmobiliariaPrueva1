namespace inmobiliariaPrueva1.Models;

public class Usuario
{
    public int Id {get; set; }
     public String Nombre {get; set;}="";

     public String Contraseña {get; set; }="";

     public RolUsuario Rol {get; set;}

     public List<Reserva> Reservas {get; set;} = new List<Reserva>();
     


}
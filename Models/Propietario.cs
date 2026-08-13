public class Propietario
{
    public int Dni {get; set;}
    public String nombreCompleto{get; set;}="";
    public int Telefono {get; set;}

    public String Email {get; set;}="";
    
    public List<string> ListaInmuebles {get; set;}=new List<string>();
    

}
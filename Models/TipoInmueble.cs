using System.ComponentModel.DataAnnotations;
namespace inmobiliariaPrueva1.Models
{
    public class TipoInmueble
    {
        
        public int IdTipoInmueble {get; set;}
        [Required]
        [RegularExpression(@"^[a-zA-ZñÑ\s]+$")]
        public String Descripcion {get; set;}="";
       
        [Required]
        public Boolean Estado {get; set;} =true;
    }
    
}
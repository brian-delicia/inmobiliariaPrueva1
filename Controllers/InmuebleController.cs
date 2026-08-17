using Microsoft.AspNetCore.Mvc;
using inmobiliariaPrueva1.Models;
 
public class InmuebleController : Controller
{
    public IActionResult Index()
    {
        Inmueble inmueble1 = new Inmueble();
        inmueble1.Id=1;
        inmueble1.Direccion="lavalle 789 ";
        inmueble1.Capacidad=4;
        inmueble1.Tipo=TipoInmueble.Departamento;
        inmueble1.Coordenadas=745.123f;
        inmueble1.PrecioAlquiler=85000m;
        inmueble1.Estado=true;

        return View(inmueble1);
    }
}
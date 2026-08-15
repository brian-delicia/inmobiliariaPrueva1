using Microsoft.AspNetCore.Mvc;
using inmobiliariaPrueva1.Models;


public class PropietarioController : Controller
{
    
    public IActionResult Index()
    {
        Propietario propietario1 = new Propietario();
        propietario1.Dni=32165498;
        propietario1.nombre="javier";
        propietario1.apellido="orco";
        propietario1.Telefono=266545659;
        propietario1.Email="orojavier@gmail.com";
        return View(propietario1);
    }
}
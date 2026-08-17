using Microsoft.AspNetCore.Mvc;
using inmobiliariaPrueva1.Models;

public class InquilinoController : Controller
{
    public IActionResult Index()
    {
        Inquilino inquilino1 = new Inquilino();
        inquilino1.Dni=38439671;
        inquilino1.Nombre="brian";
         inquilino1.Apellido="delicia";
        inquilino1.Telefono="266548789";
        inquilino1.Email="brian@gmmail.com";
        
        
       return View(inquilino1); 
        }
}
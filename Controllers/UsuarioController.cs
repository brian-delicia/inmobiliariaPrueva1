using Microsoft.AspNetCore.Mvc;
using inmobiliariaPrueva1.Models;

public class UsuarioController : Controller
{
    public IActionResult Index()
    {
        Usuario usuario1 = new Usuario();
        usuario1.Id=1;
        usuario1.Nombre="Esteban";
        usuario1.Contraseña="9qwe4587asd";
        usuario1.Roll=RollUsuario.Administrativo;
        return View(usuario1);
    }
}
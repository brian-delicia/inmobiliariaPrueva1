using Microsoft.AspNetCore.Mvc;
using inmobiliariaPrueva1.Models;

public class ReservaController : Controller
{
    public IActionResult Index()
    {
        Reserva reserva1 = new Reserva();
        reserva1.inquilino=new Inquilino();
        reserva1.inmueble= new Inmueble();
        reserva1.MontoDiario=85.000m;
        reserva1.FechaInicio=new DateTime(2026,8,15,19,2,0); //new DateTime(año, mes, día, hora, minutos, segundos)
        reserva1.FechaFin=new DateTime(2026,9,15,19,2,0);
        reserva1.Pago="cambiar forma de pago";

        return View(reserva1);
    }
}
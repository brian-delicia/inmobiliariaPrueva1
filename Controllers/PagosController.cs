using Microsoft.AspNetCore.Mvc;
using inmobiliariaPrueva1.Models;

public class PagosController : Controller
{
    public IActionResult Index()
    {
        Pagos pago1=new Pagos();
        pago1.Id=1;
        pago1.FechaDePago= new DateTime(2026,8,15,19,30,0);
        pago1.PagoParcial=5.000m;
        pago1.PagoTotal=85.000m;
        pago1.Tipo=TipoDePago.Efectivo;

        return View(pago1);
    }
}
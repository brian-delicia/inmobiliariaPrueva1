using Microsoft.AspNetCore.Mvc;
using inmobiliariaPrueva1.Data;


namespace inmobiliariaPrueva1.Controllers{
public class PropietarioController : Controller
{
    private readonly ApplicationDbContext _context;

    public PropietarioController(ApplicationDbContext context)
        {
            _context=context;
        }
    public IActionResult Index()
    {
        var propietarios = _context.Propietarios.ToList();
        
        return View(propietarios);
    }
}
}
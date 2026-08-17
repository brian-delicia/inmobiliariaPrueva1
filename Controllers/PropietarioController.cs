using Microsoft.AspNetCore.Mvc;
using inmobiliariaPrueva1.Data;
using inmobiliariaPrueva1.Models;


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

    public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Propietario propietario)
        {
            Console.WriteLine("ENTRO AL CREATE POST");
            _context.Propietarios.Add(propietario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
}
}
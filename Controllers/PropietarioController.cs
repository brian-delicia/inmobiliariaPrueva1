using Microsoft.AspNetCore.Mvc;

using inmobiliariaPrueva1.Models;
using inmobiliariaPrueva1.Services;


namespace inmobiliariaPrueva1.Controllers;

public class PropietarioController: Controller
{
    private readonly PropietarioService _service;
   
    public PropietarioController(PropietarioService service)
    {
       _service=service;
    }



    public IActionResult Index()
    {
        var propietarios=_service.ObtenerTodos();
      return View(propietarios);
    }
    
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Propietario propietario)
    {
        if(!ModelState.IsValid){
       return View(propietario); }
    
        

  
        if (_service.ExisteDni(propietario.Dni))
        {
            ModelState.AddModelError("Dni","El Dni ya esta registrado");
            return View(propietario);

        }
        
        _service.Crear(propietario);
        
        return RedirectToAction("Index");
        
        
        }
        
    }


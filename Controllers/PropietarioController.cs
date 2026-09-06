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

        TempData["Mensaje"]="Propietario creado con exito";
        
        return RedirectToAction("Index");
        
        
        }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var propietario= _service.ObtenerPorId(id);
        if (propietario == null)
        {
            return NotFound();
        }
        return View(propietario);
    }        
    
    [HttpPost]
    public IActionResult Edit(Propietario propietario)

    {
        if (!ModelState.IsValid)
        {
            return View(propietario);
        }
        bool dniExiste= _service.ExisteDniEnOtroPropietario(propietario.Dni,propietario.IdPropietario);

        if (dniExiste)
        {
            ModelState.AddModelError("Dni","El dni ya esta registrado por otro propietario ");
            return View(propietario);
        }
        _service.Actualizar(propietario);

        TempData["Mensaje"]="Propietario actualizado correctamente";
        return RedirectToAction("Index");
    }
    
    
    [HttpGet]
    public IActionResult Baja(int id)
    {
        var propietario=_service.ObtenerPorId(id);
        if (propietario == null)
        {
            return NotFound();
        }
        return View(propietario);
        
    }
    
    
    [HttpPost]
    public IActionResult DarDeBaja(int idPropietario)
    {
         Console.WriteLine($"ID recibido: {idPropietario}");
        _service.DarDeBaja(idPropietario);

        TempData["Mensaje"]="Propietario dado de baja correctamente";

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Bajas()
    {
        var propietarios =_service.ObtenerDadosDeBaja();

        return View(propietarios);
    }

    [HttpPost]
    public IActionResult Reactivar(int IdPropietario)
    {
        _service.Reactivar(IdPropietario);
        TempData["Mensaje"]="propietario activo nuevamente";
        return RedirectToAction("Index");
    }
    }


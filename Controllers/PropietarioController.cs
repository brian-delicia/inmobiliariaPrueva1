using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using inmobiliariaPrueva1.Models;


namespace inmobiliariaPrueva1.Controllers;

public class PropietarioController: Controller
{
    private readonly string _connectionString;
    public PropietarioController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }


    
    public IActionResult Index()
    {
        List<Propietario>propietarios = new List<Propietario>();

        using var connection = new MySqlConnection(_connectionString);
        
        connection.Open();

        string sql=""" 
        SELECT Dni,Nombre,Apellido,Telefono,Email
        FROM Propietarios 
        
        """;

        using var command= new MySqlCommand(sql,connection);

        using var reader=command.ExecuteReader();

        while (reader.Read())
        {
            Propietario propietario =new Propietario();

            propietario.Dni=reader.GetInt32("Dni");
            propietario.Nombre=reader.GetString("Nombre");
            propietario.Apellido=reader.GetString("Apellido");
            propietario.Telefono=reader.GetString("Telefono");
            propietario.Email=reader.GetString("Email");
           
           propietarios.Add(propietario);
        }
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
    
        using var connection =new MySqlConnection(_connectionString);
        connection.Open();

        string sqlExiste="""
        SELECT COUNT(*)
        FROM propietarios
        WHERE Dni=@Dni
        """;
        using var commandExiste=new MySqlCommand(sqlExiste,connection);
        commandExiste.Parameters.AddWithValue("@Dni",propietario.Dni);

        int cantidad= Convert.ToInt32(commandExiste.ExecuteScalar());
        if (cantidad > 0)
        {
            ModelState.AddModelError("Dni","El Dni ya esta registrado");
            return View(propietario);
        }

        string sql = """
        INSERT INTO Propietarios
        (Dni, Nombre, Apellido, Telefono, Email)
        VALUES
        (@Dni, @Nombre, @Apellido, @Telefono, @Email)
        """;
        using var command= new MySqlCommand(sql,connection);

        command.Parameters.AddWithValue("@Dni",propietario.Dni);
        command.Parameters.AddWithValue("@Nombre",propietario.Nombre);
        command.Parameters.AddWithValue("@Apellido",propietario.Apellido);
        command.Parameters.AddWithValue("@Telefono",propietario.Telefono);
        command.Parameters.AddWithValue("@Email",propietario.Email);

        command.ExecuteNonQuery();
        
        return RedirectToAction("Index");
        
        
        }
        
    }


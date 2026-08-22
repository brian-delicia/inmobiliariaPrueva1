 using MySqlConnector;
 using inmobiliariaPrueva1.Models;
 namespace inmobiliariaPrueva1.DaoMySQL;

 public class PropietarioDAO
{
    private readonly string _connectionString;
     public PropietarioDAO(string connectionString)
    {
        _connectionString = connectionString;
    }


public List<Propietario>ObtenerTodos()
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
        return propietarios;
}
public bool ExisteDni(int dni)
    {
        using var connection=new MySqlConnection(_connectionString);
        connection.Open();
        String sql="""
        SELECT COUNT(*)
        FROM Propietarios
        WHERE Dni=@Dni
        """;
        using var command=new MySqlCommand(sql,connection);
        command.Parameters.AddWithValue("@Dni",dni);

        int cantidad=Convert.ToInt32(command.ExecuteScalar);

        return cantidad > 0 ;
    }

    public void Crear(Propietario propietario)
    {
        using var connection=new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        INSERT INTO Propietarios
        (Dni,Nombre,Apellido,Telefono,Email,Estado)
        VALUES(@Dni,@Nombre,@Telefono,@Email,@Estado)
        """;
        using var comand=new MySqlCommand(sql,connection);

        comand.Parameters.AddWithValue("@Dni",propietario.Dni);
        comand.Parameters.AddWithValue("@Nombre",propietario.Nombre);
        comand.Parameters.AddWithValue("@Apellido",propietario.Apellido);
        comand.Parameters.AddWithValue("@Telefono",propietario.Telefono);
        comand.Parameters.AddWithValue("@Email",propietario.Email);
        comand.Parameters.AddWithValue("@Estado",propietario.Estado);

        comand.ExecuteNonQuery();
    }
}
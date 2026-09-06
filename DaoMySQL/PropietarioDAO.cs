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
        SELECT IdPropietario,Dni,Nombre,Apellido,Telefono,Email,Estado
        FROM Propietarios 
        WHERE Estado = true
        
        """;

        using var command= new MySqlCommand(sql,connection);

        using var reader=command.ExecuteReader();

        while (reader.Read())
        {
            Propietario propietario =new Propietario();

            propietario.IdPropietario=reader.GetInt32("IdPropietario");
            propietario.Dni=reader.GetInt32("Dni");
            propietario.Nombre=reader.GetString("Nombre");
            propietario.Apellido=reader.GetString("Apellido");
            propietario.Telefono=reader.GetString("Telefono");
            propietario.Email=reader.GetString("Email");
            propietario.Estado=reader.GetBoolean("Estado");
           
           propietarios.Add(propietario);
        }
        return propietarios;
}

public List<Propietario> ObtenerDadosDeBaja()
    {
        List<Propietario>ListaBaja=new List<Propietario>();
        using var connection=new MySqlConnection(_connectionString);
        
        connection.Open();

        string sql="""
        SELECT IdPropietario, Dni, Nombre, Apellido, Telefono, Email, Estado
        FROM Propietarios
        WHERE Estado = false
        """;
        using var command=new MySqlCommand(sql,connection);

        using var reader= command.ExecuteReader();
        while (reader.Read())
        {
            Propietario propietario =new Propietario()
            {
                       IdPropietario = reader.GetInt32("IdPropietario"),
            Dni = reader.GetInt32("Dni"),
            Nombre = reader.GetString("Nombre"),
            Apellido = reader.GetString("Apellido"),
            Telefono = reader.GetString("Telefono"),
            Email = reader.GetString("Email"),
            Estado = reader.GetBoolean("Estado")
        };

            ListaBaja.Add(propietario);

        }
        return ListaBaja;
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

        int cantidad=Convert.ToInt32(command.ExecuteScalar());

        return cantidad > 0 ;
    }
    public bool ExisteDniEnOtroPropietario(int dni,int idPropietario)
    {
        using var connection=new MySqlConnection(_connectionString);
        connection.Open();
        String sql="""
        SELECT COUNT(*)
        FROM Propietarios
        WHERE Dni=@Dni
        AND IdPropietario <> @IdPropietario
        """;
        using var command=new MySqlCommand(sql,connection);
        command.Parameters.AddWithValue("@Dni",dni);
        command.Parameters.AddWithValue("@IdPropietario",idPropietario);

        int cantidad=Convert.ToInt32(command.ExecuteScalar());

        return cantidad > 0 ;
    }

public void Crear(Propietario propietario)
    {
        using var connection=new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        INSERT INTO Propietarios
        (Dni,Nombre,Apellido,Telefono,Email,Estado)
        VALUES(@Dni,@Nombre,@Apellido,@Telefono,@Email,@Estado)
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


public Propietario? ObtenerPorId(int IdPropietario)  //? puede devolver un propietario o null
    {
        using var conection=new MySqlConnection(_connectionString);
        
        conection.Open();

        string sql="""
                SELECT IdPropietario,Dni,Nombre,Apellido,Telefono,Email,Estado
                FROM Propietarios 
                WHERE IdPropietario = @IdPropietario 
                """;
        using var command=new MySqlCommand(sql,conection);

        command.Parameters.AddWithValue("@IdPropietario",IdPropietario);

        using var reader= command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }
        return new Propietario
        {
            IdPropietario= reader.GetInt32("IdPropietario"),
            Dni= reader.GetInt32("Dni"),
            Nombre=reader.GetString("Nombre"),
            Apellido=reader.GetString("Apellido"),
            Telefono=reader.GetString("Telefono"),
            Email=reader.GetString("Email"),
            Estado=reader.GetBoolean("Estado")
        };
        
        
    }

public void Actualizar(Propietario propietario)
    {
        using var connection=new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""

            UPDATE Propietarios
            SET
                Dni=@Dni,
                Nombre=@Nombre,
                Apellido=@Apellido,
                Telefono=@Telefono,
                Email=@Email
            WHERE IdPropietario = @IdPropietario
            """;    
        using var command=new MySqlCommand(sql,connection);
        
        command.Parameters.AddWithValue("@IdPropietario",propietario.IdPropietario); 
        command.Parameters.AddWithValue("@Dni",propietario.Dni);    
        command.Parameters.AddWithValue("@Nombre",propietario.Nombre);
        command.Parameters.AddWithValue("@Apellido",propietario.Apellido);
        command.Parameters.AddWithValue("@Telefono",propietario.Telefono);   
        command.Parameters.AddWithValue("@Email",propietario.Email);
        
        command.ExecuteNonQuery();
    } 

public void DarDeBaja(int idPropietario)
    {
        using var connecton= new MySqlConnection(_connectionString);
        connecton.Open();

        string sql="""
        UPDATE Propietarios
        SET Estado = false
        WHERE IdPropietario = @IdPropietario
        """;
        using var command= new MySqlCommand(sql,connecton);
        
        command.Parameters.AddWithValue("@IdPropietario",idPropietario);

        command.ExecuteNonQuery();
    }

public void Reactivar(int IdPropietario)
    {
        using var connection= new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        UPDATE Propietarios
        SET Estado=true
        WHERE IdPropietario = @IdPropietario
        """;
        using var command=new MySqlCommand(sql,connection);
        
        command.Parameters.AddWithValue("@IdPropietario",IdPropietario);
        
        command.ExecuteNonQuery();
    }
}




using MySqlConnector;
using inmobiliariaPrueva1.Models;
namespace inmobiliariaPrueva1.DaoMySQL;


public class InquilinoDAO
{
    private readonly string _connectionString;

    public InquilinoDAO(string connectionString)
    {
        _connectionString=connectionString;
    }
    public List<Inquilino> ObtenerTodos()
    {
        List<Inquilino>inquilinos =new List<Inquilino>();
        using var connection= new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        SELECT IdInquilino,Dni,Nombre,Apellido,Telefono,Email,Estado
        FROM Inquilinos
        WHERE Estado=true 
        """;

        using var command =new MySqlCommand(sql,connection);

        using var reader=command.ExecuteReader();
        while (reader.Read())
        {
            Inquilino inquilino=new Inquilino();

            inquilino.IdInquilino=reader.GetInt32("IdInquilino");
            inquilino.Dni=reader.GetInt32("Dni");
            inquilino.Nombre=reader.GetString("Nombre");
            inquilino.Apellido=reader.GetString("Apellido");
            inquilino.Telefono=reader.GetString("Telefono");
            inquilino.Email=reader.GetString("Email");
            inquilino.Estado=reader.GetBoolean("Estado");

            inquilinos.Add(inquilino);
        }
        return inquilinos;
    }

    public List<Inquilino> ObtenerDadosDeBaja()
    {
        List<Inquilino>ListaBaja=new List<Inquilino>();

        using var connection= new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        SELECT IdInquilino,Dni,Nombre,Apellido,Telefono,Email,Estado
        FROM Inquilinos
        WHERE Estado=false
        """;
        using var command=new MySqlCommand(sql,connection);

        using var reader=command.ExecuteReader();
        while (reader.Read())
        {
            Inquilino inquilino =new Inquilino()
            {
            IdInquilino=reader.GetInt32("IdInquilino"),
            Dni=reader.GetInt32("Dni"),
            Nombre=reader.GetString("Nombre"),
            Apellido=reader.GetString("Apellido"),
            Telefono=reader.GetString("Telefono"),
            Email=reader.GetString("Email"),
            Estado=reader.GetBoolean("Estado"),

            };
            ListaBaja.Add(inquilino);
        }
        return ListaBaja;
    }

    public bool ExisteDni(int dni)
    {
        using var connection =new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        SELECT COUNT(*)
        FROM Inquilinos
        WHERE Dni=@Dni
        """;

        using var command=new MySqlCommand(sql,connection);
        command.Parameters.AddWithValue("@Dni",dni);

        int cantidad=Convert.ToInt32(command.ExecuteScalar());

        return cantidad>0;
        
    }
    public bool ExisteDniEnOtroInqulino(int dni,int idInquilino)
    {
        using var connection=new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        SELECT COUNT(*)
        FROM Inquilinos
        WHERE Dni=@Dni 
        AND IdInquilino <> @IdInquilino
        """;
        using var command=new MySqlCommand(sql,connection);
        command.Parameters.AddWithValue("@Dni",dni);
        command.Parameters.AddWithValue("@IdInquilino",idInquilino);

        int cantidad=Convert.ToInt32(command.ExecuteScalar());

        return cantidad > 0;
    }

    public void Crear(Inquilino inquilino)
    {
        using var connection=new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        INSERT INTO Inquilinos
        (Dni,Nombre,Apellido,Telefono,Email,Estado)
        VALUES(@Dni,@Nombre,@Apellido,@Telefono,@Email,@Estado)
        """;
        using var command=new MySqlCommand(sql,connection);

        command.Parameters.AddWithValue("@Dni",inquilino.Dni);
        command.Parameters.AddWithValue("@Nombre",inquilino.Nombre);
        command.Parameters.AddWithValue("@Apellido",inquilino.Apellido);
        command.Parameters.AddWithValue("@Telefono",inquilino.Telefono);
        command.Parameters.AddWithValue("@Email",inquilino.Email);
        command.Parameters.AddWithValue("@Estado",inquilino.Estado);

        command.ExecuteNonQuery();
    }

    public Inquilino? ObtenerPorId(int idInquilino)
    {
        using var connection =new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        SELECT IdInquilino,Dni,Nombre,Apellido,Telefono,Email,Estado
        FROM Inquilinos
        WHERE IdInquilino = @IdInquilino
        """;
        using var command= new MySqlCommand(sql,connection);
         
        command.Parameters.AddWithValue("@IdInquilino",idInquilino);
         using var reader=command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }
        return new Inquilino
        {
            IdInquilino=reader.GetInt32("IdInquilino"),
            Dni=reader.GetInt32("Dni"),
            Nombre=reader.GetString("Nombre"),
            Apellido=reader.GetString("Apellido"),
            Telefono=reader.GetString("Telefono"),
            Email=reader.GetString("Email"),
            Estado=reader.GetBoolean("Estado")
        };

    }
    public void Actualizar(Inquilino inquilino)
    {
        using var connection=new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        UPDATE Inquilinos
        SET
            Dni = @Dni,
            Nombre = @Nombre,
            Apellido = @Apellido,
            Telefono = @Telefono,
            Email = @Email
            
        WHERE IdInquilino= @IdInquilino
        """;
        using var command=new MySqlCommand(sql,connection);

        command.Parameters.AddWithValue("@IdInquilino",inquilino.IdInquilino);
        command.Parameters.AddWithValue("@Dni",inquilino.Dni);
        command.Parameters.AddWithValue("@Nombre",inquilino.Nombre);
        command.Parameters.AddWithValue("@Apellido",inquilino.Apellido);
        command.Parameters.AddWithValue("@Telefono",inquilino.Telefono);
        command.Parameters.AddWithValue("@Email",inquilino.Email);

        command.ExecuteNonQuery();

    }

    public void DarDeBaja(int idInquilino)
    {
        using var connection=new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        UPDATE Inquilinos
        SET Estado = false
        WHERE IdInquilino = @IdInquilino
        """;
        using var command=new MySqlCommand(sql,connection);
        
        command.Parameters.AddWithValue("@IdInquilino",idInquilino);

        command.ExecuteNonQuery();       
    }
    public void Reactivar(int idInquilino)
    {
        using var connection= new MySqlConnection(_connectionString);
        connection.Open();

        string sql="""
        UPDATE Inquilinos
        SET Estado=true
        WHERE IdInquilino = @IdInquilino
        """;
        using var command=new MySqlCommand(sql,connection);
        
        command.Parameters.AddWithValue("@IdInquilino",idInquilino);
        
        command.ExecuteNonQuery();
    }
}








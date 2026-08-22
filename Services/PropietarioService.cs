using inmobiliariaPrueva1.DaoMySQL;
using inmobiliariaPrueva1.Models;

namespace inmobiliariaPrueva1.Services;

public class PropietarioService
{
    private readonly PropietarioDAO _dao;

    public PropietarioService(PropietarioDAO dao)
    {
        _dao=dao;
    }
    public List<Propietario> ObtenerTodos()
    {
        return _dao.ObtenerTodos();
    }
    public bool ExisteDni(int dni)
    {
        return _dao.ExisteDni(dni) ;
    }

    public void Crear(Propietario propietario)
    {
         _dao.Crear(propietario);
    }

}
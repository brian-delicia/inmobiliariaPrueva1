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
    
    public List<Propietario> ObtenerDadosDeBaja()
    {
        return _dao.ObtenerDadosDeBaja();
    }
    public bool ExisteDni(int dni)
    {
        return _dao.ExisteDni(dni) ;
    }

    public void Crear(Propietario propietario)
    {
         _dao.Crear(propietario);
    }

    public Propietario? ObtenerPorId(int IdPropietario)
    {
        return _dao.ObtenerPorId(IdPropietario);
    }
    public bool ExisteDniEnOtroPropietario(int dni, int IdPropietario)
    {
        return _dao.ExisteDniEnOtroPropietario( dni, IdPropietario);
    }
    public void Actualizar(Propietario propietario)
    {
        _dao.Actualizar(propietario);
    }

    public void DarDeBaja(int idPropietario)
    {
        _dao.DarDeBaja(idPropietario);
    }
    public void Reactivar(int IdPropietario)
    {
        _dao.Reactivar(IdPropietario);
    }
}
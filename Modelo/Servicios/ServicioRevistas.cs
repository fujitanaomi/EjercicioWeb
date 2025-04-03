using EjercicioWeb.Modelo.DAO;
using EjercicioWeb.Modelo.Entidades;

namespace EjercicioWeb.Modelo.Servicios
{
    public static class ServicioRevistas
    {
        public static int Crear(revista revista)
        {
            return GenericDAO<revista>.Crear(revista);
        }

        public static revista Buscar(int id)
        {
            return GenericDAO<revista>.Buscar(id);
        }

        public static void Actualizar(revista revista)
        {
            GenericDAO<revista>.Actualizar(revista);
        }

        public static void Eliminar(int id)
        {
            GenericDAO<revista>.Eliminar(id);
        }
    }
}

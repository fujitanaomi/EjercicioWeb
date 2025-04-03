using EjercicioWeb.Modelo.DAO;
using EjercicioWeb.Modelo.Entidades;

namespace EjercicioWeb.Modelo.Servicios
{
	public static class ServicioLibros
	{
		public static int Crear(libro libro)
		{
			return GenericDAO<libro>.Crear(libro);
		}

		public static libro Buscar(int id)
		{
			return GenericDAO<libro>.Buscar(id);
		}

		public static void Actualizar(libro libro)
		{
			GenericDAO<libro>.Actualizar(libro);
		}

		public static void Eliminar(int id)
		{
			GenericDAO<libro>.Eliminar(id);
		}
	}
}

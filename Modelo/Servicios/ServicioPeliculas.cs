using EjercicioWeb.Modelo.DAO;
using EjercicioWeb.Modelo.Entidades;

namespace EjercicioWeb.Modelo.Servicios
{
	public static class ServicioPeliculas
	{
		public static int Crear(pelicula pelicula)
		{
			return GenericDAO<pelicula>.Crear(pelicula);
		}

		public static pelicula Buscar(int id)
		{
			return GenericDAO<pelicula>.Buscar(id);
		}

		public static void Actualizar(pelicula pelicula)
		{
			GenericDAO<pelicula>.Actualizar(pelicula);
		}

		public static void Eliminar(int id)
		{
			GenericDAO<pelicula>.Eliminar(id);
		}
	}
}

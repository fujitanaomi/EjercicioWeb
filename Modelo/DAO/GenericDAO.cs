using EjercicioWeb.Modelo.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioWeb.Modelo.DAO
{
	public static class GenericDAO<T> where T : IEntidad
	{
		private static List<T> BaseDatosEnMemoria = new List<T>();
		private static int NextId = 1;

		public static int Crear(T entidad)
		{
			entidad.id = NextId++;
			BaseDatosEnMemoria.Add(entidad);
			return entidad.id;
		}

		public static T Buscar(int id)
		{
			return BaseDatosEnMemoria.FirstOrDefault(x => x.id == id);
		}

		public static void Actualizar(T entidad)
		{
			int indice = BaseDatosEnMemoria.FindIndex(x => x.id == entidad.id);
			if (indice != -1)
				BaseDatosEnMemoria[indice] = entidad;
		}

		public static void Eliminar(int id)
		{
			int indice = BaseDatosEnMemoria.FindIndex(x => x.id == id);
			if (indice != -1)
				BaseDatosEnMemoria.RemoveAt(indice);
		}
	}
}

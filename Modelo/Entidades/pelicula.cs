using System;

namespace EjercicioWeb.Modelo.Entidades
{
	public class pelicula : IEntidad
	{
		public int id { get; set; }
		public string titulo { get; set; }
		public int año { get; set; }

		public pelicula(String titulo, int año)
		{
			this.titulo = titulo;
			this.año = año;
		}
	}
}

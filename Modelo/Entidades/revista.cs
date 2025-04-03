using EjercicioWeb.Modelo.Entidades;

namespace EjercicioWeb.Modelo.Entidades
{
    public class revista : IEntidad
    {
        public int id { get; set; }
        public string titulo { get; set; }

        public revista(string titulo)
        {
            this.titulo = titulo;
        }
    }
}

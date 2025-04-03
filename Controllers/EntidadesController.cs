using EjercicioWeb.Modelo.DAO;
using EjercicioWeb.Modelo.Entidades;
using EjercicioWeb.Modelo.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace EjercicioWeb.Controllers
{
    public class EntidadesController : Controller
    {
        private static int contadorPeliculas = 1;
        private static int contadorLibros = 1;
        private static int contadorRevistas = 1;

        private static Dictionary<string, Type> tiposEntidad = new Dictionary<string, Type>
        {
            { "Película", typeof(pelicula) },
            { "Libro", typeof(libro) },
            { "Revista", typeof(revista) }
        };

        private static Dictionary<string, Type> tiposServicio = new Dictionary<string, Type>
        {
            { "Película", typeof(ServicioPeliculas) },
            { "Libro", typeof(ServicioLibros) },
            { "Revista", typeof(ServicioRevistas) }
        };

        private static List<string> logOperaciones = new List<string>();

        // GET: Entidades
        public ActionResult Index(string entidad = "Película", string filtro = "")
        {
            ViewBag.Entidades = new SelectList(tiposEntidad.Keys, entidad);
            ViewBag.Seleccionada = entidad;

            Type tipoEntidad = tiposEntidad[entidad];
            Type tipoGenericDAO = typeof(GenericDAO<>).MakeGenericType(tipoEntidad);
            var campoBD = tipoGenericDAO.GetField("BaseDatosEnMemoria", BindingFlags.NonPublic | BindingFlags.Static);
            var lista = campoBD?.GetValue(null) as IEnumerable<IEntidad>;

            var resultado = lista?.ToList() ?? new List<IEntidad>();

            if (!string.IsNullOrEmpty(filtro))
                resultado = resultado.Where(x => x.titulo.ToLower().Contains(filtro.ToLower())).ToList();

            return View(resultado);
        }

        public ActionResult Crear(string entidad)
        {
            ViewBag.Entidad = entidad;
            return View();
        }

        [HttpPost]
        public ActionResult Crear(string entidad, string titulo, int? anio = null)
        {
            Type tipoEntidad = tiposEntidad[entidad];
            Type tipoServicio = tiposServicio[entidad];

            IEntidad nuevo;

            if (tipoEntidad == typeof(pelicula))
                nuevo = new pelicula(titulo, anio ?? DateTime.Now.Year);
            else if (tipoEntidad == typeof(libro))
                nuevo = new libro(titulo);
            else
                nuevo = new revista(titulo);

            tipoServicio.GetMethod("Crear").Invoke(null, new object[] { nuevo });
            logOperaciones.Add($"{DateTime.Now}: Crear → {entidad} (id: {nuevo.id})");

            return RedirectToAction("Index", new { entidad });
        }
        //public ActionResult Crear(string entidad)
        //{
        //    Type tipoEntidad = tiposEntidad[entidad];
        //    Type tipoServicio = tiposServicio[entidad];

        //    IEntidad nuevo;

        //    if (tipoEntidad == typeof(pelicula))
        //        nuevo = new pelicula($"Película {contadorPeliculas++}", DateTime.Now.Year);
        //    else if (tipoEntidad == typeof(libro))
        //        nuevo = new libro($"Libro {contadorLibros++}");
        //    else
        //        nuevo = new revista($"Revista {contadorRevistas++}");

        //    tipoServicio.GetMethod("Crear").Invoke(null, new object[] { nuevo });

        //    logOperaciones.Add($"{DateTime.Now}: Crear → {entidad} (id: {nuevo.id})");

        //    return RedirectToAction("Index", new { entidad });
        //}

        public ActionResult Eliminar(string entidad, int id)
        {
            Type tipoServicio = tiposServicio[entidad];
            tipoServicio.GetMethod("Eliminar").Invoke(null, new object[] { id });

            logOperaciones.Add($"{DateTime.Now}: Eliminar → {entidad} (id: {id})");

            return RedirectToAction("Index", new { entidad });
        }

        public ActionResult Informe()
        {
            return Content(string.Join("\n", logOperaciones), "text/plain");
        }
    }
}
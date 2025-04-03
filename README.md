# EjercicioWeb
Ejercicio CRUD Dinámico Web – ASP.NET MVC (.NET Framework 4.8)
---------------------------------------------------------------

Desarrollado por:
Naomi Fujita Salinas

Objetivo del ejercicio
----------------------
Desarrollar una aplicación web en ASP.NET MVC que permita gestionar diferentes tipos de entidades
(películas, libros, revistas) de forma dinámica, simulando una base de datos en memoria,
y aplicando principios de diseño SOLID.

Funcionalidades implementadas
-----------------------------
1. Selección dinámica de entidad desde un desplegable (ComboBox).
2. Visualización de objetos en tabla según entidad seleccionada.
3. Filtro por texto en tiempo real (título).
4. Creación de objetos con formulario (título personalizado).
5. Eliminación de objetos desde la tabla.
6. Registro en memoria de todas las operaciones CRUD.
7. Navegación fluida entre vistas.
8. Enfoque automático en el campo de texto en la vista "Crear".
9. Diseño responsive con Bootstrap.

Estructura del proyecto
-----------------------
/EjercicioWeb/
├── Controllers/
│   └── EntidadesController.cs
├── Modelo/
│   ├── DAO/
│   │   └── GenericDAO.cs
│   ├── Entidades/
│   │   ├── IEntidad.cs
│   │   ├── libro.cs
│   │   ├── pelicula.cs
│   │   └── revista.cs
│   └── Servicios/
│       ├── ServicioLibros.cs
│       ├── ServicioPeliculas.cs
│       └── ServicioRevistas.cs
├── Views/
│   ├── Entidades/
│   │   ├── Index.cshtml
│   │   └── Crear.cshtml
│   └── Shared/
│       └── _Layout.cshtml
└── App_Start/
    └── RouteConfig.cs

Principios SOLID aplicados
--------------------------
- **S**: Separación clara de responsabilidades: UI, lógica, acceso a datos.
- **O**: Fácil extensión: añadir nuevas entidades sin modificar lógica base.
- **L**: Todas las entidades implementan `IEntidad`, garantizando intercambiabilidad.
- **I**: Interfaz específica y enfocada (`id` y `titulo`).
- **D**: Dependencias internas desacopladas por reflexión y estructuras genéricas.

Cómo ejecutar
-------------
1. Abrir la solución en Visual Studio 2022.
2. Ejecutar el proyecto `EjercicioWeb`.
3. Se abrirá directamente en la página de listado (`Index`) con opción de crear, filtrar y eliminar.
4. Todo funciona en memoria, sin necesidad de base de datos externa.

Notas
-----
- Títulos se introducen manualmente desde el formulario "Crear".
- El campo de título tiene el foco automáticamente al cargar la vista.
- El informe de operaciones puede verse desde un botón en la lista.
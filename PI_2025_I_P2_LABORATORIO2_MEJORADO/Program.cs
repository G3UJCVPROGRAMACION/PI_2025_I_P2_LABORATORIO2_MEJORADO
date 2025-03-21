using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos;
using static System.Console;
namespace PI_2025_I_P2_LABORATORIO2_MEJORADO
{
    internal class Program
    {
        static List<Libro> libros = new List<Libro>();
        static List<Autor> autores = new List<Autor>();
        static List<Editorial> editoriales = new List<Editorial>();
        static List<GeneroLiterario> generos = new List<GeneroLiterario>();
        static List<Usuario> usuarios = new List<Usuario>();
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1. Agregar Libro");
                    Console.WriteLine("2. Buscar Libro");
                    Console.WriteLine("3. Listar Libros");
                    Console.WriteLine("4. Prestar Libro");
                    Console.WriteLine("5. Devolver Libro");
                    Console.WriteLine("6. Agregar Usuario");
                    Console.WriteLine("7. Salir");
                    Console.Write("Seleccione una opción: ");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            AgregarLibro();
                            break;
                        case "2":
                            BuscarLibro();
                            break;
                        case "3":
                            ListarLibros();
                            break;
                        case "4":
                            PrestarLibro();
                            break;
                        case "5":
                            DevolverLibro();
                            break;
                        case "6":
                            AgregarUsuario();
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (EntradaNoValidaException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void AgregarLibro()
        {
            Console.Write("Título (1-50 caracteres): ");
            string titulo = Validaciones.ValidarEntradaTexto(1, 50, "Título (1-50 caracteres): ");

            Console.Write("ISBN (10-13 caracteres): ");
            string isbn = Validaciones.ValidarEntradaTexto(10, 13, "ISBN (10-13 caracteres): ");

            if (!Validaciones.ValidarLibroUnico(libros, titulo, isbn))
            {
                throw new EntradaNoValidaException("El libro ya existe (título o ISBN duplicado).");
            }

            Console.Write("Año de Publicación (hasta {0}): ", DateTime.Now.Year);
            int añoPublicacion = Validaciones.ValidarEntero(1000, DateTime.Now.Year, $"Año de Publicación (hasta {DateTime.Now.Year}): ");

            Console.Write("Cantidad de Ejemplares: ");
            int cantidadEjemplares = Validaciones.ValidarEntero(1, int.MaxValue, "Cantidad de Ejemplares: ");

            Console.Write("Nombre del Autor (1-50 caracteres): ");
            string nombreAutor = Validaciones.ValidarEntradaTexto(1, 50, "Nombre del Autor (1-50 caracteres): ");
            Console.Write("Apellido del Autor (1-50 caracteres): ");
            string apellidoAutor = Validaciones.ValidarEntradaTexto(1, 50, "Apellido del Autor (1-50 caracteres): ");
            Autor autor = autores.FirstOrDefault(a => a.Nombre == nombreAutor && a.Apellido == apellidoAutor);
            if (autor == null)
            {
                Console.Write("Nacionalidad del Autor (1-50 caracteres): ");
                string nacionalidad = Validaciones.ValidarEntradaTexto(1, 50, "Nacionalidad del Autor (1-50 caracteres): ");

                Console.Write("Año de Nacimiento del Autor (hasta {0}): ", DateTime.Now.Year);
                int añoNacimiento = Validaciones.ValidarEntero(1000, DateTime.Now.Year, $"Año de Nacimiento del Autor (hasta {DateTime.Now.Year}): ");

                Console.Write("Cantidad de Libros Publicados: ");
                int cantidadLibrosPublicados = Validaciones.ValidarEntero(0, int.MaxValue, "Cantidad de Libros Publicados: ");

                autor = new Autor(nombreAutor, apellidoAutor, nacionalidad, añoNacimiento, cantidadLibrosPublicados);
                autores.Add(autor);
            }

            Console.Write("Nombre de la Editorial (1-50 caracteres): ");
            string nombreEditorial = Validaciones.ValidarEntradaTexto(1, 50, "Nombre de la Editorial (1-50 caracteres): ");
            Editorial editorial = editoriales.FirstOrDefault(e => e.Nombre == nombreEditorial);
            if (editorial == null)
            {
                Console.Write("País de la Editorial (1-50 caracteres): ");
                string pais = Validaciones.ValidarEntradaTexto(1, 50, "País de la Editorial (1-50 caracteres): ");

                Console.Write("Dirección de la Editorial (1-100 caracteres): ");
                string direccion = Validaciones.ValidarEntradaTexto(1, 100, "Dirección de la Editorial (1-100 caracteres): ");

                Console.Write("Teléfono de la Editorial (solo números): ");
                string telefono = Validaciones.ValidarTelefono("Teléfono de la Editorial (solo números): ");

                Console.Write("Correo Electrónico de la Editorial (debe contener @): ");
                string correoElectronico = Validaciones.ValidarCorreoElectronico("Correo Electrónico de la Editorial (debe contener @): ");

                editorial = new Editorial(nombreEditorial, pais, direccion, telefono, correoElectronico);
                editoriales.Add(editorial);
            }

            Console.Write("Nombre del Género Literario (1-50 caracteres): ");
            string nombreGenero = Validaciones.ValidarEntradaTexto(1, 50, "Nombre del Género Literario (1-50 caracteres): ");
            GeneroLiterario genero = generos.FirstOrDefault(g => g.Nombre == nombreGenero);
            if (genero == null)
            {
                Console.Write("Tema del Género Literario (1-50 caracteres): ");
                string tema = Validaciones.ValidarEntradaTexto(1, 50, "Tema del Género Literario (1-50 caracteres): ");

                genero = new GeneroLiterario(nombreGenero, tema);
                generos.Add(genero);
            }

            libros.Add(new Libro(titulo, autor, editorial, genero, isbn, añoPublicacion, cantidadEjemplares));
            Console.WriteLine("Libro agregado correctamente.");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void BuscarLibro()
        {
            Console.Write("Ingrese el título del libro a buscar: ");
            string titulo = Console.ReadLine();
            var libro = libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libro != null)
            {
                libro.MostrarInformacion();
            }
            else
            {
                throw new EntradaNoValidaException("Libro no encontrado.");
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ListarLibros()
        {
            if (libros.Count == 0)
            {
                throw new EntradaNoValidaException("No hay libros registrados.");
            }

            foreach (var libro in libros)
            {
                libro.MostrarInformacion();
                Console.WriteLine();
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void PrestarLibro()
        {
            Console.Write("Ingrese el título del libro a prestar: ");
            string titulo = Console.ReadLine();
            var libro = libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libro == null)
            {
                throw new EntradaNoValidaException("Libro no encontrado.");
            }

            Console.Write("Ingrese el nombre del usuario: ");
            string nombreUsuario = Console.ReadLine();
            Console.Write("Ingrese el apellido del usuario: ");
            string apellidoUsuario = Console.ReadLine();
            var usuario = usuarios.FirstOrDefault(u => u.Nombre.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) && u.Apellido.Equals(apellidoUsuario, StringComparison.OrdinalIgnoreCase));
            if (usuario == null)
            {
                throw new EntradaNoValidaException("Usuario no encontrado.");
            }

            usuario.PrestarLibro(libro);
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void DevolverLibro()
        {
            Console.Write("Ingrese el título del libro a devolver: ");
            string titulo = Console.ReadLine();
            var libro = libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libro == null)
            {
                throw new EntradaNoValidaException("Libro no encontrado.");
            }

            Console.Write("Ingrese el nombre del usuario: ");
            string nombreUsuario = Console.ReadLine();
            Console.Write("Ingrese el apellido del usuario: ");
            string apellidoUsuario = Console.ReadLine();
            var usuario = usuarios.FirstOrDefault(u => u.Nombre.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) && u.Apellido.Equals(apellidoUsuario, StringComparison.OrdinalIgnoreCase));
            if (usuario == null)
            {
                throw new EntradaNoValidaException("Usuario no encontrado.");
            }

            usuario.DevolverLibro(libro);
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void AgregarUsuario()
        {
            Console.Write("Nombre del usuario (1-50 caracteres): ");
            string nombre = Validaciones.ValidarEntradaTexto(1, 50, "Nombre del usuario (1-50 caracteres): ");

            Console.Write("Apellido del usuario (1-50 caracteres): ");
            string apellido = Validaciones.ValidarEntradaTexto(1, 50, "Apellido del usuario (1-50 caracteres): ");

            Console.Write("Identificación del usuario (1-20 caracteres): ");
            string identificacion = Validaciones.ValidarEntradaTexto(1, 20, "Identificación del usuario (1-20 caracteres): ");

            if (!Validaciones.ValidarUsuarioUnico(usuarios, identificacion))
            {
                throw new EntradaNoValidaException("El usuario ya existe (identificación duplicada).");
            }

            Console.Write("Correo electrónico del usuario (debe contener @): ");
            string correo = Validaciones.ValidarCorreoElectronico("Correo electrónico del usuario (debe contener @): ");

            Console.Write("Teléfono del usuario (solo números): ");
            string telefono = Validaciones.ValidarTelefono("Teléfono del usuario (solo números): ");

            Console.Write("¿Es un profesor o un estudiante? (P/E): ");
            string tipoUsuario = Console.ReadLine().ToUpper();

            if (tipoUsuario == "P")
            {
                Console.Write("Departamento del profesor (1-50 caracteres): ");
                string departamento = Validaciones.ValidarEntradaTexto(1, 50, "Departamento del profesor (1-50 caracteres): ");

                Profesor profesor = new Profesor(nombre, apellido, identificacion, correo, telefono, departamento);
                usuarios.Add(profesor);
                Console.WriteLine("Profesor agregado correctamente.");
            }
            else if (tipoUsuario == "E")
            {
                Console.Write("Carrera del estudiante (1-50 caracteres): ");
                string carrera = Validaciones.ValidarEntradaTexto(1, 50, "Carrera del estudiante (1-50 caracteres): ");

                Estudiante estudiante = new Estudiante(nombre, apellido, identificacion, correo, telefono, carrera);
                usuarios.Add(estudiante);
                Console.WriteLine("Estudiante agregado correctamente.");
            }
            else
            {
                throw new EntradaNoValidaException("Opción no válida. Debe ser 'P' para profesor o 'E' para estudiante.");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}






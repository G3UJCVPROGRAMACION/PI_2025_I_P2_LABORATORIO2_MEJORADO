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
                    WriteLine("Bienvenido al inventario de la Biblioteca UJCV");
                    WriteLine("Menú de opciones");
                    WriteLine("1. Agregar Libro");
                    WriteLine("2. Buscar Libro");
                    WriteLine("3. Listar Libros");
                    WriteLine("4. Prestar Libro");
                    WriteLine("5. Devolver Libro");
                    WriteLine("6. Agregar Usuario");
                    WriteLine("7. Salir");
                    Write("Seleccione una opción: ");
                    string opcion = ReadLine();

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
                            WriteLine("Opción no válida. Ingrese un numero entre 1 y 7");
                            break;
                    }
                }
                catch (EntradaNoValidaException ex)
                {
                    WriteLine($"Error: {ex.Message}");
                    WriteLine("\nPresione cualquier tecla para continuar..."); 
                    ReadKey();
                    Clear();
                }
                catch (Exception ex)
                {
                    WriteLine($"Error inesperado: {ex.Message}");
                    WriteLine("\nPresione cualquier tecla para continuar..."); 
                    ReadKey();
                    Clear();
                }
            }
        }

        static void AgregarLibro()
        {
            Write("Título (1-50 caracteres): ");
            string titulo = ValidarEntradaTexto(1, 50);

            Write("ISBN (10-13 caracteres): ");
            string isbn = ValidarEntradaTexto(10, 13);

            Write("Año de Publicación (hasta {0}): ", DateTime.Now.Year);
            int añoPublicacion = ValidarEntero(1000, DateTime.Now.Year);

            Write("Cantidad de Ejemplares: ");
            int cantidadEjemplares = ValidarEntero(1, int.MaxValue);

            Write("Nombre del Autor (1-50 caracteres): ");
            string nombreAutor = ValidarEntradaTexto(1, 50);
            Write("Apellido del Autor (1-50 caracteres): ");
            string apellidoAutor = ValidarEntradaTexto(1, 50);
            Autor autor = autores.FirstOrDefault(a => a.Nombre == nombreAutor && a.Apellido == apellidoAutor);
            if (autor == null)
            {
                Write("Nacionalidad del Autor (1-50 caracteres): ");
                string nacionalidad = ValidarEntradaTexto(1, 50);

                Write("Año de Nacimiento del Autor (hasta {0}): ", DateTime.Now.Year);
                int añoNacimiento = ValidarEntero(1000, DateTime.Now.Year);

                Write("Cantidad de Libros Publicados: ");
                int cantidadLibrosPublicados = ValidarEntero(0, int.MaxValue);

                autor = new Autor(nombreAutor, apellidoAutor, nacionalidad, añoNacimiento, cantidadLibrosPublicados);
                autores.Add(autor);
            }

            Write("Nombre de la Editorial (1-50 caracteres): ");
            string nombreEditorial = ValidarEntradaTexto(1, 50);
            Editorial editorial = editoriales.FirstOrDefault(e => e.Nombre == nombreEditorial);
            if (editorial == null)
            {
                Write("País de la Editorial (1-50 caracteres): ");
                string pais = ValidarEntradaTexto(1, 50);

                Write("Dirección de la Editorial (1-100 caracteres): ");
                string direccion = ValidarEntradaTexto(1, 100);

                Write("Teléfono de la Editorial (solo números): ");
                string telefono = ValidarTelefono();

                Write("Correo Electrónico de la Editorial (debe contener @): ");
                string correoElectronico = ValidarCorreoElectronico();

                editorial = new Editorial(nombreEditorial, pais, direccion, telefono, correoElectronico);
                editoriales.Add(editorial);
            }

            Write("Nombre del Género Literario (1-50 caracteres): ");
            string nombreGenero = ValidarEntradaTexto(1, 50);
            GeneroLiterario genero = generos.FirstOrDefault(g => g.Nombre == nombreGenero);
            if (genero == null)
            {
                Write("Tema del Género Literario (1-50 caracteres): ");
                string tema = ValidarEntradaTexto(1, 50);

                genero = new GeneroLiterario(nombreGenero, tema);
                generos.Add(genero);
            }

            libros.Add(new Libro(titulo, autor, editorial, genero, isbn, añoPublicacion, cantidadEjemplares));
            WriteLine("Libro agregado correctamente.");
            WriteLine("\nPresione cualquier tecla para continuar..."); 
            ReadKey();
            Clear();
        }

        static void BuscarLibro()
        {
            Write("Ingrese el título del libro a buscar: ");
            string titulo = ReadLine();
            var libro = libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libro != null)
            {
                libro.MostrarInformacion();
            }
            else
            {
                throw new EntradaNoValidaException("Libro no encontrado.");
            }
            WriteLine("\nPresione cualquier tecla para continuar..."); 
            ReadKey();
            Clear();
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
                WriteLine();
            }
            WriteLine("\nPresione cualquier tecla para continuar..."); 
            ReadKey();
            Clear();
        }

        static void PrestarLibro()
        {
            Write("Ingrese el título del libro a prestar: ");
            string titulo = ReadLine();
            var libro = libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libro == null)
            {
                throw new EntradaNoValidaException("Libro no encontrado.");
            }

            Write("Ingrese el nombre del usuario: ");
            string nombreUsuario = ReadLine();
            Write("Ingrese el apellido del usuario: ");
            string apellidoUsuario = ReadLine();
            var usuario = usuarios.FirstOrDefault(u => u.Nombre.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) && u.Apellido.Equals(apellidoUsuario, StringComparison.OrdinalIgnoreCase));
            if (usuario == null)
            {
                throw new EntradaNoValidaException("Usuario no encontrado.");
            }

            usuario.PrestarLibro(libro);
            WriteLine("\nPresione cualquier tecla para continuar..."); 
            ReadKey();
            Clear();
        }

        static void DevolverLibro()
        {
            Write("Ingrese el título del libro a devolver: ");
            string titulo = ReadLine();
            var libro = libros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
            if (libro == null)
            {
                throw new EntradaNoValidaException("Libro no encontrado.");
            }

            Write("Ingrese el nombre del usuario: ");
            string nombreUsuario = ReadLine();
            Write("Ingrese el apellido del usuario: ");
            string apellidoUsuario = ReadLine();
            var usuario = usuarios.FirstOrDefault(u => u.Nombre.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase) && u.Apellido.Equals(apellidoUsuario, StringComparison.OrdinalIgnoreCase));
            if (usuario == null)
            {
                throw new EntradaNoValidaException("Usuario no encontrado.");
            }

            usuario.DevolverLibro(libro);
            WriteLine("\nPresione cualquier tecla para continuar..."); 
            ReadKey();
            Clear();
        }

        static void AgregarUsuario()
        {
            Write("Nombre del usuario (1-50 caracteres): ");
            string nombre = ValidarEntradaTexto(1, 50);

            Write("Apellido del usuario (1-50 caracteres): ");
            string apellido = ValidarEntradaTexto(1, 50);

            Write("Identificación del usuario (1-20 caracteres): ");
            string identificacion = ValidarEntradaTexto(1, 20);

            Write("Correo electrónico del usuario (debe contener @): ");
            string correo = ValidarCorreoElectronico();

            Write("Teléfono del usuario (solo números): ");
            string telefono = ValidarTelefono();

            Write("¿Es un profesor o un estudiante? (P/E): ");
            string tipoUsuario = ReadLine().ToUpper();

            if (tipoUsuario == "P")
            {
                Write("Departamento del profesor (1-50 caracteres): ");
                string departamento = ValidarEntradaTexto(1, 50);

                Profesor profesor = new Profesor(nombre, apellido, identificacion, correo, telefono, departamento);
                usuarios.Add(profesor);
                WriteLine("Profesor agregado correctamente.");
            }
            else if (tipoUsuario == "E")
            {
                Write("Carrera del estudiante (1-50 caracteres): ");
                string carrera = ValidarEntradaTexto(1, 50);

                Estudiante estudiante = new Estudiante(nombre, apellido, identificacion, correo, telefono, carrera);
                usuarios.Add(estudiante);
                WriteLine("Estudiante agregado correctamente.");
            }
            else
            {
                throw new EntradaNoValidaException("Opción no válida. Debe ser 'P' para profesor o 'E' para estudiante.");
            }

               WriteLine("\nPresione cualquier tecla para continuar..."); 
            ReadKey();
            Clear();
        }

        static string ValidarEntradaTexto(int min, int max)
        {
            string entrada;
            while (true)
            {
                entrada = ReadLine();
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Write($"La entrada no puede estar vacía. Ingrese entre {min} y {max} caracteres: ");
                }
                else if (entrada.Length < min || entrada.Length > max)
                {
                    Write($"La entrada debe tener entre {min} y {max} caracteres: ");
                }
                else
                {
                    break;
                }
            }
            return entrada;
        }

        static int ValidarEntero(int min, int max)
        {
            int resultado;
            while (true)
            {
                string input = ReadLine();
                if (!int.TryParse(input, out resultado))
                {
                    Write("Entrada no válida. Ingrese un número: ");
                }
                else if (resultado < min || resultado > max)
                {
                    Write($"El número debe estar entre {min} y {max}: ");
                }
                else
                {
                    break;
                }
            }
            return resultado;
        }

        static string ValidarTelefono()
        {
            string telefono;
            while (true)
            {
                telefono = ReadLine();
                if (telefono.All(char.IsDigit))
                {
                    break;
                }
                else
                {
                     Write("El teléfono solo puede contener números. Intente nuevamente: ");
                }
            }
            return telefono;
        }

        static string ValidarCorreoElectronico()
        {
            string correo;
            while (true)
            {
                correo = ReadLine();
                if (correo.Contains("@"))
                {
                    break;
                }
                else
                {
                    Write("El correo electrónico debe contener el carácter '@'. Intente nuevamente: ");
                }
            }
            return correo;
        }
    }
}






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos
{
    internal class Validaciones
    {
        public static string ValidarEntradaTexto(int min, int max, string mensaje)
        {
            string entrada;
            while (true)
            {
                Console.Write(mensaje);
                entrada = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine($"La entrada no puede estar vacía. Ingrese entre {min} y {max} caracteres.");
                }
                else if (entrada.Length < min || entrada.Length > max)
                {
                    Console.WriteLine($"La entrada debe tener entre {min} y {max} caracteres.");
                }
                else
                {
                    break;
                }
            }
            return entrada;
        }

        public static int ValidarEntero(int min, int max, string mensaje)
        {
            int resultado;
            while (true)
            {
                Console.Write(mensaje);
                string input = Console.ReadLine();
                if (!int.TryParse(input, out resultado))
                {
                    Console.WriteLine("Entrada no válida. Ingrese un número.");
                }
                else if (resultado < min || resultado > max)
                {
                    Console.WriteLine($"El número debe estar entre {min} y {max}.");
                }
                else
                {
                    break;
                }
            }
            return resultado;
        }

        public static string ValidarTelefono(string mensaje)
        {
            string telefono;
            while (true)
            {
                Console.Write(mensaje);
                telefono = Console.ReadLine();
                if (telefono.All(char.IsDigit))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("El teléfono solo puede contener números. Intente nuevamente.");
                }
            }
            return telefono;
        }

        public static string ValidarCorreoElectronico(string mensaje)
        {
            string correo;
            while (true)
            {
                Console.Write(mensaje);
                correo = Console.ReadLine();
                if (correo.Contains("@"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("El correo electrónico debe contener el carácter '@'. Intente nuevamente.");
                }
            }
            return correo;
        }

        public static bool ValidarLibroUnico(List<Libro> libros, string titulo, string isbn)
        {
            return !libros.Any(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase) || l.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
        }

        public static bool ValidarUsuarioUnico(List<Usuario> usuarios, string identificacion)
        {
            return !usuarios.Any(u => u.Identificacion.Equals(identificacion, StringComparison.OrdinalIgnoreCase));
        }
    }
}

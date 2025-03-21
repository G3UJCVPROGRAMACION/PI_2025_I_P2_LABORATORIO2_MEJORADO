using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos
{
    internal class Usuario : IMostrarInformacion, IPrestable, IValidable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; } // Nueva propiedad
        public bool EsActivo { get; set; } // Nueva propiedad
        public List<Libro> LibrosPrestados { get; set; } = new List<Libro>();

        public Usuario(string nombre, string apellido, string identificacion, string correo, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Identificacion = identificacion;
            Correo = correo;
            Telefono = telefono;
            FechaRegistro = DateTime.Now;
            EsActivo = true;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre} {Apellido}, Identificación: {Identificacion}, Correo: {Correo}, Teléfono: {Telefono}");
            Console.WriteLine($"Fecha de Registro: {FechaRegistro.ToShortDateString()}, Estado: {(EsActivo ? "Activo" : "Inactivo")}");
        }

        public void PrestarLibro(Libro libro)
        {
            if (libro.EjemplaresDisponibles > 0)
            {
                LibrosPrestados.Add(libro);
                libro.EjemplaresDisponibles--;
                libro.PrestadoA.Add(this);
                Console.WriteLine($"Libro '{libro.Titulo}' prestado a {Nombre} {Apellido}.");
            }
            else
            {
                throw new EntradaNoValidaException($"No hay ejemplares disponibles del libro '{libro.Titulo}'.");
            }
        }

        public void DevolverLibro(Libro libro)
        {
            if (LibrosPrestados.Contains(libro))
            {
                LibrosPrestados.Remove(libro);
                libro.EjemplaresDisponibles++;
                libro.PrestadoA.Remove(this);
                Console.WriteLine($"Libro '{libro.Titulo}' devuelto por {Nombre} {Apellido}.");
            }
            else
            {
                throw new EntradaNoValidaException($"El libro '{libro.Titulo}' no fue prestado a {Nombre} {Apellido}.");
            }
        }

        public bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
             !string.IsNullOrWhiteSpace(Apellido) &&
             !string.IsNullOrWhiteSpace(Identificacion) &&
             ValidarCorreoElectronico(Correo) && // Validar correo electrónico
             ValidarTelefono(Telefono); // Validar teléfono
        }
        private bool ValidarTelefono(string telefono)
        {
            return telefono.All(char.IsDigit); // Solo caracteres numéricos
        }

        private bool ValidarCorreoElectronico(string correo)
        {
            return correo.Contains("@"); // Debe contener el carácter @
        }
    }   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos
{
    internal class Libro : IMostrarInformacion, IValidable
    {
        public string Titulo { get; set; }
        public Autor AutorLibro { get; set; }
        public Editorial EditorialLibro { get; set; }
        public GeneroLiterario Genero { get; set; }
        public string ISBN { get; set; }
        public int AñoPublicacion { get; set; }
        public int CantidadEjemplares { get; set; } 
        public int EjemplaresDisponibles { get; set; } 
        public List<Usuario> PrestadoA { get; set; } = new List<Usuario>(); 
        public Libro(string titulo, Autor autorLibro, Editorial editorialLibro, GeneroLiterario genero, string isbn, int añoPublicacion, int cantidadEjemplares)
        {
            Titulo = titulo;
            AutorLibro = autorLibro;
            EditorialLibro = editorialLibro;
            Genero = genero;
            ISBN = isbn;
            AñoPublicacion = añoPublicacion;
            CantidadEjemplares = cantidadEjemplares;
            EjemplaresDisponibles = cantidadEjemplares; 
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Título: {Titulo}");
            AutorLibro.MostrarInformacion();
            EditorialLibro.MostrarInformacion();
            Genero.MostrarInformacion();
            Console.WriteLine($"ISBN: {ISBN}, Año de Publicación: {AñoPublicacion}, Ejemplares Disponibles: {EjemplaresDisponibles}/{CantidadEjemplares}");
            if (PrestadoA.Count > 0)
            {
                Console.WriteLine("Prestado a:");
                foreach (var usuario in PrestadoA)
                {
                    Console.WriteLine($"- {usuario.Nombre} {usuario.Apellido}");
                }
            }
        }

        public bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Titulo) &&
                   !string.IsNullOrWhiteSpace(ISBN) &&
                   AñoPublicacion > 0 &&
                   AutorLibro != null &&
                   EditorialLibro != null &&
                   Genero != null &&
                   CantidadEjemplares > 0; 
        }
    }    
}

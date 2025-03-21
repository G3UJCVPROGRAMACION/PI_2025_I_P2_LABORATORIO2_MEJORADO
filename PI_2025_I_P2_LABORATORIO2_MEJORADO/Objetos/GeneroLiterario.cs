using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos
{
    internal class GeneroLiterario : IMostrarInformacion, IValidable
    {
        public string Nombre { get; set; }
        public string Tema { get; set; }
        public string Subgenero { get; set; } // Nueva propiedad
        public bool EsPopular { get; set; } // Nueva propiedad
        public int AñoOrigen { get; set; } // Nueva propiedad
        public string Descripcion { get; set; } // Nueva propiedad
        public List<string> AutoresRepresentativos { get; set; } = new List<string>(); // Nueva propiedad

        public GeneroLiterario(string nombre, string tema, string subgenero = "", bool esPopular = false, int añoOrigen = 0, string descripcion = "")
        {
            Nombre = nombre;
            Tema = tema;
            Subgenero = subgenero;
            EsPopular = esPopular;
            AñoOrigen = añoOrigen;
            Descripcion = descripcion;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Género Literario: {Nombre}, Tema: {Tema}");
            Console.WriteLine($"Subgénero: {Subgenero}, Es Popular: {(EsPopular ? "Sí" : "No")}");
            Console.WriteLine($"Año de Origen: {AñoOrigen}, Descripción: {Descripcion}");
            if (AutoresRepresentativos.Count > 0)
            {
                Console.WriteLine("Autores Representativos:");
                foreach (var autor in AutoresRepresentativos)
                {
                    Console.WriteLine($"- {autor}");
                }
            }
        }

        public bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
                   !string.IsNullOrWhiteSpace(Tema);
        }

        // Nuevos métodos
        public void AgregarAutorRepresentativo(string autor)
        {
            AutoresRepresentativos.Add(autor);
            Console.WriteLine($"Autor representativo '{autor}' agregado.");
        }

        public bool EsGeneroAntiguo()
        {
            return (DateTime.Now.Year - AñoOrigen) > 100;
        }
    }
}

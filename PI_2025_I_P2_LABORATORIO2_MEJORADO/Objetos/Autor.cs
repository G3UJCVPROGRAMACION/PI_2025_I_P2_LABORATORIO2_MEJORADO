using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos
{
    internal class Autor : IMostrarInformacion, IValidable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacionalidad { get; set; }
        public int AñoNacimiento { get; set; }
        public int CantidadLibrosPublicados { get; set; }

        public Autor(string nombre, string apellido, string nacionalidad, int añoNacimiento, int cantidadLibrosPublicados)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
            AñoNacimiento = añoNacimiento;
            CantidadLibrosPublicados = cantidadLibrosPublicados;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Autor: {Nombre} {Apellido}, Nacionalidad: {Nacionalidad}, Año de Nacimiento: {AñoNacimiento}, Libros Publicados: {CantidadLibrosPublicados}");
        }

        public bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
                   !string.IsNullOrWhiteSpace(Apellido) &&
                   !string.IsNullOrWhiteSpace(Nacionalidad) &&
                   AñoNacimiento > 0 &&
                   CantidadLibrosPublicados >= 0;
        }
    }
}

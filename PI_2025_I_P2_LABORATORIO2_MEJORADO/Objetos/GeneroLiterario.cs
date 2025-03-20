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

        public GeneroLiterario(string nombre, string tema)
        {
            Nombre = nombre;
            Tema = tema;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Género Literario: {Nombre}, Tema: {Tema}");
        }

        public bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
                   !string.IsNullOrWhiteSpace(Tema);
        }
    }
}

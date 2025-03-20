using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos
{
    internal class Estudiante : Usuario
    {
        public string Carrera { get; set; }

        public Estudiante(string nombre, string apellido, string identificacion, string correo, string telefono, string carrera)
            : base(nombre, apellido, identificacion, correo, telefono)
        {
            Carrera = carrera;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Carrera: {Carrera}");
        }
    }
}
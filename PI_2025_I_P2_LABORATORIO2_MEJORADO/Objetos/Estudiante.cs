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
        public int Semestre { get; set; } // Nueva propiedad
        public double PromedioCalificaciones { get; set; } // Nueva propiedad

        public Estudiante(string nombre, string apellido, string identificacion, string correo, string telefono, string carrera, int semestre = 1, double promedioCalificaciones = 0.0)
            : base(nombre, apellido, identificacion, correo, telefono)
        {
            Carrera = carrera;
            Semestre = semestre;
            PromedioCalificaciones = promedioCalificaciones;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Carrera: {Carrera}, Semestre: {Semestre}, Promedio: {PromedioCalificaciones}");
        }

        // Nuevos métodos
        public void ActualizarSemestre(int nuevoSemestre)
        {
            Semestre = nuevoSemestre;
            Console.WriteLine($"Semestre actualizado a: {Semestre}");
        }

        public void ActualizarPromedio(double nuevoPromedio)
        {
            PromedioCalificaciones = nuevoPromedio;
            Console.WriteLine($"Promedio actualizado a: {PromedioCalificaciones}");
        }

        public bool EsBecado()
        {
            return PromedioCalificaciones >= 9.0;
        }
    }
}
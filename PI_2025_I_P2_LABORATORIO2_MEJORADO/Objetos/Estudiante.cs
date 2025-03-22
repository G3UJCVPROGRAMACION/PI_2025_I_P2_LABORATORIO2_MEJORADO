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
        public int Semestre { get; set; } 
        public double PromedioCalificaciones { get; set; } 
        public int Edad { get; set; }
        public string EstadoCivil { get; set; }

        public Estudiante(string nombre, string apellido, string identificacion, string correo, string telefono, string carrera, int semestre = 1, double promedioCalificaciones = 0.0, int edad = 0, string estadoCivil = "")
            : base(nombre, apellido, identificacion, correo, telefono)
        {
            Carrera = carrera;
            Semestre = semestre;
            PromedioCalificaciones = promedioCalificaciones;
            Edad = edad;
            EstadoCivil = estadoCivil;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Carrera: {Carrera}, Semestre: {Semestre}, Promedio: {PromedioCalificaciones}");
        }

        
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
            return PromedioCalificaciones >= 90;
        }
    }
}
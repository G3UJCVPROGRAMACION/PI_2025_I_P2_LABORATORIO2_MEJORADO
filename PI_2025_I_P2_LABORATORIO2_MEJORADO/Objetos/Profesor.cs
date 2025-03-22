using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos
{
    internal class Profesor : Usuario
    {
        public string Departamento { get; set; }
        public int AñosExperiencia { get; set; } 
        public string EsTitular { get; set; } 

        public Profesor(string nombre, string apellido, string identificacion, string correo, string telefono, string departamento, int añosExperiencia = 0, string esTitular = "")
            : base(nombre, apellido, identificacion, correo, telefono)
        {
            Departamento = departamento;
            AñosExperiencia = añosExperiencia;
            EsTitular = esTitular;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Departamento: {Departamento}, Años de Experiencia: {AñosExperiencia}");
        }

        
        public void AumentarExperiencia(int años)
        {
            AñosExperiencia += años;
            Console.WriteLine($"Años de experiencia actualizados a: {AñosExperiencia}");
        }

        public void CambiarTitularidad(string esTitular)
        {
            EsTitular = esTitular;
            Console.WriteLine($"Titularidad actualizada a: {EsTitular}");
        }

        public bool EsProfesorSenior()
        {
            return AñosExperiencia >= 10;
        }
    }
}

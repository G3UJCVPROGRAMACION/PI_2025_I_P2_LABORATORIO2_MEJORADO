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

        public Profesor(string nombre, string apellido, string identificacion, string correo, string telefono, string departamento)
            : base(nombre, apellido, identificacion, correo, telefono)
        {
            Departamento = departamento;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Departamento: {Departamento}");
        }
    }
}

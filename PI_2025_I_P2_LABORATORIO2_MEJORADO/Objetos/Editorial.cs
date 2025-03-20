using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos
{
    internal class Editorial : IMostrarInformacion, IValidable
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public Editorial(string nombre, string pais, string direccion, string telefono, string correoElectronico)
        {
            Nombre = nombre;
            Pais = pais;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Editorial: {Nombre}, País: {Pais}, Dirección: {Direccion}, Teléfono: {Telefono}, Correo Electrónico: {CorreoElectronico}");
        }

        public bool Validar()
        {
            return !string.IsNullOrWhiteSpace(Nombre) &&
                   !string.IsNullOrWhiteSpace(Pais) &&
                   !string.IsNullOrWhiteSpace(Direccion) &&
                   ValidarTelefono(Telefono) && 
                   ValidarCorreoElectronico(CorreoElectronico); 
        }

        private bool ValidarTelefono(string telefono)
        {
            return telefono.All(char.IsDigit); 
        }

        private bool ValidarCorreoElectronico(string correo)
        {
            return correo.Contains("@"); 
        }
    }
       
}

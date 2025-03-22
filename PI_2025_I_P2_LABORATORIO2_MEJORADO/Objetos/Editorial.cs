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
        public int AñoFundacion { get; set; } 
        public string EsIndependiente { get; set; } 

        public Editorial(string nombre, string pais, string direccion, string telefono, string correoElectronico, int añoFundacion = 0, string esIndependiente = "")
        {
            Nombre = nombre;
            Pais = pais;
            Direccion = direccion;
            Telefono = telefono;
            CorreoElectronico = correoElectronico;
            AñoFundacion = añoFundacion;
            EsIndependiente = esIndependiente;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Editorial: {Nombre}, País: {Pais}, Dirección: {Direccion}, Teléfono: {Telefono}, Correo Electrónico: {CorreoElectronico}");
            Console.WriteLine($"Año de Fundación: {AñoFundacion},");
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


        
        public int CalcularAntiguedad()
        {
            return DateTime.Now.Year - AñoFundacion;
        }

        public void CambiarEstadoIndependiente(string nuevoEstado)
        {
            EsIndependiente = nuevoEstado;
            Console.WriteLine($"Estado de independencia actualizado a: {EsIndependiente}");
        }

        public string ObtenerInformacionContacto()
        {
            return $"Teléfono: {Telefono}, Correo: {CorreoElectronico}";
        }
    }
       
}

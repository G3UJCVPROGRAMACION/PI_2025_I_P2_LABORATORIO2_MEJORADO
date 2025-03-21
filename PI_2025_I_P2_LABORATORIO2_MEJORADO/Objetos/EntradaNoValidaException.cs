using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_2025_I_P2_LABORATORIO2_MEJORADO.Objetos
{
    internal class EntradaNoValidaException : Exception
    {
        public EntradaNoValidaException(string mensaje) : base(mensaje) { }
    }

    // Interfaz para mostrar información
    interface IMostrarInformacion
    {
        void MostrarInformacion();
    }

    // Interfaz para prestar y devolver libros
    interface IPrestable
    {
        void PrestarLibro(Libro libro);
        void DevolverLibro(Libro libro);
    }

    // Interfaz para validar datos
    interface IValidable
    {
        bool Validar();
    }
}

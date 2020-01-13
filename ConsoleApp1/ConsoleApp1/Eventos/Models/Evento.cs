using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Models
{
    public class Evento
    {
        string nombre;
        DateTime fecha;

        public Evento(string nombre, DateTime fecha)
        {
            this.nombre = nombre;
            this.fecha = fecha;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }
    }
}

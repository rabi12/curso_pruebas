using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Eventos.Models;

namespace ConsoleApp1.Eventos.Services
{
    class DatosParseEventosService : IDatosParseEventosService
    {
        private IValidadorArchivoEventosService validador;

        public DatosParseEventosService(IValidadorArchivoEventosService validador)
        {
            this.validador = validador;
        }

        public List<Evento> datosToEventos(List<string[]> datos)
        {
            List<Evento> eventos = new List<Evento>();
            if (!validador.validarPlantillaEventos(datos))
            {
                throw new Exception("El archivo tiene formato incorrecto");
            }
            else
            {
               foreach(var dato in datos)
                {
                    try { 
                        Evento newEvento = new Evento(dato[0], DateTime.Parse(dato[1]));
                        eventos.Add(newEvento);
                    }
                    catch(Exception e)
                    {
                        throw new Exception("El evento "+ dato[0] +" tiene fecha con formato incorrecto.");
                    }
                }
            }
            return eventos;
        }
    }
}

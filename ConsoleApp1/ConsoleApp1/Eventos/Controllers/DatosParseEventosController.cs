using ConsoleApp1.Eventos.Models;
using ConsoleApp1.Eventos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Controllers
{
    class DatosParseEventosController
    {
        IDatosParseEventosService datosParseEventosService;

        public DatosParseEventosController(IDatosParseEventosService datosParseEventosService)
        {
            this.datosParseEventosService = datosParseEventosService;
        }

        public List<Evento> datosToEventos(List<string[]> datos)
        {
            return datosParseEventosService.datosToEventos(datos);
        }

    }
}

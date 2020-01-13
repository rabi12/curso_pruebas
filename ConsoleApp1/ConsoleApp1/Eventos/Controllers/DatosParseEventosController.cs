using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Eventos.Models;
using ConsoleApp1.Eventos.Services;

namespace ConsoleApp1.Eventos.Controllers
{
    public class DatosParseEventosController : IDatosParseEventosController
    {
        IDatosParseEventosService datosParseEventosService;

        public DatosParseEventosController(IDatosParseEventosService datosParseEventosService)
        {
            this.datosParseEventosService = datosParseEventosService;
        }

        public List<Evento> obtieneEventosArchivo(List<string[]> datos)
        {
            return datosParseEventosService.datosToEventos(datos);
        }
    }
}

using ConsoleApp1.Eventos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Services
{
    public interface IDatosParseEventosService
    {
         List<Evento> datosToEventos(List<string[]> datos);
    }
}

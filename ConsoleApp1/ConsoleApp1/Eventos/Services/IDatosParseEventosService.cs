using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Services
{
    interface IDatosParseEventosService
    {
        List<Models.Evento> datosToEventos(List<string[]> datos);
    }
}

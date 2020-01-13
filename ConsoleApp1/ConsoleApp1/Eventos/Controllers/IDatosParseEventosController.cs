using ConsoleApp1.Eventos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Controllers
{
    public interface IDatosParseEventosController
    {
        List<Evento> obtieneEventosArchivo(List<string[]> datos);
    }
}

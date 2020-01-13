using ConsoleApp1.Eventos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Controllers
{
    public interface IEventoController
    {
          Func<DateTime> proveedorFecha { get; set; }

          List<string> obtenerMensajesEventos(List<Evento> eventos);
    }
}

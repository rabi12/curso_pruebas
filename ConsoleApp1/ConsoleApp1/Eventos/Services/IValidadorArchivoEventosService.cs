using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Services
{
    interface IValidadorArchivoEventosService
    {
         bool validarPlantillaEventos(List<string []> datos);
    }
}

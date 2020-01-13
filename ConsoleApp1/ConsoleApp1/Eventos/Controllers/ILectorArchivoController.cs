using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Controllers
{
    public interface ILectorArchivoController
    {
        List<string[]> obtenerDatosArchivo(string ruta);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Services
{
    interface ILectorArchivoService
    {
         List<string[]> leerArchivo(string ruta);
    }
}

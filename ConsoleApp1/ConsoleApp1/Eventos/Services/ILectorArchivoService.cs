using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Services
{
    public interface ILectorArchivoService
    {
         List<string[]> leerArchivo(string ruta);
    }
}

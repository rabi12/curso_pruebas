using ConsoleApp1.Eventos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Controllers
{
    class LectorArchivoController
    {
        ILectorArchivoService lectorArchivoService;

        public LectorArchivoController(ILectorArchivoService lectorArchivoService)
        {
            this.lectorArchivoService = lectorArchivoService;
        }

        public List<string []> leerArchivo(string ruta)
        {
            return lectorArchivoService.leerArchivo(ruta);
        }
    }
}

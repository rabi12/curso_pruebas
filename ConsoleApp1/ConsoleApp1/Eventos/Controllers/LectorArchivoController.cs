using ConsoleApp1.Eventos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Controllers
{
    public class LectorArchivoController : ILectorArchivoController
    {
        ILectorArchivoService lectorArchivoService;

        public LectorArchivoController(ILectorArchivoService lectorArchivoService)
        {
            this.lectorArchivoService = lectorArchivoService;
        }

        public List<string[]> obtenerDatosArchivo(string ruta)
        {
            List<string[]> datos = null;
            try
            {
                datos = lectorArchivoService.leerArchivo(ruta);
            }
            catch (Exception)
            {
                throw new Exception("No existe el archivo en la ruta especificada");
            }

            return datos;
        }
    }
}

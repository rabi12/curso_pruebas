using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1.Eventos.Services
{
    public class ValidadorArchivoEventosService : IValidadorArchivoEventosService
    {
        public bool validarPlantillaEventos(List<string[]> datos)
        {
            if (datos == null)
                throw new Exception("El archivo no tiene el formato correcto o esta vacío");

            foreach(var dato in datos)
            {
                if (dato.Length != 2 || string.IsNullOrEmpty(dato[0]) || string.IsNullOrEmpty(dato[1]))
                    return false;
            }

            return true;
        }
    }
}

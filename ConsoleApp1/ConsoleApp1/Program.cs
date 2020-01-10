using ConsoleApp1.Eventos.Views;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
   
    class Program
    {
        static void Main(string[] args)
        {
            VistaEventos vista = new VistaEventos();
            vista.init();

            string ruta = vista.solicitaRuta();

            vista.muestraEventosRuta(ruta);
    
            Console.ReadKey();
        }

    }

}

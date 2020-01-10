using ConsoleApp1.Eventos.Controllers;
using ConsoleApp1.Eventos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Views
{
    class VistaEventos
    {
        EventoController eventoController;

        public void init()
        {
            ILectorArchivoService lectorArchivoService = new LectorArchivoService();
            IValidadorArchivoEventosService validadorArchivoEventosService = new ValidadorArchivoEventosService();
            IDatosParseEventosService datosParseEventosService= new DatosParseEventosService(validadorArchivoEventosService);
            ICalculadorDiferenciaFechasEnMeses calculadorMeses = new CalculadorDiferenciaFechasEnMeses() ;
            ICalculadorDiferenciaFechasEnDias calculadorDias = new CalculadorDiferenciaFechasEnDias();
            ICalculadorDiferenciaFechasEnHoras calculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            ICalculadorDiferenciaFechasEnMinutos calculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();

            eventoController = new EventoController(lectorArchivoService, datosParseEventosService, calculadorMeses, calculadorDias, calculadorHoras, calculadorMinutos);

        }

        public string solicitaRuta()
        {
            Console.WriteLine("Introduce la ruta completa del archivo");
            string ruta = Convert.ToString(Console.ReadLine());

            return ruta;
        }

        public void muestraEventosRuta(string ruta)
        {
            List<string> avisos=eventoController.getMensajesEventosArchivo(ruta);
            foreach(var aviso in avisos)
            {
                Console.WriteLine(aviso);
            }
        }

    }
}

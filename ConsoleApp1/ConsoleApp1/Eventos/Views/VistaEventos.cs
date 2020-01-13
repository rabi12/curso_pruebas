using ConsoleApp1.Eventos.Controllers;
using ConsoleApp1.Eventos.Models;
using ConsoleApp1.Eventos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Views
{
    class VistaEventos
    {
        ILectorArchivoController lectorArchivoController;
        IEventoController eventoController;
        IDatosParseEventosController datosParseEventosController;

        public void init()
        {
            ILectorArchivoService lectorArchivoService = new LectorArchivoService();
            IValidadorArchivoEventosService validadorArchivoEventosService = new ValidadorArchivoEventosService();
            IDatosParseEventosService datosParseEventosService= new DatosParseEventosService(validadorArchivoEventosService);
            ICalculadorDiferenciaFechasEnMeses calculadorMeses = new CalculadorDiferenciaFechasEnMeses() ;
            ICalculadorDiferenciaFechasEnDias calculadorDias = new CalculadorDiferenciaFechasEnDias();
            ICalculadorDiferenciaFechasEnHoras calculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            ICalculadorDiferenciaFechasEnMinutos calculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();

            lectorArchivoController = new LectorArchivoController(lectorArchivoService);
            datosParseEventosController = new DatosParseEventosController(datosParseEventosService);
            eventoController = new EventoController(calculadorMeses, calculadorDias, calculadorHoras, calculadorMinutos);

        }

        public string solicitaRuta()
        {
            Console.WriteLine("Introduce la ruta completa del archivo");
            string ruta = Convert.ToString(Console.ReadLine());

            return ruta;
        }

        public void muestraEventosRuta(string ruta)
        {
            List<string> avisos=getMensajesEventosArchivo(ruta);
            foreach(var aviso in avisos)
            {
                Console.WriteLine(aviso);
            }
        }

        private List<string> getMensajesEventosArchivo(string ruta)
        {
            try
            {
                List<string[]> datosArchivo = obtenerDatosArchivo(ruta);
                List<Evento> eventos = obtenerEventosDatosArchivo(datosArchivo);

                return obtenerMensajesEventos(eventos);
            }
            catch (Exception e)
            {
                List<string> listaMensaje = new List<string>();
                listaMensaje.Add(e.Message);
                return listaMensaje;
            }
        }

        private List<string []> obtenerDatosArchivo(string ruta)
        {
            return this.lectorArchivoController.obtenerDatosArchivo(ruta);
        }

        private List<Evento> obtenerEventosDatosArchivo(List<string[]> datosArchivo)
        {
            return this.datosParseEventosController.obtieneEventosArchivo(datosArchivo);
        }

        private List<string> obtenerMensajesEventos(List<Evento> eventos)
        {
            return this.eventoController.obtenerMensajesEventos(eventos);
        }
    }
}

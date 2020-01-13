using ConsoleApp1.Eventos.Models;
using ConsoleApp1.Eventos.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Controllers
{
    public class EventoController: IEventoController
    {
        ICalculadorDiferenciaFechasEnMeses calculadorMeses;
        ICalculadorDiferenciaFechasEnDias calculadorDias;
        ICalculadorDiferenciaFechasEnHoras calculadorHoras;
        ICalculadorDiferenciaFechasEnMinutos calculadorMinutos;

        public Func<DateTime> proveedorFecha { get; set; }

        public EventoController( 
            ICalculadorDiferenciaFechasEnMeses calculadorMeses, ICalculadorDiferenciaFechasEnDias calculadorDias, 
            ICalculadorDiferenciaFechasEnHoras calculadorHoras, ICalculadorDiferenciaFechasEnMinutos calculadorMinutos)
        {
            this.proveedorFecha = () => DateTime.Now;
            this.calculadorMeses = calculadorMeses;
            this.calculadorDias = calculadorDias;
            this.calculadorHoras= calculadorHoras;
            this.calculadorMinutos = calculadorMinutos;
        }

        public List<string> obtenerMensajesEventos(List<Evento> eventos)
        {
            List<string> listaAvisoEventos= new List<string>();

            foreach(var evento in eventos)
            {
                listaAvisoEventos.Add(obtenerMensajeEvento(evento, proveedorFecha()));
            }

            return listaAvisoEventos;
        }

        private string obtenerMensajeEvento(Evento evento, DateTime fechaActual)
        {
            int diferenciaTiempo = 0;
            string diferenciaRango = "Mes(es)";
            string cadena = evento.getNombre() + " " + evento.getFecha().ToString() + " ------>" + evento.getNombre() + " ";

            diferenciaTiempo = calcularDiferenciaEnMeses(fechaActual, evento.getFecha());
            if (diferenciaTiempo == 0)
            {
                diferenciaRango = "Dia(s)";
                diferenciaTiempo = calcularDiferenciaEnDias(fechaActual, evento.getFecha());
                if (diferenciaTiempo == 0)
                {
                    diferenciaRango = "Hora(s)";
                    diferenciaTiempo = calcularDiferenciaEnHoras(fechaActual, evento.getFecha());
                    if (diferenciaTiempo == 0)
                    {
                        diferenciaRango = "Minuto(s)";
                        diferenciaTiempo = calcularDiferenciaEnMinutos(fechaActual, evento.getFecha());
                    }
                }
            }

            if (diferenciaTiempo > 0)
            {
                cadena += " Ocurrirá dentro de " + diferenciaTiempo + " " + diferenciaRango;
            }
            else
                cadena += " Ocurrió hace " + Math.Abs(diferenciaTiempo) + " " + diferenciaRango;
            return cadena;
        }

        private int calcularDiferenciaEnMeses(DateTime fecha1, DateTime fecha2)
        {
            return this.calculadorMeses.calcularDiferencia(fecha1, fecha2);
        }

        private int calcularDiferenciaEnDias(DateTime fecha1, DateTime fecha2)
        {
            return this.calculadorDias.calcularDiferencia(fecha1, fecha2);
        }

        private int calcularDiferenciaEnHoras(DateTime fecha1, DateTime fecha2)
        {
            return this.calculadorHoras.calcularDiferencia(fecha1, fecha2);
        }

        private int calcularDiferenciaEnMinutos(DateTime fecha1, DateTime fecha2)
        {
            return this.calculadorMinutos.calcularDiferencia(fecha1, fecha2);
        }
    }
}

using ConsoleApp1.Eventos.Controllers;
using ConsoleApp1.Eventos.Models;
using ConsoleApp1.Eventos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Controllers
{
    [TestClass]
    public class EventoControllerUTest
    {
        [TestMethod]
        public void obtenerMensajesEventos_EventoMesPasado_MensajeCorrecto()
        {
            //Arrange
            List<Evento> eventos = new List<Evento>();
            Evento newEvento = new Evento("Evento mes pasado", new DateTime(2019, 11, 30));
            eventos.Add(newEvento);

            var DOCcalculadorMeses = new CalculadorDiferenciaFechasEnMeses();
            var DOCcalculadorDias = new CalculadorDiferenciaFechasEnDias();
            var DOCcalculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            var DOCcalculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();


            IEventoController SUT = new EventoController(DOCcalculadorMeses, DOCcalculadorDias, DOCcalculadorHoras, DOCcalculadorMinutos);
            SUT.proveedorFecha = () => new DateTime(2019, 12, 30);

            //Act
            var resultado = SUT.obtenerMensajesEventos(eventos);

            //Assert
            Assert.IsTrue(resultado[0].Contains("Ocurrió hace 1 Mes(es)"));
        }

        [TestMethod]
        public void obtenerMensajesEventos_EventoMesFuturo_MensajeCorrecto()
        {
            //Arrange
            List<Evento> eventos = new List<Evento>();
            Evento newEvento = new Evento("Evento proximo mes", new DateTime(2019, 11, 30));
            eventos.Add(newEvento);

            var DOCcalculadorMeses = new CalculadorDiferenciaFechasEnMeses();
            var DOCcalculadorDias = new CalculadorDiferenciaFechasEnDias();
            var DOCcalculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            var DOCcalculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();


            IEventoController SUT = new EventoController(DOCcalculadorMeses, DOCcalculadorDias, DOCcalculadorHoras, DOCcalculadorMinutos);
            SUT.proveedorFecha = () => new DateTime(2019, 10, 30);

            //Act
            var resultado = SUT.obtenerMensajesEventos(eventos);

            //Assert
            Assert.IsTrue(resultado[0].Contains("Ocurrirá dentro de 1 Mes(es)"));
        }

        [TestMethod]
        public void obtenerMensajesEventos_EventoDiaPasado_MensajeCorrecto()
        {
            //Arrange
            List<Evento> eventos = new List<Evento>();
            Evento newEvento = new Evento("Evento ayer", new DateTime(2019,11,30));
            eventos.Add(newEvento);

            var DOCcalculadorMeses = new CalculadorDiferenciaFechasEnMeses();
            var DOCcalculadorDias = new CalculadorDiferenciaFechasEnDias();
            var DOCcalculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            var DOCcalculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();


            IEventoController SUT = new EventoController(DOCcalculadorMeses, DOCcalculadorDias, DOCcalculadorHoras, DOCcalculadorMinutos);
            SUT.proveedorFecha = () => new DateTime(2019, 12, 1);
            
            //Act
            var resultado = SUT.obtenerMensajesEventos(eventos);

            //Assert
            Assert.IsTrue(resultado[0].Contains("Ocurrió hace 1 Dia(s)"));
        }

        [TestMethod]
        public void obtenerMensajesEventos_EventoDiaFuturo_MensajeCorrecto()
        {
            //Arrange
            List<Evento> eventos = new List<Evento>();
            Evento newEvento = new Evento("Evento mañana", new DateTime(2019, 11, 30));
            eventos.Add(newEvento);

            var DOCcalculadorMeses = new CalculadorDiferenciaFechasEnMeses();
            var DOCcalculadorDias = new CalculadorDiferenciaFechasEnDias();
            var DOCcalculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            var DOCcalculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();


            IEventoController SUT = new EventoController(DOCcalculadorMeses, DOCcalculadorDias, DOCcalculadorHoras, DOCcalculadorMinutos);
            SUT.proveedorFecha = () => new DateTime(2019, 11, 29);

            //Act
            var resultado = SUT.obtenerMensajesEventos(eventos);

            //Assert
            Assert.IsTrue(resultado[0].Contains("Ocurrirá dentro de 1 Dia(s)"));
        }

        [TestMethod]
        public void obtenerMensajesEventos_EventoHoraPasado_MensajeCorrecto()
        {
            //Arrange
            List<Evento> eventos = new List<Evento>();
            Evento newEvento = new Evento("Evento hace 1 hora", new DateTime(2019, 11, 30,12,0,0));
            eventos.Add(newEvento);

            var DOCcalculadorMeses = new CalculadorDiferenciaFechasEnMeses();
            var DOCcalculadorDias = new CalculadorDiferenciaFechasEnDias();
            var DOCcalculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            var DOCcalculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();


            IEventoController SUT = new EventoController(DOCcalculadorMeses, DOCcalculadorDias, DOCcalculadorHoras, DOCcalculadorMinutos);
            SUT.proveedorFecha = () => new DateTime(2019, 11, 30,13,0,0);

            //Act
            var resultado = SUT.obtenerMensajesEventos(eventos);

            //Assert
            Assert.IsTrue(resultado[0].Contains("Ocurrió hace 1 Hora(s)"));
        }

        [TestMethod]
        public void obtenerMensajesEventos_EventoHoraFuturo_MensajeCorrecto()
        {
            //Arrange
            List<Evento> eventos = new List<Evento>();
            Evento newEvento = new Evento("Evento proxima hora", new DateTime(2019, 11, 30,12,0,0));
            eventos.Add(newEvento);

            var DOCcalculadorMeses = new CalculadorDiferenciaFechasEnMeses();
            var DOCcalculadorDias = new CalculadorDiferenciaFechasEnDias();
            var DOCcalculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            var DOCcalculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();


            IEventoController SUT = new EventoController(DOCcalculadorMeses, DOCcalculadorDias, DOCcalculadorHoras, DOCcalculadorMinutos);
            SUT.proveedorFecha = () => new DateTime(2019, 11, 30,11,0,0);

            //Act
            var resultado = SUT.obtenerMensajesEventos(eventos);

            //Assert
            Assert.IsTrue(resultado[0].Contains("Ocurrirá dentro de 1 Hora(s)"));
        }

        [TestMethod]
        public void obtenerMensajesEventos_EventoMinutoPasado_MensajeCorrecto()
        {
            //Arrange
            List<Evento> eventos = new List<Evento>();
            Evento newEvento = new Evento("Evento hace 1 minuto", new DateTime(2019, 11, 30, 12, 0, 0));
            eventos.Add(newEvento);

            var DOCcalculadorMeses = new CalculadorDiferenciaFechasEnMeses();
            var DOCcalculadorDias = new CalculadorDiferenciaFechasEnDias();
            var DOCcalculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            var DOCcalculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();


            IEventoController SUT = new EventoController(DOCcalculadorMeses, DOCcalculadorDias, DOCcalculadorHoras, DOCcalculadorMinutos);
            SUT.proveedorFecha = () => new DateTime(2019, 11, 30, 12, 1, 0);

            //Act
            var resultado = SUT.obtenerMensajesEventos(eventos);

            //Assert
            Assert.IsTrue(resultado[0].Contains("Ocurrió hace 1 Minuto(s)"));
        }

        [TestMethod]
        public void obtenerMensajesEventos_EventoMinutoFuturo_MensajeCorrecto()
        {
            //Arrange
            List<Evento> eventos = new List<Evento>();
            Evento newEvento = new Evento("Evento proximo minuto", new DateTime(2019, 11, 30, 12, 0, 0));
            eventos.Add(newEvento);

            var DOCcalculadorMeses = new CalculadorDiferenciaFechasEnMeses();
            var DOCcalculadorDias = new CalculadorDiferenciaFechasEnDias();
            var DOCcalculadorHoras = new CalculadorDiferenciaFechasEnHoras();
            var DOCcalculadorMinutos = new CalculadorDiferenciaFechasEnMinutos();


            IEventoController SUT = new EventoController(DOCcalculadorMeses, DOCcalculadorDias, DOCcalculadorHoras, DOCcalculadorMinutos);
            SUT.proveedorFecha = () => new DateTime(2019, 11, 30, 11, 59, 0);

            //Act
            var resultado = SUT.obtenerMensajesEventos(eventos);

            //Assert
            Assert.IsTrue(resultado[0].Contains("Ocurrirá dentro de 1 Minuto(s)"));
        }
    }
}

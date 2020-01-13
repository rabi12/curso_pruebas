using ConsoleApp1.Eventos.Models;
using ConsoleApp1.Eventos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Services
{
    [TestClass]
    public class DatosParseEventosServiceUTest
    {
        [TestMethod]
        public void datosToEventos_FormatoIncorrectoMasDatos_False()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Evento mas datos", "30/11/2019", "mas datos" });

            var SUT = new DatosParseEventosService(new ValidadorArchivoEventosService());

            // Act
            try
            {
                var resultado = SUT.datosToEventos(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo tiene formato incorrecto");
                return;
            }
        }

        [TestMethod]
        public void datosToEventos_FormatoIncorrectoMenosDatos_Exception()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Evento menos datos" });

            var SUT = new DatosParseEventosService(new ValidadorArchivoEventosService());

            // Act
            try
            {
                var resultado = SUT.datosToEventos(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo tiene formato incorrecto");
                return;
            }
        }

        [TestMethod]
        public void datosToEventos_FormatoCorrecto_Evento()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Evento bien", "30/11/2019" });

            var SUT = new DatosParseEventosService(new ValidadorArchivoEventosService());

            // Act
            var resultado = SUT.datosToEventos(datos);

            // Assert
            Assert.IsInstanceOfType(resultado[0], typeof(Evento));
        }

        [TestMethod]
        public void datosToEventos_Null_Excpetion()
        {
            //Arrange
            List<string[]> datos = null;

            var SUT = new ValidadorArchivoEventosService();

            // Act
            try
            {
                var resultado = SUT.validarPlantillaEventos(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo no tiene el formato correcto o esta vacío");
                return;
            }

            Assert.Fail("No se lanzo ninguna excepcion.");
        }
    }
}

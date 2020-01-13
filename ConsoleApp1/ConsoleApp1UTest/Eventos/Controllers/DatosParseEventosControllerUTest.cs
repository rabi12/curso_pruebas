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
    public class DatosParseEventosControllerUTest
    {
        [TestMethod]
        public void obtieneEventosArchivo_FormatoIncorrectoMasDatos_False()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Evento mas datos", "30/11/2019", "mas datos" });

            DatosParseEventosService service = new DatosParseEventosService(new ValidadorArchivoEventosService());
            var SUT = new DatosParseEventosController(service);

            // Act
            try
            {
                var resultado = SUT.obtieneEventosArchivo(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo tiene formato incorrecto");
                return;
            }
        }

        [TestMethod]
        public void obtieneEventosArchivo_FormatoIncorrectoMenosDatos_Exception()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Evento menos datos" });

            DatosParseEventosService service = new DatosParseEventosService(new ValidadorArchivoEventosService());
            var SUT = new DatosParseEventosController(service);

            // Act
            try
            {
                var resultado = SUT.obtieneEventosArchivo(datos);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, "El archivo tiene formato incorrecto");
                return;
            }
        }

        [TestMethod]
        public void obtieneEventosArchivo_FormatoCorrecto_Evento()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Evento bien", "30/11/2019" });

            DatosParseEventosService service = new DatosParseEventosService(new ValidadorArchivoEventosService());
            var SUT = new DatosParseEventosController(service);

            // Act
            var resultado = SUT.obtieneEventosArchivo(datos);
            
            // Assert
            Assert.IsInstanceOfType(resultado[0], typeof(Evento));
        }

        [TestMethod]
        public void obtieneEventosArchivo_Null_Excpetion()
        {
            //Arrange
            List<string[]> datos = null;

            DatosParseEventosService service = new DatosParseEventosService(new ValidadorArchivoEventosService());
            var SUT = new DatosParseEventosController(service);

            // Act
            try
            {
                var resultado = SUT.obtieneEventosArchivo(datos);
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

using ConsoleApp1.Eventos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Services
{
    [TestClass]
    public class ValidadorArchivosEventosServiceUTest
    {
        [TestMethod]
        public void validarPlantillaEventos_FormatoIncorrectoMasDatos_False()
        {
            //Arrange
            List<string[]> datos  = new List<string[]>();
            datos.Add(new string[] { "Evento mas datos", "30/11/2019", "mas datos" });
            
            var SUT = new ValidadorArchivoEventosService();
            
            // Act
            var resultado=SUT.validarPlantillaEventos(datos);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void validarPlantillaEventos_FormatoIncorrectoMenosDatos_False()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Evento menos datos" });

            var SUT = new ValidadorArchivoEventosService();

            // Act
            var resultado = SUT.validarPlantillaEventos(datos);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void validarPlantillaEventos_FormatoCorrecto_True()
        {
            //Arrange
            List<string[]> datos = new List<string[]>();
            datos.Add(new string[] { "Evento bien", "30/11/2019"});

            var SUT = new ValidadorArchivoEventosService();

            // Act
            var resultado = SUT.validarPlantillaEventos(datos);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void validarPlantillaEventos_Null_Excpetion()
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
//
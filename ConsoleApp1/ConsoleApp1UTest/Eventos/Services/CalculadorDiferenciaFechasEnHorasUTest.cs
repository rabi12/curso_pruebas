﻿using ConsoleApp1.Eventos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1UTest.Eventos.Services
{
    [TestClass]
    public class CalculadorDiferenciaFechasEnHorasUTest
    {
        [TestMethod]
        public void calcularDiferencia_FechaFutura_Cero()
        {
            //Arrange  Menos de 1 hora
            var fecha1 = new DateTime(2019, 12, 1,15,30,0);
            var fecha2 = new DateTime(2019, 12, 1,15,00,00);
            var SUT = new CalculadorDiferenciaFechasEnHoras();

            //Act
            var resultado = SUT.calcularDiferencia(fecha1,fecha2);

            //Assert
            Assert.AreEqual(0, resultado);
        }

        [TestMethod]
        public void calcularDiferencia_FechaFutura_NumeroPositivo()
        {
            //Arrange  Mas 1 hora
            var fecha1 = new DateTime(2019, 12, 1,15,30,00);
            var fecha2 = new DateTime(2019, 12, 01,16,30,00);
            var SUT = new CalculadorDiferenciaFechasEnHoras();

            //Act
            var resultado = SUT.calcularDiferencia(fecha1, fecha2);

            //Assert
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void calcularDiferencia_FechaPasada_NumeroNegativo()
        {
            //Arrange  Menos 1 hora
            var fecha1 = new DateTime(2019, 12, 01,16,30,00);
            var fecha2 = new DateTime(2019, 12, 1,15,30,00);
            var SUT = new CalculadorDiferenciaFechasEnHoras();

            //Act
            var resultado = SUT.calcularDiferencia(fecha1, fecha2);

            //Assert
            Assert.AreEqual(-1, resultado);
        }

    }
}

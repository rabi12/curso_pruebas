﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Eventos.Services
{
    interface ICalculadorDiferenciaFechasEnMinutos
    {
        int calcularDiferencia(DateTime fecha1, DateTime fecha2);
    }
}
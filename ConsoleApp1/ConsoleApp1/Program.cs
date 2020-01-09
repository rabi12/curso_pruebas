using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Evento
    {
        string nombre;
        DateTime fecha;

        public Evento(string nombre, string fecha)
        {
            this.nombre = nombre;
            this.fecha = DateTime.Parse(fecha);
        }

        public static string getAviso(Evento evento)
        {
            int diferenciaTiempo = 0;
            string diferenciaRango = "Meses";
            string cadena = evento.nombre + " " + evento.fecha.ToString() + " ------>"+ evento.nombre + " ";

            diferenciaTiempo = getMeses(evento.fecha);
            if (diferenciaTiempo == 0) {
                diferenciaRango = "Dias";
                diferenciaTiempo = getDias(evento.fecha);
                if (diferenciaTiempo == 0)
                {
                    diferenciaRango = "Minutos";
                    diferenciaTiempo = getMinutos(evento.fecha);
                }
            }

            if (diferenciaTiempo > 0)
            {
                cadena += " Ocurrirá dentro de "+ diferenciaTiempo + " "+ diferenciaRango;
            }
            else
                cadena += " Ocurrió hace " + Math.Abs(diferenciaTiempo) + " " + diferenciaRango;
            return cadena;
        }

        public static int getMeses(DateTime fechaEvento)
        {
            int dias = getDias(fechaEvento);
            if(dias > 30 || dias < -30)
            {
                return dias / 30;
            }

            return 0;
           
        }

        public static int getDias(DateTime fechaEvento)
        {
            DateTime fechaActual = DateTime.Now;

            if (fechaActual > fechaEvento)
            {
                TimeSpan ts = fechaActual - fechaEvento;
                return -ts.Days;
            }
            else
            {
                TimeSpan ts = fechaEvento - fechaActual;
                return ts.Days;
            }

        }
        
        public static int getHoras(DateTime fechaEvento)
        {
            DateTime fechaActual = DateTime.Now;

            if (fechaActual > fechaEvento)
            {
                TimeSpan ts = fechaActual - fechaEvento;
                return -ts.Hours;
            }
            else
            {
                TimeSpan ts = fechaEvento - fechaActual;
                return ts.Hours;
            }
        }
        public static int getMinutos(DateTime fechaEvento)
        {
            DateTime fechaActual = DateTime.Now;

            if (fechaActual > fechaEvento)
            {
                TimeSpan ts = fechaActual - fechaEvento;
                return -ts.Minutes;
            }
            else
            {
                TimeSpan ts = fechaEvento - fechaActual;
                return ts.Minutes;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<String[]> eventos =Program.parseCSV("Archivo Eventos.csv");

            foreach(var evento in eventos)
            {
                Evento newEvento = new Evento(evento[0], evento[1]);
                String aviso=Evento.getAviso(newEvento);
                Console.WriteLine(aviso);
            }
            
            Console.ReadKey();
        }

        public static List<string[]> parseCSV(string path)
        {
            List<string[]> parsedData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(',');
                    parsedData.Add(row);
                }
            }
            return parsedData;
        }
    }

}

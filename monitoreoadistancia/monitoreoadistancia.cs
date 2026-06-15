﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace monitoreoadistancia
{
    public class MonitoreoDistancia
    {
        Random rnd = new Random();

        public void MostrarReporte()
        {
            Console.Clear();
            System.Threading.Thread.Sleep(50);

            
            Console.WriteLine("=============================================================================");
            Console.WriteLine("   REPORTE REMOTO - HOTEL CIELO");
            Console.WriteLine("   Lima, Peru - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("=============================================================================");
           

            Console.Write("Conectando toda la informacion del hotel: ");
            Thread.Sleep(500); Console.Write(".");
            Thread.Sleep(500); Console.Write(".");
            Thread.Sleep(500); Console.WriteLine(".");
            
            Console.WriteLine("Conexión lista");
          
            Console.WriteLine("-----------------------------------------------------------------------------");

         
            int escenarioAleatorio = rnd.Next(1, 4);

            int pisoElegido = rnd.Next(1, 4);
            int cuartoElegido = rnd.Next(1, 3);

            bool hayIncendio = false;

            Console.WriteLine(" MONITOREO DEL PISO 1:");
            hayIncendio |= MostrarPiso(1, escenarioAleatorio, pisoElegido, cuartoElegido);
            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.WriteLine("MONITOREO DEL PISO 2:");
            hayIncendio |= MostrarPiso(2, escenarioAleatorio, pisoElegido, cuartoElegido);
            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.WriteLine("MONITOREO DEL PISO 3:");
            hayIncendio |= MostrarPiso(3, escenarioAleatorio, pisoElegido, cuartoElegido);
            Console.WriteLine("=============================================================================");

            if (hayIncendio)
            {
                Console.WriteLine();
             
                Console.WriteLine(" ALERTA GENERAL EN LA CENTRAL: ");
                Thread.Sleep(1500);
                Console.WriteLine("INCENDIO DETECTADO");

                ReproducirAlarma("Alarmas/sonidoPELIGRO.wav");

                Console.WriteLine();
                Console.Write("Llamando a los bomberos");
                Thread.Sleep(800); Console.Write(".");
                Thread.Sleep(800); Console.Write(".");
                Thread.Sleep(800); Console.WriteLine(".");


                Console.WriteLine("mandando ubicacion a los bomberos...");
                Thread.Sleep(1500);
                Console.WriteLine("\nbomberos llegando al sitio... ");
                Thread.Sleep(1500);
                Console.WriteLine("ya llegaron los bomberos");
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("  SIN INCENDIOS REGISTRADOS");
                Console.WriteLine();
                Console.ReadKey();
            }

            Console.WriteLine("\nPresione cualquier tecla para regresar al menú principal...");
            Console.ReadKey();
        }

        bool MostrarPiso(int numeroPiso, int escenario, int pisoFuego, int cuartoFuego)
        {
            int temp1 = 0, temp2 = 0;
            double humo1 = 0, humo2 = 0;

            if (escenario == 1)
            {
                temp1 = rnd.Next(16, 26);
                humo1 = Math.Round(rnd.NextDouble() * 12, 1);
                temp2 = rnd.Next(16, 26);
                humo2 = Math.Round(rnd.NextDouble() * 12, 1);
            }
            else if (escenario == 2)
            {
                if (numeroPiso == pisoFuego)
                {
                    temp1 = (cuartoFuego == 1) ? rnd.Next(55, 75) : rnd.Next(16, 26);
                    humo1 = (cuartoFuego == 1) ? Math.Round(48 + rnd.NextDouble() * 30, 1) : Math.Round(rnd.NextDouble() * 12, 1);

                    temp2 = (cuartoFuego == 2) ? rnd.Next(55, 75) : rnd.Next(16, 26);
                    humo2 = (cuartoFuego == 2) ? Math.Round(48 + rnd.NextDouble() * 30, 1) : Math.Round(rnd.NextDouble() * 12, 1);
                }
                else
                {
                    temp1 = rnd.Next(16, 26);
                    humo1 = Math.Round(rnd.NextDouble() * 12, 1);
                    temp2 = rnd.Next(16, 26);
                    humo2 = Math.Round(rnd.NextDouble() * 12, 1);
                }
            }
            else
            {
                temp1 = rnd.Next(45, 75);
                humo1 = Math.Round(40 + rnd.NextDouble() * 50, 1);
                temp2 = rnd.Next(45, 75);
                humo2 = Math.Round(40 + rnd.NextDouble() * 50, 1);
            }

            bool peligro1 = temp1 >= 50 || humo1 >= 45;
            bool peligro2 = temp2 >= 50 || humo2 >= 45;
            bool incendio = peligro1 || peligro2;

            Console.WriteLine("Cuarto 1 - Temperatura: " + temp1 + "°C  " + (peligro1 ? "PELIGRO" : "NORMAL"));
            Console.WriteLine("Cuarto 1 - Humo:        " + humo1 + "%   " + (peligro1 ? "PELIGRO" : "NORMAL"));
            Console.WriteLine("Cuarto 2 - Temperatura: " + temp2 + "°C  " + (peligro2 ? "PELIGRO" : "NORMAL"));
            Console.WriteLine("Cuarto 2 - Humo:        " + humo2 + "%   " + (peligro2 ? "PELIGRO" : "NORMAL"));

            if (peligro1 && peligro2)
            {
                Console.WriteLine("INCENDIO CRÍTICO EN PISO " + numeroPiso + ": CUARTO 1 Y CUARTO 2");
                ReproducirAlarma("Alarmas/sonidoPELIGRO.wav");

                ActivarAspersores(numeroPiso, 1, temp1);
                ActivarAspersores(numeroPiso, 2, temp2);
            }
            else if (peligro1)
            {
                Console.WriteLine("INCENDIO DETECTADO EN PISO " + numeroPiso + ": CUARTO 1");
                ReproducirAlarma("Alarmas/sonidoLEVE.wav");
                ActivarAspersores(numeroPiso, 1, temp1);
            }
            else if (peligro2)
            {
                Console.WriteLine("INCENDIO DETECTADO EN PISO " + numeroPiso + ": CUARTO 2");
                ReproducirAlarma("Alarmas/sonidoLEVE.wav");
                ActivarAspersores(numeroPiso, 2, temp2);
            }

            return incendio;
        }
        void ActivarAspersores(int piso, int cuarto, int temperaturaInicial)
        {
            Console.WriteLine();
            Console.WriteLine("  ╔═════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║      SISTEMA AUTOMÁTICO ACTIVO EN PISO  - CUARTO                ║");
            Console.WriteLine("  ║     ASPERSORES DE AGUA ACTIVADOS EN LA ZONA AFECTADA            ║");
            Console.WriteLine("  ╚═════════════════════════════════════════════════════════════════╝");
            Thread.Sleep(800);

            int tempActual = temperaturaInicial;

            while (tempActual > 25)
            {
                tempActual -= 10; 

                if (tempActual < 25) tempActual = 25;
                Console.Write($"Rociando agua... Temperatura actual: ");

                if (tempActual == 25)
                {
               
                    Console.WriteLine(tempActual + "°C ESTABLE");
                }
                else
                {
                    Console.WriteLine(tempActual + "°C PELIGRO");
                }
                Thread.Sleep(600); 
            }
            Console.WriteLine($"Temperatura controlada con éxito en Piso {piso} - Cuarto {cuarto}");
            Console.WriteLine();
        }

        void ReproducirAlarma(string rutaArchivo)
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer(rutaArchivo);
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reproducir sonido: " + ex.Message);
            }
        }
    }
}
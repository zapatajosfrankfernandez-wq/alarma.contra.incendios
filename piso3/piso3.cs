using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Piso3
{
    public class piso3
    {
        public void MostrarEstado()
        {
            Console.Clear();
            Random random = new Random();

            int temp1 = random.Next(20, 90);
            int humo1 = random.Next(0, 50);
            int temp2 = random.Next(20, 90);
            int humo2 = random.Next(0, 50);


            bool incendio1 = temp1 >= 55 && humo1 >= 48;
            bool incendio2 = temp2 >= 55 && humo2 >= 48;


            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        PLANO DETECCIÓN - PISO 3                           ║");
            Console.WriteLine("║                                                                           ║");
            Console.WriteLine("║ ┌───────────────────────────────┐     ┌───────────────────────────────┐   ║");
            Console.WriteLine("║ │           CUARTO 1            │     │           CUARTO 2            │   ║");
            Console.WriteLine("║ │ ┌──────┐         ┌──────┐     │     │    ┌──────┐         ┌──────┐  │   ║");
            Console.WriteLine("║ │ │      │         │      │     │     │    │      │         │      │  │   ║");
            Console.WriteLine("║ │ └──────┘         └──────┘     │     │    └──────┘         └──────┘  │   ║");
            Console.WriteLine("║ │                               │     │                               │   ║");
            Console.WriteLine("║ │ Temp: " + temp1.ToString("00") + " °C     Humo: " + humo1.ToString("00") + "%     │     │ Temp: " + temp2.ToString("00") + " °C     Humo: " + humo2.ToString("00") + "%     │   ║");
            Console.WriteLine("║ │                               │     │                               │   ║");
            Console.WriteLine("║ │                               │     │                               │   ║");
            Console.WriteLine("║ └───────────────────────────────┘     └───────────────────────────────┘   ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ Última actualización: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss t") + "  ║");



            MostrarEstadoCuarto("Cuarto 1", temp1, humo1, incendio1);
            Console.WriteLine("║---------------------------------------------------------------------------║");
            MostrarEstadoCuarto("Cuarto 2", temp2, humo2, incendio2);

            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.Write("Presione una tecla para volver al menú...");
            Console.ReadKey();
        }

        void MostrarEstadoCuarto(string nombre, int temp, int humo, bool incendio)
        {
            Console.WriteLine("║ " + nombre + " - Temperatura: " + temp + " °C");
            Console.WriteLine("║ " + nombre + " - Humo: " + humo + " %");

            if (incendio)
            {
                Console.WriteLine("║  ¡ALERTA DE INCENDIO en " + nombre + "!");
                ReproducirAlarmax("Alarmas/sonidoPELIGRO.wav");
            }
            else
            {
                Console.WriteLine("║ Estado: Normal");
            }
        }
        public void ReproducirAlarmax(string rutaArchivo)
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer(rutaArchivo);
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reproducir sonido crítico: " + ex.Message);
            }
        }


    }
}


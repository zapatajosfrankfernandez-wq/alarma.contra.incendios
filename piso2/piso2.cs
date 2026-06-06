using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Piso2
{
    public class piso2
    {
        public void MostrarEstado()
        {
            Console.Clear();
            Random random = new Random();


            int temp1 = random.Next(15, 75);
            double humo1 = Math.Round(random.NextDouble() * 100, 1);
            int temp2 = random.Next(15, 75);
            double humo2 = Math.Round(random.NextDouble() * 100, 1);

            bool incendio1 = temp1 >= 50.0 || humo1 >= 45.0;
            bool incendio2 = temp2 >= 50.0 || humo2 >= 45.0;


            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                P I S O    2                                      ║");
            Console.WriteLine("║                                                                           ║");
            Console.WriteLine("║ ┌───────────────────────────────┐     ┌───────────────────────────────┐   ║");
            Console.WriteLine("║ │           CUARTO 1            │     │           CUARTO 2            │   ║");
            Console.WriteLine("║ │ ┌──────┐         ┌──────┐     │     │    ┌──────┐         ┌──────┐  │   ║");
            Console.WriteLine("║ │ │      │         │      │     │     │    │      │         │      │  │   ║");
            Console.WriteLine("║ │ └──────┘         └──────┘     │     │    └──────┘         └──────┘  │   ║");
            Console.WriteLine("║ │                               │     │                               │   ║");
            Console.WriteLine("║ │ Temp: " + temp1 + " °C     Humo: " + humo1.ToString("00.0") + "%     │     │ Temp: " + temp2 + " °C     Humo: " + humo2.ToString("00.0") + "%     │   ║");
            Console.WriteLine("║ │                               │     │                               │   ║");
            Console.WriteLine("║ │                               │     │                               │   ║");
            Console.WriteLine("║ └───────────────────────────────┘     └───────────────────────────────┘   ║");
            Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║ Última actualización: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss ") + "                          ");
            Console.WriteLine("=============================================================================");

            if (incendio1 && incendio2)
            {
                Console.WriteLine("Alarma Critica: INCENDIO EN AMBOS CUARTOS DEL PISO 2");
                Console.WriteLine("CUARTO 1 y CUARTO 2");
                Console.WriteLine("Luces Estroboscópicas: ACTIVADA EN TODO LOS PISOS");
                Console.WriteLine("Porfavor Evacuar");
                ReproducirAlarmaf("Alarmas/sonidoPELIGRO.wav");
            }
            else if (incendio1)
            {
                Console.WriteLine("ALARMA DE INCENDIO");
                Console.WriteLine("CUARTO 1");
                Console.WriteLine("Luces Estroboscópicas: ACTIVADA EN TODO LOS PISOS");
                Console.WriteLine("Porfavor Evacuar");
                ReproducirAlarmaf("Alarmas/sonidoLEVE.wav");
            }
            else if (incendio2)
            {
                Console.WriteLine("ALARMA DE INCENDIO");
                Console.WriteLine("CUARTO 2");
                Console.WriteLine("Luces Estroboscópicas: ACTIVADA EN TODO LOS PISOS");
                Console.WriteLine("Porfavor Evacuar");
                ReproducirAlarmaf("Alarmas/sonidoLEVE.wav");
            }
            else
            {
                Console.WriteLine(" Sistema Seguro: PISO 2 SIN DAÑOS");
            }
            Console.WriteLine("=============================================================================");

            Console.WriteLine("\nPresione cualquier tecla para regresar...");
            Console.ReadKey();
        }

        public void ReproducirAlarmaf(string rutaArchivo)
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
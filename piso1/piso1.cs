using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Piso1
{
    public class P1
    {
        public DateTime Tiempo { get; set; }
        public int Piso { get; set; }
        public double Temp1 { get; set; }
        public double Humo1 { get; set; }
        public double Temp2 { get; set; }
        public double Humo2 { get; set; }
    }

    public class piso1
    {
        int direccionSensorC1 = 1;
        int direccionSensorC2 = 2;
        public Random rnd = new Random();
        public bool HuboIncendio { get; private set; }

        public void MostrarSimulacion()
        {
            P1 dato = SimularSensores();
            PlanoCasaP1(dato);
            MostrarEstado(dato);
            VerificarAlarmas(dato);
        }

        public P1 SimularSensores()
        {
            return new P1
            {
                Tiempo = DateTime.Now,
                Piso = 1,
                Temp1 = rnd.Next(15, 75),
                Humo1 = Math.Round(rnd.NextDouble() * 100, 1),
                Temp2 = rnd.Next(15, 75),
                Humo2 = Math.Round(rnd.NextDouble() * 100, 1)
            };
        }

        public void PlanoCasaP1(P1 dato)
        {
            Console.Clear();
            Console.WriteLine("                     ╔════════════════════════════════════════════░░░░══════════════════════════░░░░══╗");
            Console.WriteLine("                     ║      ╔══════╗E               ▓                           ┌───────────────┐     ║");
            Console.WriteLine("                     ║      ║------║S               ▓                           │ Cuarto 2      │     ║");
            Console.WriteLine("                     ║      ║--  --║C               ▓                           │ Temp:{0,5}°C  │     ║", dato.Temp2);
            Console.WriteLine("                     ║      ║--  --║A               ▓                           │ Humo:{1,5}%   │     ║", dato.Temp2, dato.Humo2);
            Console.WriteLine("                     ║      ║--  --║L               ▓                           └───────────────┘     ║");
            Console.WriteLine("                     ║      ║--  --║E               ▓                                                 ║");
            Console.WriteLine("                     ║      ║--  --║R               ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓     ║");
            Console.WriteLine("                     ║      ╚══════╝A                                                                 ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                     P A S I L L O                              ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                       ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓                  ║");
            Console.WriteLine("                     ║                                                               ▓                ║");
            Console.WriteLine("                     ║                                                               ▓                ║");
            Console.WriteLine("                     ║                                                               ▓                ║");
            Console.WriteLine("                     ║                                         ┌───────────────┐     ▓                ║");
            Console.WriteLine("                     ║                                   ▓     │ Cuarto 1      │     ▓                ║");
            Console.WriteLine("                     ║                                   ▓     │ Temp:{0,5}°C  │     ▓                ║", dato.Temp1);
            Console.WriteLine("                     ║                                   ▓     │ Humo: {1,5}%  │     ▓                ║", dato.Temp1, dato.Humo1);
            Console.WriteLine("                     ║                                   ▓     └───────────────┘     ▓                ║");
            Console.WriteLine("                     ╚══════░░░░════════════════════════════════════════░░░░══════════════════════════╝");
        }
        public void MostrarEstado(P1 dato)
        {
            Console.WriteLine("                                    ════════════════════════════════════════════════");
            Console.WriteLine("                                         ========== ESTADO DEL PISO  ==========");
            EscribirCentrado($"Última actualización: {dato.Tiempo}");

            EscribirCentrado($"Cuarto 1 - Temp: {dato.Temp1} °C", NivelRiesgoTemperature(dato.Temp1));
            EscribirCentrado($"Cuarto 1 - Humo: {dato.Humo1}%", NivelRiesgoHumo(dato.Humo1));
            Console.WriteLine("                                    ════════════════════════════════════════════════");
            EscribirCentrado($"Cuarto 2 - Temp: {dato.Temp2} °C", NivelRiesgoTemperature(dato.Temp2));
            EscribirCentrado($"Cuarto 2 - Humo: {dato.Humo2}%", NivelRiesgoHumo(dato.Humo2));

            Console.WriteLine("                                    ════════════════════════════════════════════════");
        }
        public void EscribirCentrado(string texto, string nivel)
        {
            int ancho = Console.WindowWidth;
            int margen = Math.Max((ancho - texto.Length) / 2, 0);
            Console.Write(new string(' ', margen));
            switch (nivel)
            {
                case "Estable":
                case "Bajo":
                    break;
                case "Normal":
                case "Moderado":
                    break;
                case "Peligro":
                    break;
            }

            Console.WriteLine(texto);
        }
        public void VerificarAlarmas(P1 dato)
        {
            bool cuarto1Peligro = dato.Temp1 >= 30.0 || dato.Humo1 >= 48.0;
            bool cuarto2Peligro = dato.Temp2 >= 30.0 || dato.Humo2 >= 48.0;

            Console.WriteLine("                      ===========================================================================");
            if (cuarto1Peligro && cuarto2Peligro)
            {
                EscribirCentrado("INCENDIO EN AMBOS CUARTOS");
                EscribirCentrado("Cuarto 1  y Cuarto 2");
                EscribirCentrado("Luces Estroboscópicas: ACTIVADA EN TODO LOS PISOS");
                Console.WriteLine("                                                 Porfavor Evacuar");
                ReproducirAlarma1("Alarmas/sonidoPELIGRO.wav");
            }
            else if (cuarto1Peligro)
            {
                EscribirCentrado("ALARMA DE INCENDIO");
                EscribirCentrado("CUARTO 1 ");
                EscribirCentrado("Luces Estroboscópicas: ACTIVADA EN TODOS LOS PISOS");
                Console.WriteLine("                                                     Porfavor Evacuar");
                ReproducirAlarma2("Alarmas/sonidoLEVE.wav");
            }
            else if (cuarto2Peligro)
            {
                EscribirCentrado("ALARMA DE INCENDIO");
                EscribirCentrado("CUARTO 2 Sensor Dirección");
                EscribirCentrado("Luces Estroboscópicas: ACTIVADA EN TODOS LOS PISOS");
                Console.WriteLine("Porfavor Evacuar");

                ReproducirAlarma2("Alarmas/sonidoLEVE.wav");
            }
            else
            {
                EscribirCentrado("Sistema Seguro: PISO 1 SIN DAÑOS");
              
            }

            Console.WriteLine("                      ============================================================================");
            HuboIncendio = cuarto1Peligro || cuarto2Peligro;
            Console.WriteLine("\nPresione cualquier tecla para regresar...");
            Console.ReadKey();
        }

        public void ReproducirAlarma1(string rutaArchivo)
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
        public void ReproducirAlarma2(string rutaArchivo)
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer(rutaArchivo);
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reproducir sonido leve: " + ex.Message);
            }
        }
        public string NivelRiesgoTemperature(double temp)
        {
            if (temp < 28.0) return "Estable";
            if (temp < 30.0) return "Normal";
            return "Peligro";
        }
        public string NivelRiesgoHumo(double humo)
        {
            if (humo < 20.0) return "Bajo";
            if (humo < 35.0) return "Moderado";
            return "Peligro";
        }

        public void EscribirCentrado(string texto)
        {
            int ancho = Console.WindowWidth;
            int margen = Math.Max((ancho - texto.Length) / 2, 0);
            Console.WriteLine(new string(' ', margen) + texto);
        }
    }
}

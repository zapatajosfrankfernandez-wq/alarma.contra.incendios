using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using monitoreoadistancia;
using Piso1;
using Piso2;
using Piso3;

namespace SistemaContraincendio
{
    public class Program
    {
        static bool continuar = true;
        static Random rndEnergia = new Random();
        static string turnoActual = "";
        static List<string> historial = new List<string>();
        static bool energiaPrincipal = true;
        static bool energiaRespaldo = true;
        static void LucesEstroboscopicas()
        {
            try
            {
                SoundPlayer sonido = new SoundPlayer("Alarmas/sonidoPELIGRO.wav");
                sonido.Play();
            }
            catch { }

            for (int i = 0; i < 6; i++)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("                                      ");
                Console.WriteLine("      INCENDIO DETECTADO !!!          ");
                Console.WriteLine("      EVACUE EL HOTEL AHORA !!!       ");
                Console.WriteLine("                                      ");
                Console.WriteLine("========================================");

                Console.Beep(1500, 200);
                Thread.Sleep(250);

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("=========================================");
                Console.WriteLine("                                      ");
                Console.WriteLine("   LUCES ESTROBOSCOPICAS ACTIVADAS    ");
                Console.WriteLine("                                      ");
                Console.WriteLine("========================================");

                Console.Beep(1000, 200);
                Thread.Sleep(250);
            }

            Console.ResetColor();
        }


        static void Main(string[] args)
        {
            Console.Title = "Sistema de Monitoreo - EL BOMBERITO";
            Console.WriteLine("                               LIMA PERU  - PERÚ 2026                                 ");
            Console.WriteLine("===================================================================================");
            Console.WriteLine("                               H O T E L  C I E L O                                ");
            Console.WriteLine($"                                {DateTime.Now}                                      ");
            Console.WriteLine("===================================================================================");
            Console.WriteLine();

            energiaPrincipal = rndEnergia.Next(0, 2) == 0;
            Console.WriteLine("VERIFICANDO ENERGIA DEL SISTEMA...");
            Thread.Sleep(2500);
            if (energiaPrincipal)
            {
                Console.WriteLine("ENERGIA PRINCIPAL: todo bien");
                Thread.Sleep(2500);
            }
            else if (energiaRespaldo)
            {
                Console.WriteLine("energia principal fallo");
                Console.WriteLine("cambiando a energia de respaldo...");
                Thread.Sleep(2500);
                Console.WriteLine("energia de respaldo: activada");
                Thread.Sleep(2500);

                int turno = rndEnergia.Next(0, 2);
                if (turno == 0)
                {
                    turnoActual = "dia";
                    Console.WriteLine("TURNO: dia");
                }
                else
                {
                    turnoActual = "noche";
                    Console.WriteLine("TURNO: noche");
                }
                Thread.Sleep(2500);
            }
            Console.WriteLine();

            while (continuar)
            {

                Console.Clear();
                DibujarEdificio();
                MenuPrincipal();

            }
        }
        static void DibujarEdificio()
        {
            Console.WriteLine("¿QUÉ PISO DEL EDIFICIO DESEA MONITOREAR?");
            Console.WriteLine("       _______________________________________");
            Console.WriteLine("      //                                     /|");
            Console.WriteLine("     //                                     //|");
            Console.WriteLine("    //                                     // |");
            Console.WriteLine("   //_____________________________________//  |");
            Console.WriteLine("   ||                                     ||  |");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   ||  /|");
            Console.WriteLine("   ||   ||   ||      PISO 3    ||   ||   || / |");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   ||/  |");
            Console.WriteLine("   ||-----------------||-----------------||   |");
            Console.WriteLine("   ||                                     ||  |");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   ||  /|");
            Console.WriteLine("   ||   ||   ||      PISO 2    ||   ||   || / |");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   ||/  |");
            Console.WriteLine("   ||-----------------||-----------------||   |");
            Console.WriteLine("   ||                                     ||  |");
            Console.WriteLine("   ||      _____    PISO 1    _____      ||   /");
            Console.WriteLine("   ||      |S E|      ||      |S E|      ||  /");
            Console.WriteLine("   ||      |?  |      ||      |?  |      || /");
            Console.WriteLine("   ||||||||||||||||||||||||||||||||||||||||/");
            Console.WriteLine("  _______________________________________\n");
        }

        static void MenuPrincipal()
        {
            Console.WriteLine("MENÚ DE MONITOREO");
            Console.WriteLine("1. Monitorear pisos: ");
            Console.WriteLine("2. Monitoreo a Distancia: ");
            Console.WriteLine("3. Alerta Manual: ");
            Console.WriteLine("4. Historial: ");
            Console.WriteLine("5. Salir: ");
            Console.WriteLine();
            Console.Write("\nSeleccione una opción (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {

                switch (opcion)
                {
                    case 1:
                        bool salirPisos = false;
                        while (!salirPisos)
                        {
                            Console.Clear();
                            Console.WriteLine("=== MONITOREAR PISOS ===");
                            Console.WriteLine("1. Piso 1");
                            Console.WriteLine("2. Piso 2");
                            Console.WriteLine("3. Piso 3");
                            Console.WriteLine("4. Regresar al menu principal");
                            Console.Write("\nQue piso desea ver: ");
                            if (int.TryParse(Console.ReadLine(), out int pisoElegido))
                            {
                                if (pisoElegido == 1)
                                {
                                    Console.Clear();
                                    var p1 = new piso1();
                                    p1.MostrarSimulacion();
                                    if (p1.HuboIncendio)
                                    {
                                        LucesEstroboscopicas();
                                    }
                                    string resultado1 = p1.HuboIncendio ? "Hubo incendio" : "no hubo incendio";
                                    historial.Add("piso 1 - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - turno: " + turnoActual + " - " + resultado1);
                                }
                                else if (pisoElegido == 2)
                                {
                                    Console.Clear();
                                    var p2 = new piso2();
                                    p2.MostrarEstado();
                                    if (p2.HuboIncendio)
                                    {
                                        LucesEstroboscopicas();
                                    }
                                    string resultado2 = p2.HuboIncendio ? "Hubo incendio" : "no hubo incendio";
                                    historial.Add("piso 2 - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - turno: " + turnoActual + " - " + resultado2);
                                }
                                else if (pisoElegido == 3)
                                {
                                    Console.Clear();
                                    var p3 = new piso3();
                                    p3.MostrarEstado();
                                    if (p3.HuboIncendio)
{
    LucesEstroboscopicas();
}
                                    string resultado3 = p3.HuboIncendio ? "hubo incendio" : "no hubo incendio";
                                    historial.Add("piso 3 - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - turno: " + turnoActual + " - " + resultado3);
                                }
                                else if (pisoElegido == 4)
                                {
                                    salirPisos = true;
                                }
                                else
                                {
                                    Console.WriteLine("opcion no valida");
                                    Console.ReadKey();
                                }
                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine(" Ingresando al monitoreo a distancia...");
                        Thread.Sleep(500);
                        new MonitoreoDistancia().MostrarReporte();
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("=== ESTACION MANUAL DE ALARMA ===");
                        Console.WriteLine("Ingrese el piso donde esta el incendio:");
                        string piso = Console.ReadLine();
                        Console.WriteLine("Ingrese el cuarto: ");
                        string cuarto = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("ALERTA MANUAL ACTIVADA");
                        try
                        {
                            SoundPlayer sonido = new SoundPlayer("Alarmas/sonidoPELIGRO.wav");
                            sonido.Play();
                        }
                        catch { }
                        if (cuarto == "ambos")
                        {
                            Console.WriteLine("incendio reportado en piso " + piso + " cuarto 1 y cuarto 2");
                        }
                        else
                        {
                            Console.WriteLine("incendio reportado en piso " + piso + " cuarto " + cuarto);
                        }
                        Console.WriteLine("activando luces estroboscopicas...");
                        Console.WriteLine("llamando a bomberos...");
                        historial.Add("alerta manual - piso " + piso + " cuarto " + cuarto + " - " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - turno: " + turnoActual);
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("historial de consultas:");
                        Console.WriteLine("========================");
                        if (historial.Count == 0)
                        {
                            Console.WriteLine("no hay consultas aun");
                        }
                        else
                        {
                            foreach (string registro in historial)
                            {
                                Console.WriteLine("- " + registro);
                            }
                        }
                        Console.ReadKey();
                        break;

                    case 5:
                        try
                        {
                            SoundPlayer sonidoSalir = new SoundPlayer("Alarmas/sonidoLEVE.wav");
                            sonidoSalir.Play();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al reproducir sonido de salida: " + ex.Message);
                        }
                        Console.Clear();
                        Console.WriteLine(" SALIENDO DEL SISTEMA ...");
                        Console.ReadKey();


                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("          M U C H A S  G R A C I A S  P O R   T E N E R   C O N F I A N Z A   E N   N O S O T R O S");
                        continuar = false;
                        Console.ReadKey();

                        return;

                    default:
                        Console.WriteLine(" Opción no válida. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine(" Entrada inválida. Debe ingresar un número del 1 al 5.");
                Console.ReadKey();
            }
        }
    }
}
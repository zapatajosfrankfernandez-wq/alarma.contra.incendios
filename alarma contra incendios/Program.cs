using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Piso1;
using Piso2;
using Piso3;

namespace SistemaContraincendio
{
    internal class Program
    {
        static bool continuar = true;
        static void Main(string[] args)
        {
            Console.Title = "Sistema de Monitoreo - EL BOMBERITO";
             Console.WriteLine("                               LIMA PERU  - PERÚ 2026                                 ");
             Console.WriteLine("===================================================================================");
             Console.WriteLine("                             H O T E L  C I E L O                                ");             
             Console.WriteLine($"                                  {DateTime.Now}                                      ");
             Console.WriteLine("===================================================================================");
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
            Console.WriteLine("1. Cuartos de Piso 1");
            Console.WriteLine("2. Cuartos de Piso 2");
            Console.WriteLine("3. Cuartos de Piso 3");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción (1-4): ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(" Ingresando al Piso 1...");
                        new piso1().MostrarSimulacion();
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine(" Ingresando al Piso 2...");
                        new piso2().MostrarEstado();
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine(" Ingresando al Piso 3...");
                        new piso3().MostrarEstado();
                        break;

                    case 4:
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
                Console.WriteLine(" Entrada inválida. Debe ingresar un número del 1 al 6.");
            }         
            Console.ReadKey();
           
        }
    }
}


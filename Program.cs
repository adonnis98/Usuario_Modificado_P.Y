using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Usuario.Clases;

namespace Usuario
{
    public class Program
    {
        private static Clases.Usuario gestionUsuarios = new Clases.Usuario();

        static void DisplayLoginScreenWithLoading()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();

            Console.WriteLine("╔══════════════════════════════════════════════════════╗    ");
            Console.WriteLine("║  ║║     ║║║║     ║║║║║║║║   ║║        ║║║║         ║    ");
            Console.WriteLine("║  ║║     ║║ ║║       ║║     ║║         ║║           ║    ");
            Console.WriteLine("║  ║║     ║║         ║║     ║║        ║║             ║    ");
            Console.WriteLine("║  ║║       ║║         ║║     ║║        ║║             ║    ");
            Console.WriteLine("║  ║║     ║║ ║║       ║║     ║║         ║║           ║    ");
            Console.WriteLine("║  ║║ ║║   ║║║║ ║║   ║║ ║║   ║║║║║║ ║║    ║║║║   ║║  ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝    ");
            Console.WriteLine("╔══════════════════════════════════════════════════════╗    ");
            Console.WriteLine("║          BIENVENIDO A MI APLICACIÓN              ║    ");
            Console.WriteLine("║                    Versión 1.0                   ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝    ");
            Console.WriteLine("╔══════════════════════════════════════════════════════╗    ");
            Console.WriteLine("║  Sistema de Gestión de Información para la Fundación ║    ");
            Console.WriteLine("║                  RESPLANDECE KIDS                  ║    ");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝    ");

            Console.ResetColor();

            Console.Write("Cargando");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            DisplayLoginScreenWithLoading();

            gestionUsuarios = new Clases.Usuario();
            gestionUsuarios.CrearUsuariosAdministrativos();
            DisplayLoginScreenWithAuthentication();

            DisplayMainMenu();
        }

        static void DisplayLoginScreenWithAuthentication()
        {
            Console.WriteLine("████████████████████████████████████████████████████");
            Console.WriteLine("█                                                  █");
            Console.WriteLine("█ * * F U N D A C I Ó N  R E S P L A N D E C E * * █");
            Console.WriteLine("█                                                  █");
            Console.WriteLine("████████████████████████████████████████████████████");

            Console.WriteLine("\nBienvenido al sistema Resplandece Kids\n");

            bool isAuthenticated = false;
            while (!isAuthenticated)
            {
                Console.Write("Usuario: ");
                string username = Console.ReadLine();

                Console.Write("Contraseña: ");
                string password = ReadPassword();

                isAuthenticated = gestionUsuarios.AutenticarUsuario(username, password);

                if (!isAuthenticated)
                {
                    Console.WriteLine("\nUsuario o contraseña incorrectos. Intente de nuevo.\n");
                }
            }

            Console.Clear();
        }

        private static string ReadPassword()
        {
            StringBuilder passwordBuilder = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    passwordBuilder.Append(key.KeyChar);
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && passwordBuilder.Length > 0)
                {
                    passwordBuilder.Remove(passwordBuilder.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return passwordBuilder.ToString();
        }

        static void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("█████████████████████████████████████████");
                Console.WriteLine("█                                       █");
                Console.WriteLine("█      * * * Menú Principal * * *       █");
                Console.WriteLine("█                                       █");
                Console.WriteLine("█████████████████████████████████████████");
                Console.WriteLine("1. Registrar nuevo niños/niñas "); //resigtrar niñoas y buscar y consultar
                Console.WriteLine("2. Gestion de datos: "); // edita informacion y elimina registro
                Console.WriteLine("3. Reporte y listado: "); //genera reportes  e imprime listados 
                Console.WriteLine("4. Accesivilidad");
              
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                Console.ReadLine();
            }
        }
    }
}



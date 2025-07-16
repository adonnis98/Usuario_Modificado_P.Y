using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BSD.Clases;
using Usuario.Clases;

namespace Usuario
{
    public class Program
    {
        private static Clases.Usuario gestionUsuarios = new Clases.Usuario();

        static void DisplayLoginScreenWithLoading()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
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

        public static void DisplayMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("█████████████████████████████████████████");
                Console.WriteLine("█                                       █");
                Console.WriteLine("█      * * * Menú Principal * * *       █");
                Console.WriteLine("█                                       █");
                Console.WriteLine("█████████████████████████████████████████");
                Console.WriteLine("1. Registrar nuevo niños/niñas "); //resigtrar niñoas create
                Console.WriteLine("2. Información de niños/niñas ");  //buscar y consultar read
                Console.WriteLine("3. Registro");  //read all
                Console.WriteLine("4. Gestion de datos: "); // edita informacion y elimina registro update
                Console.WriteLine("5. Eliminar datos de beneficiario");  // delete
                Console.WriteLine("6. Reporte y listado: "); //genera reportes  e imprime listados 
                Console.WriteLine("7. Accesibilidad");
              
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {///configurar bien el menu
                    case "1":
                        CreateBeneficiario();
                        break;
                    case "2":
                        ReadBeneficiario();//datos por cedula
                        break;
                    case "3":
                        ReadAllBeneficiario();// total de ninos
                        break;
                    case "4":
                        UpdateBeneficiario();
                        break;
                    case "5":
                        DeleteBeneficiario();
                        break;
                    case "6":
                        DeleteBeneficiario();
                        break;
                    case "7":
                        DeleteBeneficiario();

                        break;
                    case "0":
                        return; // Salir del menú
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        Console.ReadLine();
                        break;

                }
            }
        }

        private static void CreateBeneficiario()
        {
            Console.Clear();

            Console.WriteLine("Registrar un Beneficiario");

            Console.WriteLine("Ingrese la cedula del Beneficiario: ");
            string cedula = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese los nombres del Beneficiario: ");
            string nombres = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese los apellidos del Beneficiario: ");
            string apellidos = Console.ReadLine();
            Console.WriteLine();


            Beneficiarios objBeneficiarios = new Beneficiarios(cedula, nombres, apellidos);

            Console.WriteLine("Beneficiario Registrado Correctamente");
        
            Console.ReadLine();
        }

        private static void ReadBeneficiario()
        {
            Console.Clear();
            Console.WriteLine(" Buscar Beneficiario Registrados");
            Console.Write("Ingrese la cédula del Beneficiario a buscar: ");
            string cedula = Console.ReadLine();
            Beneficiarios objBeneficiarioBuscado = BSD.BaseDatos.BaseDeDatos.BuscarBeneficiarioPorCedula(cedula);

            if (objBeneficiarioBuscado != null)
            {
                objBeneficiarioBuscado.imprimir();

            }
            else
            {
                Console.WriteLine("Beneficiario no encontrado");
            }
            Console.ReadLine();
           
        }


        //READ ALL CLIENTES
        private static void ReadAllBeneficiario()
        {
            Console.Clear();
            Console.WriteLine("**** Mostrar Lista de Beneficiario ****");
            Console.WriteLine();
            BSD.BaseDatos.BaseDeDatos.ImprimirBeneficiarios();
            Console.ReadLine();
            Console.Clear();
        }



        //UPDATE CLIENTE
        private static void UpdateBeneficiario()
        {
            Console.Clear();
            Console.WriteLine("**** Actualizar información de un Beneficiario ****");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del Beneficiario a buscar: ");
            string cedula = Console.ReadLine();
            Beneficiarios objBeneficiarioBuscado = BSD.BaseDatos.BaseDeDatos.BuscarBeneficiarioPorCedula(cedula);

            if (objBeneficiarioBuscado != null)
            {
                objBeneficiarioBuscado.imprimir();
                Console.WriteLine("Ingrese los nombres del Beneficiario a modificar: ");
                string nombres = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Ingrese los apellidos del Beneficiario a modificar: ");
                string apellidos = Console.ReadLine();
                Console.WriteLine();
                objBeneficiarioBuscado.setNombres(nombres);
                objBeneficiarioBuscado.setApellidos(apellidos);
                BSD.BaseDatos.BaseDeDatos.BaseDatosCliente.RemoveAt(objBeneficiarioBuscado.getID() - 1); //ELIMINAR CLIENTE
                BSD.BaseDatos.BaseDeDatos.BaseDatosCliente.Insert(objBeneficiarioBuscado.getID() - 1, objBeneficiarioBuscado); // INSERTAR CLIENTE
                Console.WriteLine("¡Beneficiario actualizado con éxito!");

            }
            else
            {
                Console.WriteLine("Beneficiario no encontrado.");
            }
            Console.ReadLine();
            
        }

        //DELETE CLIENTE
        private static void DeleteBeneficiario()
        {
            Console.Clear();
            Console.WriteLine("**** Eliminar un Beneficiario existente ****");
            Console.WriteLine();
            Console.Write("Ingrese la cédula del Beneficiario a eliminar: ");
            string cedula = Console.ReadLine();
            Beneficiarios objBeneficiarioBuscado = BSD.BaseDatos.BaseDeDatos.BuscarBeneficiarioPorCedula(cedula);

            if (objBeneficiarioBuscado != null)
            {
                Console.WriteLine($"¿Está seguro de que desea eliminar la información del Beneficiario: {objBeneficiarioBuscado.getNombresCompletos()} ? (S/N)");
                string confirmacion = Console.ReadLine().ToUpper();
                if (confirmacion == "S")
                {
                    BSD.BaseDatos.BaseDeDatos.BaseDatosCliente.Remove(objBeneficiarioBuscado);
                    Console.WriteLine("Información eliminada correctamente.");
                }
                else
                {
                    Console.WriteLine("Se ha cancelado la eliminación.");
                }
            }
            else
            {
                Console.WriteLine("Beneficiario no encontrado.");
            }
            Console.ReadLine();
       
        }



      
    }
}



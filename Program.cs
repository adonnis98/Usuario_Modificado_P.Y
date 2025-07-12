using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Clases;

namespace Usuario
{
    public class Program
    {
        private static Clases.Usuario gestionUsuarios = new Clases.Usuario();

        static void Main(string[] args)
        {
            gestionUsuarios = new Clases.Usuario();
            gestionUsuarios.CrearUsuariosAdministrativos();
            DisplayLoginScreen();
            DisplayMainMenu();
            // con esto se muestra la pantalla de inicio de sesión
        }
        static void DisplayLoginScreen()
        {
            Console.WriteLine("████████████████████████████████████████████████████");
            Console.WriteLine("█                                                  █");
            Console.WriteLine("█ * * F U N D A C I Ó N  R E S P L A N D E C E * * █");
            Console.WriteLine("█                                                  █");
            Console.WriteLine("████████████████████████████████████████████████████");

            Console.WriteLine("\nBienvenido al sistema Resplandece Kids\n");
            //con esto solicitamos el usuario y contraseña
            bool isAuthenticated = false;
            while (!isAuthenticated)
            {
                Console.Write("Usuario: ");
                string username = Console.ReadLine();

                Console.Write("Contraseña: ");
                string password = ReadPassword();

                // aqui se usa el método de autenticación de GestionUsuarios
                isAuthenticated = gestionUsuarios.AutenticarUsuario(username, password);

                if (!isAuthenticated)
                {
                    Console.WriteLine("\nUsuario o contraseña incorrectos. Intente de nuevo.\n");
                }
            }

            Console.Clear(); // Limpia la consola después de un inicio de sesión exitoso
                             // Muestra el menú principal después de iniciar sesión correctamente
        }



        ///si quiero la contraseña privadaal escribirla
        private static string ReadPassword()
        {
            StringBuilder passwordBuilder = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true); // 'true' intercepta la tecla para que no se muestre en la consola


                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    passwordBuilder.Append(key.KeyChar);
                    Console.Write("*"); // Muestra un asterisco por cada carácter
                }
                // Si es Backspace y hay caracteres para borrar, eliminar el último y retroceder el cursor
                else if (key.Key == ConsoleKey.Backspace && passwordBuilder.Length > 0)
                {
                    passwordBuilder.Remove(passwordBuilder.Length - 1, 1);
                    Console.Write("\b \b"); // Borra el asterisco anterior
                }
            }
            while (key.Key != ConsoleKey.Enter); // Detener cuando se presiona Enter

            Console.WriteLine(); // Mueve el cursor a la siguiente línea después de presionar Enter
            return passwordBuilder.ToString();
        }


        // ejemplo de menu
        static void DisplayMainMenu()
        {

            while (true)
            {
                Console.WriteLine("█████████████████████████████████████████");
                Console.WriteLine("█                                       █");
                Console.WriteLine("█      * * * Menú Principal * * *       █");
                Console.WriteLine("█                                       █");
                Console.WriteLine("█████████████████████████████████████████");
                Console.WriteLine("1. Registrar nuevo niños@ "); //TIENE QUE SER FUNCIONAL PARA REGISTRAR 
                Console.WriteLine("2. Clasificación automática por grupo etario"); //esto tendria que ser automaticamente DENTRO DEL SISTEMAA
                Console.WriteLine("3. Asignación de niños a programas específicos"); // Este punto se aborda con la asignación automática por edad Y AL PRESIONAR ESTA OPCION DEBERIA MOTRAR UN LISTADO DE LOS NIÑOS CON SUS RESPETIVOS PROGRAMAS CONFORME A LA EDAD
                Console.WriteLine("4. Búsqueda por nombre, edad, o programa de apoyo"); //UTIL QUIERO QUE APAREZCA Y SEA FUNCIONAL
                Console.WriteLine("5. Historial básico de salud y observaciones personales"); // QUIERO QUE SEA UNA FICHA COMPLETA DE TODOS LOS DATOS DEL NIÑO  BUSCADO POR QUE HAY QUE BUSCAR POR NIÑO Y QUE OBVIAMENTE TENGA Historial básico de salud y observaciones personales
                Console.WriteLine("6. Gestión de usuarios del sistema"); //NO QUIERO ESTO
                Console.WriteLine("7. Generación de listados por grupo de edad o por programa");//EN ESTO QUIERO QUE MUESTRE UNA LISTA DE LOS NIÑOS CON SU RESPECTIVO TUTOR Y DE QUE EDAD HASTA QUE EDAD RECIBE
                Console.WriteLine("8. Reportes estadísticos por género, edad, nivel de participación"); //UN REPORTE DE ASISTENCIA?, HAY QUE PENSARLO
                Console.WriteLine("9. Interfaz amigable y segura para el personal de la fundación");// ESTO NO QUIERO
                Console.WriteLine("10. Respaldo y exportación de datos en formatos digitales"); // ESO SERIA necesARIO YA QUE SE LE PODRA ENVIAR AL CORREO DEL REPRESENTANTE
                Console.WriteLine("11. Listado completo de niños ingresados");// TENDRIA QUE SER UNA LISTA DE TODOS LOS NIÑOS INGRESADOS
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                Console.ReadLine();
            }
        }
    }
}



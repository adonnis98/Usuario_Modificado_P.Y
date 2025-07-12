using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Clases
{
    public class Usuario
    {
        public string usuario;
        public string contraseña;
        public string rol;

        public Usuario(string usuario, string contraseña, string admin)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.rol = admin;
        }

       
            public List<Usuario> UsuariosDelSistema;

            public Usuario()
            {
                UsuariosDelSistema = new List<Usuario>();
            }

            public void CrearUsuariosAdministrativos()
            {
                Usuario admin1 = new Usuario("Pilar", "PI2025", "Administrador");
                UsuariosDelSistema.Add(admin1);

                Usuario admin2 = new Usuario("Narcisa", "NAR2025", "Administrador");
                UsuariosDelSistema.Add(admin2);

                Usuario admin3 = new Usuario("Adonis", "adn123", "Administrador");
                UsuariosDelSistema.Add(admin3);
        }

        public void MostrarUsuarios()
            {
                foreach (var usuario in UsuariosDelSistema)
                {
                    Console.WriteLine($"Usuario: {usuario.usuario}, Rol: {usuario.rol}");
                }
            }
            // con esto autentificamos a un usuario si son los registrados
            public bool AutenticarUsuario(string username, string password)
            {
                foreach (var user in UsuariosDelSistema)
                {
                    if (user.usuario == username && user.contraseña == password)
                    {
                        return true;
                    }
                }
                return false;
            }
            //para crear un nuevo usuario desde dentro del sistema
            //public void CrearUsuariosAdministrativos()
            //{
            //Usuario admin1 = new Usuario("Pilar", "PI2025", "Administrador");
            //UsuariosDelSistema.Add(admin1);
            //Usuario admin2 = new Usuario("Narcisa", "NAR2025", "Administrador");
            //UsuariosDelSistema.Add(admin2);
            //}
        }
    }


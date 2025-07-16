﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSD.BaseDatos;

    namespace BSD.Clases
    {
        public class Beneficiarios
        {
            private int id;
            public string cedula;
            private string nombres;
            private string apellidos;
            private string nombres_completos;

       

        public void setNombres(string nombres)
        {
            this.nombres = nombres;
            this.nombres_completos = nombres + " " + this.apellidos;
        }

        public void setApellidos(string apellidos)
        {
            this.apellidos = apellidos;
            this.nombres_completos = this.nombres + " " + apellidos;
        }

        public string getNombresCompletos()
        {
            return this.nombres_completos;
        }

        public int getID()
        {
            return this.id;
        }
        public Beneficiarios(string cedula, string nombres, string apellidos)
        {
            int secuencialGenerado = BaseDeDatos.BaseDatosCliente.Count() + 1;
            this.id = secuencialGenerado;
            this.cedula = cedula;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.nombres_completos = nombres + " " + apellidos;

            BaseDeDatos.BaseDatosCliente.Add(this);
        }

        public void imprimir()
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("ID: " + this.id);
                Console.WriteLine("Cédula: " + this.cedula);
                Console.WriteLine("Nombres: " + this.nombres);
                Console.WriteLine("Apellidos: " + this.apellidos);
                Console.WriteLine("Nombres Completos: " + this.nombres_completos);
                Console.WriteLine("=========================================");
            }
        }
    }


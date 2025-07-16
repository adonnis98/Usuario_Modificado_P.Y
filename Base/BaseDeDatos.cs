using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using BSD.Clases;

namespace BSD.BaseDatos
{
    public static class BaseDeDatos
    {
        public static List<Beneficiarios> BaseDatosCliente = new List<Beneficiarios>();

        public static void ImprimirBeneficiarios()
        {
            foreach (Beneficiarios cliente in BaseDatosCliente)
            {
                cliente.imprimir();
            }
        }


        public static Beneficiarios BuscarBeneficiarioPorCedula(string parametro_cedula)
        {
            return BaseDatosCliente.FirstOrDefault(bdc => bdc.cedula == parametro_cedula);
        }


    }
}
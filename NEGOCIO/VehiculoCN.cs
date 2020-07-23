using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
   public class VehiculoCN
    {


        private static VehiculoDAL obj = new VehiculoDAL();

        public static void Agregar(Vehiculo vehiculo)
        {
            obj.Agregar(vehiculo);
        }

        public static List<Vehiculo> ListarVehiculo()
        {
            return obj.ListarVehiculo();
        }

        public static Vehiculo GetVehiculo(int id)
        {
            return obj.ObtenerVehiculo(id);
        }

        public static void Editar(Vehiculo vehiculo)
        {
            obj.Editar(vehiculo);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}

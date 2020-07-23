using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
   public class Vehiculo_ServicioCN
    {
        private static Vehiculo_ServicioDAL obj = new Vehiculo_ServicioDAL();

        public static void Agregar(Vehiculo_Servicio vehiculo_servicio)
        {
            obj.Agregar(vehiculo_servicio);
        }

        public static List<Vehiculo_Servicio> ListarVehiculo_Servicio()
        {
            return obj.ListarVehiculo_Servicio();

        }

        public static Vehiculo_Servicio GetVehiculo_Servicio(int id)
        {
            return obj.ObtenerVehiculo_Servicio(id);
        }

        public static void Editar(Vehiculo_Servicio vehiculo_servicio)
        {
            obj.Editar(vehiculo_servicio);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}

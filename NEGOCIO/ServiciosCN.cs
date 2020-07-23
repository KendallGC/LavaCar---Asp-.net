using DATOS;
using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
   public class ServiciosCN
    {

        private static ServiciosDAL obj = new ServiciosDAL();

        public static void Agregar(Servicios servicio)
        {
            obj.Agregar(servicio);
        }

        public static List<Servicios> ListarServicios()
        {
            return obj.ListarServicios();
        }

        public static Servicios GetServicios(int id)
        {
            return obj.ObtenerServicios(id);
        }

        public static void Editar(Servicios servicio)
        {
            obj.Editar(servicio);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}

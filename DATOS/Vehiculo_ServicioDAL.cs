using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{


    
   public class Vehiculo_ServicioDAL
    {

        public void Agregar(Vehiculo_Servicio vs)
        {
            using (var db = new LavaCarEntities())
            {
                db.Vehiculo_Servicio.Add(vs);
                db.SaveChanges();
            }
        }

        public void Editar(Vehiculo_Servicio vs)
        {
            using (var db = new LavaCarEntities())
            {

                var origen = db.Vehiculo_Servicio.Find(vs.ID_Vehiculo_Servicio);
                origen.ID_Servicio = vs.ID_Servicio;
                origen.ID_Vehiculo = vs.ID_Vehiculo;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new LavaCarEntities())
            {
                var vs = db.Vehiculo_Servicio.Find(id);
                db.Vehiculo_Servicio.Remove(vs);
                db.SaveChanges();
            }
        }

        public List<Vehiculo_Servicio> ListarVehiculo_Servicio()
        {
            string sql = @"select vs.[ID_Vehiculo-Servicio], vs.ID_Servicio, vs.ID_Vehiculo from [Vehiculo-Servicio] vs ";
            using (var db = new LavaCarEntities())
            {
                return db.Database.SqlQuery<Vehiculo_Servicio>(sql).ToList();
            }
        }

        public Vehiculo_Servicio ObtenerVehiculo_Servicio(int id)
        {
            string sql = @"select vs.[ID_Vehiculo-Servicio], vs.ID_Servicio, vs.ID_Vehiculo from [Vehiculo-Servicio] vs 
                            where vs.[ID_Vehiculo-Servicio] = @ID_Vehiculo-Servicio";
            using (var db = new LavaCarEntities())
            {

                return db.Database.SqlQuery<Vehiculo_Servicio>(sql,
                    new SqlParameter("@ID_Vehiculo-Servicio", id)).FirstOrDefault();
            }
        }
    }
}

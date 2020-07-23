using ENTIDAD;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace DATOS
{
    public class ServiciosDAL
    {

        public void Agregar(Servicios servicios)
        {
            using (var db = new LavaCarEntities())
            {
                db.Servicios.Add(servicios);
                db.SaveChanges();
            }
        }

        public void Editar(Servicios servicios)
        {
            using (var db = new LavaCarEntities())
            {

                var origen = db.Servicios.Find(servicios.ID_Servicio);
                origen.Descripción = servicios.Descripción;
                origen.Monto = servicios.Monto;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new LavaCarEntities())
            {
                var servicios = db.Servicios.Find(id);
                db.Servicios.Remove(servicios);
                db.SaveChanges();
            }
        }
        public List<Servicios> ListarServicios() //SERVICIOSCE
        {
            string sql = @"select s.ID_Servicio,s.Descripción, s.Monto from Servicios s";
            using (var db = new LavaCarEntities())
            {
                return db.Database.SqlQuery<Servicios>(sql).ToList();
            }
        }

        public Servicios ObtenerServicios(int id) //SERVICIOSCE
        {
            string sql = @"select s.ID_Servicio,s.Descripción, 
                          s.Monto from Servicios s where s.ID_Servicio = @ID_Servicio";
            using (var db = new LavaCarEntities())
            {
                
                return db.Database.SqlQuery<Servicios>(sql,
                    new SqlParameter("@ID_Servicio", id)).FirstOrDefault();
            }
        }
    }
}

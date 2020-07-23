using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
  public  class VehiculoDAL
    {

        public void Agregar(Vehiculo vehiculo)
        {
            using (var db = new LavaCarEntities())
            {
                db.Vehiculo.Add(vehiculo);
                db.SaveChanges();
            }
        }

        public void Editar(Vehiculo vehiculo)
        {
            using (var db = new LavaCarEntities())
            {

                var origen = db.Vehiculo.Find(vehiculo.ID_Vehiculo);
                origen.Placa = vehiculo.Placa;
                origen.Dueño = vehiculo.Dueño;
                origen.Marca = vehiculo.Marca;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new LavaCarEntities())
            {
                var vehiculo = db.Vehiculo.Find(id);
                db.Vehiculo.Remove(vehiculo);
                db.SaveChanges();
            }
        }

        public List<Vehiculo> ListarVehiculo()
        {
            string sql = @"select v.ID_Vehiculo, v.Placa,v.Dueño,v.Marca from Vehiculo v";
            using (var db = new LavaCarEntities())
            {
                return db.Database.SqlQuery<Vehiculo>(sql).ToList();
            }
        }

        public Vehiculo ObtenerVehiculo(int id)
        {
            string sql = @"select v.ID_Vehiculo, v.Placa,v.Dueño,v.Marca from Vehiculo v where v.ID_Vehiculo = @ID_Vehiculo";
            using (var db = new LavaCarEntities())
            {

                return db.Database.SqlQuery<Vehiculo>(sql,
                    new SqlParameter("@ID_Vehiculo", id)).FirstOrDefault();
            }
        }


    }
}
